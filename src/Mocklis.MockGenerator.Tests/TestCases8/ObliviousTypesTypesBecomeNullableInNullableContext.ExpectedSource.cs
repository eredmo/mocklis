// <auto-generated />

#nullable enable

namespace Test
{
    partial class TestClass
    {
        public global::Mocklis.Core.PropertyMock<string?> NormalProperty { get; }

        string? global::Test.ITestClass.NormalProperty => NormalProperty.Value;

        public global::Mocklis.Core.IndexerMock<string?, string?> Item { get; }

        string? global::Test.ITestClass.this[string? s] => Item[s];

        public global::Mocklis.Core.EventMock<global::System.EventHandler> NonNullableEvent { get; }

        event global::System.EventHandler? global::Test.ITestClass.NonNullableEvent { add => NonNullableEvent.Add(value); remove => NonNullableEvent.Remove(value); }

        public global::Mocklis.Core.FuncMethodMock<(string? p1, string? p2), string?> Method3 { get; }

        string? global::Test.ITestClass.Method3(string? p1, string? p2) => Method3.Call((p1, p2));

        public global::Mocklis.Core.PropertyMock<int> ValueTypeProperty { get; }

        int global::Test.ITestClass.ValueTypeProperty => ValueTypeProperty.Value;

        public global::Mocklis.Core.PropertyMock<int?> NullableValueTypeProperty { get; }

        int? global::Test.ITestClass.NullableValueTypeProperty => NullableValueTypeProperty.Value;

        protected TestClass() : base()
        {
            this.NormalProperty = new global::Mocklis.Core.PropertyMock<string?>(this, "TestClass", "ITestClass", "NormalProperty", "NormalProperty", global::Mocklis.Core.Strictness.Lenient);
            this.Item = new global::Mocklis.Core.IndexerMock<string?, string?>(this, "TestClass", "ITestClass", "this[]", "Item", global::Mocklis.Core.Strictness.Lenient);
            this.NonNullableEvent = new global::Mocklis.Core.EventMock<global::System.EventHandler>(this, "TestClass", "ITestClass", "NonNullableEvent", "NonNullableEvent", global::Mocklis.Core.Strictness.Lenient);
            this.Method3 = new global::Mocklis.Core.FuncMethodMock<(string? p1, string? p2), string?>(this, "TestClass", "ITestClass", "Method3", "Method3", global::Mocklis.Core.Strictness.Lenient);
            this.ValueTypeProperty = new global::Mocklis.Core.PropertyMock<int>(this, "TestClass", "ITestClass", "ValueTypeProperty", "ValueTypeProperty", global::Mocklis.Core.Strictness.Lenient);
            this.NullableValueTypeProperty = new global::Mocklis.Core.PropertyMock<int?>(this, "TestClass", "ITestClass", "NullableValueTypeProperty", "NullableValueTypeProperty", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
