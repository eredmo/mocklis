// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtractedClassInformation.cs">
//   SPDX-License-Identifier: MIT
//   Copyright © 2019-2020 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Mocklis.CodeGeneration;

namespace Mocklis.CodeGeneration
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Mocklis.CodeGeneration.Compatibility;
    using Mocklis.CodeGeneration.UniqueNames;
    using F = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    #endregion

    public record struct MockSettings(bool MockReturnsByRef, bool MockReturnsByRefReadonly, bool Strict, bool VeryStrict);

    public class ExtractionMocklisSymbols
    {
        private readonly Compilation _compilation;
        private readonly INamedTypeSymbol _object;
        public INamedTypeSymbol MocklisClassAttribute { get; }

        public ExtractionMocklisSymbols(Compilation compilation)
        {
            INamedTypeSymbol GetTypeSymbol(string metadataName)
            {
                return compilation.GetTypeByMetadataName(metadataName) ??
                       throw new ArgumentException($"Compilation does not contain {metadataName}.", nameof(compilation));
            }

            _compilation = compilation;
            _object = GetTypeSymbol("System.Object");
            MocklisClassAttribute = GetTypeSymbol("Mocklis.Core.MocklisClassAttribute");
        }

        public bool HasImplicitConversionToObject(ITypeSymbol symbol)
        {
            return _compilation.HasImplicitConversion(symbol, _object);
        }
    }

    public class ExtractedClassInformation
    {
        public INamedTypeSymbol ClassSymbol { get; }
        public MockSettings Settings { get; }
        public bool NullableContextEnabled { get; }
        private readonly ExtractedInterfaceInformation[] _interfaces;
        public IReadOnlyList<ExtractedInterfaceInformation> Interfaces => _interfaces;

        private ExtractedClassInformation(INamedTypeSymbol classSymbol, IEnumerable<ExtractedInterfaceInformation> interfaces, MockSettings settings, bool nullableContextEnabled)
        {
            ClassSymbol = classSymbol;
            Settings = settings;
            NullableContextEnabled = nullableContextEnabled;
            _interfaces = interfaces.ToArray();
        }

        public static ExtractedClassInformation BuildFromClassSymbol(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel)
        {
            //TODO: Reinstate cancellation token...

            var symbols = new ExtractionMocklisSymbols(semanticModel.Compilation);

            var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration) ?? throw new ArgumentException("symbol for class was not found in semantic model.", nameof(classDeclaration));

            var settings = GetSettingsFromAttribute(classDeclaration, classSymbol, symbols);

            var classIsInNullableContext = semanticModel.ClassIsInNullableContext(classDeclaration);

            // Identify the interfaces here...
            var namesToReserveAndUse = new List<string>(classSymbol.BaseType?.GetUsableNames() ?? Array.Empty<string>()) { classSymbol.Name };
            var uniquifier = new Uniquifier(namesToReserveAndUse);

            var interfaceList = new List<(INamedTypeSymbol interfaceSymbol, List<ISymbol> memberSymbols)>();

            var baseTypeSymbol = classSymbol.BaseType;
            foreach (var interfaceSymbol in classSymbol.AllInterfaces)
            {
                var memberSymbols = new List<ISymbol>();

                foreach (var memberSymbol in interfaceSymbol.GetMembers())
                {
                    if (!memberSymbol.IsAbstract)
                    {
                        continue;
                    }

                    if (memberSymbol is IMethodSymbol && !memberSymbol.CanBeReferencedByName)
                    {
                        continue;
                    }

                    if (baseTypeSymbol?.FindImplementationForInterfaceMember(memberSymbol) != null)
                    {
                        continue;
                    }

                    memberSymbols.Add(memberSymbol);
                    uniquifier.ReserveName(memberSymbol.Name);
                }

                if (memberSymbols.Any())
                {
                    interfaceList.Add((interfaceSymbol, memberSymbols));
                }
            }

            var interfaces = new ExtractedInterfaceInformation[interfaceList.Count];

            for (int i = 0; i < interfaceList.Count; i++)
            {
                var (isym, msyms) = interfaceList[i];

                var members = new IMemberMock[msyms.Count];

                for (int j = 0; j < msyms.Count; j++)
                {
                    // Create the right type of member...?
                    members[j] = CreateMock(symbols, classSymbol, isym, msyms[j], uniquifier, settings);
                }

                interfaces[i] = new ExtractedInterfaceInformation(isym, members);
            }

            return new ExtractedClassInformation(classSymbol, interfaces, settings, classIsInNullableContext);
        }


        public static IMemberMock CreateMock(ExtractionMocklisSymbols mocklisSymbols, INamedTypeSymbol classSymbol, INamedTypeSymbol interfaceSymbol, ISymbol memberSymbol, Uniquifier uniquifier, MockSettings settings)
        {
            string mockMemberName = uniquifier.GetUniqueName(memberSymbol.MetadataName);

            switch (memberSymbol)
            {
                case IPropertySymbol memberPropertySymbol:
                {
                    var hasRestrictedParameter = memberPropertySymbol.Parameters.Any(p => !mocklisSymbols.HasImplicitConversionToObject(p.Type));
                    var hasRestrictedReturnType = !mocklisSymbols.HasImplicitConversionToObject(memberPropertySymbol.Type);

                    bool useVirtualMethod = hasRestrictedParameter || hasRestrictedReturnType ||
                                            memberPropertySymbol.ReturnsByRef && !settings.MockReturnsByRef ||
                                            memberPropertySymbol.ReturnsByRefReadonly && !settings.MockReturnsByRefReadonly;

                    if (memberPropertySymbol.IsIndexer)
                    {
                        if (useVirtualMethod)
                        {
                            return new VirtualMethodBasedIndexerMock(interfaceSymbol, memberPropertySymbol, mockMemberName);
                        }

                        return new PropertyBasedIndexerMock(interfaceSymbol, memberPropertySymbol, mockMemberName);
                    }

                    if (useVirtualMethod)
                    {
                        return new VirtualMethodBasedPropertyMock(interfaceSymbol, memberPropertySymbol, mockMemberName);
                    }

                    return new PropertyBasedPropertyMock(interfaceSymbol, memberPropertySymbol, mockMemberName);
                }

                case IEventSymbol memberEventSymbol:
                    return new PropertyBasedEventMock(interfaceSymbol, memberEventSymbol, mockMemberName);
                case IMethodSymbol memberMethodSymbol:
                {
                    var hasRestrictedParameter = memberMethodSymbol.Parameters.Any(p => !mocklisSymbols.HasImplicitConversionToObject(p.Type));
                    var hasRestrictedReturnType = !memberMethodSymbol.ReturnsVoid &&
                                                  !mocklisSymbols.HasImplicitConversionToObject(memberMethodSymbol.ReturnType);

                    bool useVirtualMethod = hasRestrictedParameter || hasRestrictedReturnType || memberMethodSymbol.IsVararg;

                    useVirtualMethod = useVirtualMethod || memberMethodSymbol.ReturnsByRef && !settings.MockReturnsByRef;
                    useVirtualMethod = useVirtualMethod || memberMethodSymbol.ReturnsByRefReadonly && !settings.MockReturnsByRefReadonly;

                    var typeParameterSubstitutions = new Substitutions(classSymbol, memberMethodSymbol);

                    if (useVirtualMethod)
                    {
                        return new VirtualMethodBasedMethodMock(interfaceSymbol, memberMethodSymbol, mockMemberName, typeParameterSubstitutions);
                    }

                    if (memberMethodSymbol.Arity > 0)
                    {
                        var metadataName = memberSymbol.MetadataName;
                        var mockProviderName = uniquifier.GetUniqueName( "_" + char.ToLowerInvariant(metadataName[0]) + metadataName.Substring(1));
                        return new PropertyBasedMethodMockWithTypeParameters(interfaceSymbol, memberMethodSymbol, mockMemberName, typeParameterSubstitutions, mockProviderName);
                    }

                    return new PropertyBasedMethodMock(interfaceSymbol, memberMethodSymbol, mockMemberName, typeParameterSubstitutions);
                }

                default:
                    return NullMemberMock.Instance;
            }
        }

        public static MockSettings GetSettingsFromAttribute(ClassDeclarationSyntax classDeclaration, INamedTypeSymbol classSymbol, ExtractionMocklisSymbols symbols)
        {
            bool mockReturnsByRef = false;
            bool mockReturnsByRefReadonly = true;
            bool strict = false;
            bool veryStrict = false;
            var attribute = classSymbol.GetAttributes().SingleOrDefault(a =>
                a.AttributeClass != null && a.AttributeClass.Equals(symbols.MocklisClassAttribute, SymbolEqualityComparer.Default));

            if (attribute != null)
            {
                var attributeSyntaxReference = attribute.ApplicationSyntaxReference ??
                                               throw new ArgumentException("MocklisClass attribute did not have syntax reference.");

                var attributeArguments = classDeclaration.FindNode(attributeSyntaxReference.Span).DescendantNodes().OfType<AttributeArgumentSyntax>();

                foreach (var k in attributeArguments)
                {
                    if (k.Expression is LiteralExpressionSyntax les)
                    {
                        var name = k.NameEquals?.Name.Identifier.Text;
                        bool value;
                        if (les.IsKind(SyntaxKind.TrueLiteralExpression))
                        {
                            value = true;
                        }
                        else if (les.IsKind(SyntaxKind.FalseLiteralExpression))
                        {
                            value = false;
                        }
                        else
                        {
                            break;
                        }

                        switch (name)
                        {
                            case "MockReturnsByRef":
                                mockReturnsByRef = value;
                                break;
                            case "MockReturnsByRefReadonly":
                                mockReturnsByRefReadonly = value;
                                break;
                            case "Strict":
                                strict = value;
                                break;
                            case "VeryStrict":
                                veryStrict = value;
                                break;
                        }
                    }
                }
            }

            // 'Very strict' implies 'strict'
            strict |= veryStrict;

            return new MockSettings(mockReturnsByRef, mockReturnsByRefReadonly, strict, veryStrict);
        }



        public void AddSourceToContext(SourceProductionContext context)
        {
            var sb = new StringBuilder();

            sb.AppendLine("// <auto-generated />");
            sb.AppendLine();

            context.AddSource(ClassSymbol.Name + ".g.cs", sb.ToString());
        }

        public SyntaxList<MemberDeclarationSyntax> GenerateMembers(MocklisTypesForSymbols typesForSymbols)
        {
            var declarationList = new List<MemberDeclarationSyntax>();

            var constructorStatements = new List<StatementSyntax>();

            var constructorDeclarationList = new List<MemberDeclarationSyntax>();

            foreach (var i in Interfaces)
            {
                i.GenerateMembers(typesForSymbols, Settings, declarationList, constructorStatements, ClassSymbol);
            }

            GenerateConstructors(constructorDeclarationList, constructorStatements, typesForSymbols, ClassSymbol);

            declarationList.InsertRange(0, constructorDeclarationList);

            return new SyntaxList<MemberDeclarationSyntax>(declarationList);
        }

         private void GenerateConstructors(IList<MemberDeclarationSyntax> declarationList, List<StatementSyntax> constructorStatements, MocklisTypesForSymbols typesForSymbols, ITypeSymbol classSymbol)
            {
                static bool CanAccessConstructor(IMethodSymbol constructor)
                {
                    // TODO: Should we consider allowing access to internal constructors as well - if they can be seen?
                    switch (constructor.DeclaredAccessibility)
                    {
                        case Accessibility.Protected:
                        case Accessibility.ProtectedOrInternal:
                        case Accessibility.Public:
                        {
                            return true;
                        }

                        default:
                        {
                            return false;
                        }
                    }
                }

                var baseTypeConstructors = classSymbol.BaseType?.Constructors.Where(c => !c.IsStatic && !c.IsVararg && CanAccessConstructor(c))
                    .ToArray() ?? Array.Empty<IMethodSymbol>();

                if (baseTypeConstructors.Length == 1 && baseTypeConstructors[0].Parameters.Length == 0 && constructorStatements.Count == 0)
                {
                    // This would correspond to emitting just a default constructor, which we don't really need to do.
                    return;
                }

                foreach (var constructor in baseTypeConstructors)
                {
                    var parameterNames = constructor.Parameters.Select(p => p.Name).ToArray();

                    var constructorStatementsWithThisWhereRequired = constructorStatements.Select(constructorStatement =>
                    {
                        if (constructorStatement is ExpressionStatementSyntax { Expression: AssignmentExpressionSyntax { Left: IdentifierNameSyntax identifierNameSyntax } assignmentExpressionSyntax } expressionStatementSyntax && parameterNames.Contains(identifierNameSyntax.Identifier.Text)
                        )
                        {
                            var newLeft = F.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, F.ThisExpression(), identifierNameSyntax);
                            return expressionStatementSyntax.WithExpression(assignmentExpressionSyntax.WithLeft(newLeft));
                        }

                        return constructorStatement;
                    });

                    var constructorDeclaration = F.ConstructorDeclaration(F.Identifier(classSymbol.Name))
                        .WithModifiers(F.TokenList(F.Token(classSymbol.IsAbstract ? SyntaxKind.ProtectedKeyword : SyntaxKind.PublicKeyword)))
                        .WithParameterList(
                            F.ParameterList(
                                F.SeparatedList(constructor.Parameters.Select(tp => typesForSymbols.AsParameterSyntax(tp)))))
                        .WithBody(F.Block(constructorStatementsWithThisWhereRequired));

                    if (parameterNames.Any())
                    {
                        constructorDeclaration = constructorDeclaration.WithInitializer(F.ConstructorInitializer(
                            SyntaxKind.BaseConstructorInitializer,
                            F.ArgumentList(constructor.Parameters.AsArgumentList())));
                    }

                    declarationList.Add(constructorDeclaration);
                }
            }
        }
    }

public class ExtractedInterfaceInformation
{
    public INamedTypeSymbol InterfaceSymbol { get; }
    private readonly IMemberMock[] _memberMocks;

    public ExtractedInterfaceInformation(INamedTypeSymbol interfaceSymbol, IReadOnlyCollection<IMemberMock> memberMocks)
    {
        InterfaceSymbol = interfaceSymbol;
        _memberMocks = memberMocks.ToArray();
    }

    public void GenerateMembers(MocklisTypesForSymbols typesForSymbols, MockSettings mockSettings, List<MemberDeclarationSyntax> declarationList,
        List<StatementSyntax> constructorStatements, INamedTypeSymbol classSymbol)
    {
        var interfaceNameSyntax = typesForSymbols.ParseName(InterfaceSymbol);
        foreach (var memberMock in _memberMocks)
        {
            var syntaxAdder = memberMock.GetSyntaxAdder(typesForSymbols, mockSettings.Strict, mockSettings.VeryStrict);
            syntaxAdder.AddInitialisersToConstructor(constructorStatements, classSymbol.Name, InterfaceSymbol.Name);
            syntaxAdder.AddMembersToClass(declarationList, interfaceNameSyntax, classSymbol.Name, InterfaceSymbol.Name);
        }
    }
}

