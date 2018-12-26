// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MocklisEvent.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.CodeGeneration
{
    #region Using Directives

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using F = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    #endregion

    public class MocklisEvent : MocklisMember<IEventSymbol>
    {
        private TypeSyntax EventHandlerTypeSyntax { get; }
        public override TypeSyntax MockPropertyType { get; }

        public MocklisEvent(MocklisClass mocklisClass, INamedTypeSymbol interfaceSymbol, IEventSymbol symbol) : base(mocklisClass,
            interfaceSymbol, symbol)
        {
            EventHandlerTypeSyntax = mocklisClass.ParseTypeName(symbol.Type);

            MockPropertyType = mocklisClass.EventMock(EventHandlerTypeSyntax);
        }

        public override MemberDeclarationSyntax ExplicitInterfaceMember(string memberMockName)
        {
            var mockedProperty = F.EventDeclaration(EventHandlerTypeSyntax, Symbol.Name)
                .WithExplicitInterfaceSpecifier(F.ExplicitInterfaceSpecifier(InterfaceName));

            mockedProperty = mockedProperty.AddAccessorListAccessors(F.AccessorDeclaration(SyntaxKind.AddAccessorDeclaration)
                .WithExpressionBody(F.ArrowExpressionClause(F.InvocationExpression(
                        F.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, F.IdentifierName(memberMockName),
                            F.IdentifierName("Add")))
                    .WithExpressionsAsArgumentList(F.IdentifierName("value"))))
                .WithSemicolonToken(F.Token(SyntaxKind.SemicolonToken))
            );

            mockedProperty = mockedProperty.AddAccessorListAccessors(F.AccessorDeclaration(SyntaxKind.RemoveAccessorDeclaration)
                .WithExpressionBody(F.ArrowExpressionClause(F.InvocationExpression(
                        F.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                            F.IdentifierName(memberMockName), F.IdentifierName("Remove")))
                    .WithExpressionsAsArgumentList(F.IdentifierName("value"))))
                .WithSemicolonToken(F.Token(SyntaxKind.SemicolonToken)));

            return mockedProperty;
        }
    }
}
