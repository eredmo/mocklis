// <auto-generated />

namespace Test
{
    partial class TestClass
    {
        public global::Mocklis.Core.PropertyMock<string> NullableProperty { get; }

        string global::Test.ITestClass.NullableProperty => NullableProperty.Value;

        public global::Mocklis.Core.PropertyMock<string> NormalProperty { get; }

        string global::Test.ITestClass.NormalProperty => NormalProperty.Value;

        public global::Mocklis.Core.IndexerMock<int, string> Item { get; }

        string global::Test.ITestClass.this[int i] => Item[i];

        public global::Mocklis.Core.IndexerMock<bool, string> Item0 { get; }

        string global::Test.ITestClass.this[bool b] => Item0[b];

        public global::Mocklis.Core.IndexerMock<string, string> Item1 { get; }

        string global::Test.ITestClass.this[string s] => Item1[s];

        public global::Mocklis.Core.IndexerMock<(int i, string s), string> Item2 { get; }

        string global::Test.ITestClass.this[int i, string s] => Item2[(i, s)];

        public global::Mocklis.Core.EventMock<global::System.EventHandler> NonNullableEvent { get; }

        event global::System.EventHandler global::Test.ITestClass.NonNullableEvent { add => NonNullableEvent.Add(value); remove => NonNullableEvent.Remove(value); }

        public global::Mocklis.Core.EventMock<global::System.EventHandler> NullableEvent { get; }

        event global::System.EventHandler global::Test.ITestClass.NullableEvent { add => NullableEvent.Add(value); remove => NullableEvent.Remove(value); }

        public global::Mocklis.Core.FuncMethodMock<string, string> Method1 { get; }

        string global::Test.ITestClass.Method1(string parameter) => Method1.Call(parameter);

        public global::Mocklis.Core.FuncMethodMock<string, string> Method2 { get; }

        string global::Test.ITestClass.Method2(string parameter) => Method2.Call(parameter);

        public global::Mocklis.Core.FuncMethodMock<(string p1, string p2), string> Method3 { get; }

        string global::Test.ITestClass.Method3(string p1, string p2) => Method3.Call((p1, p2));

        protected TestClass() : base()
        {
            this.NullableProperty = new global::Mocklis.Core.PropertyMock<string>(this, "TestClass", "ITestClass", "NullableProperty", "NullableProperty", global::Mocklis.Core.Strictness.Lenient);
            this.NormalProperty = new global::Mocklis.Core.PropertyMock<string>(this, "TestClass", "ITestClass", "NormalProperty", "NormalProperty", global::Mocklis.Core.Strictness.Lenient);
            this.Item = new global::Mocklis.Core.IndexerMock<int, string>(this, "TestClass", "ITestClass", "this[]", "Item", global::Mocklis.Core.Strictness.Lenient);
            this.Item0 = new global::Mocklis.Core.IndexerMock<bool, string>(this, "TestClass", "ITestClass", "this[]", "Item0", global::Mocklis.Core.Strictness.Lenient);
            this.Item1 = new global::Mocklis.Core.IndexerMock<string, string>(this, "TestClass", "ITestClass", "this[]", "Item1", global::Mocklis.Core.Strictness.Lenient);
            this.Item2 = new global::Mocklis.Core.IndexerMock<(int i, string s), string>(this, "TestClass", "ITestClass", "this[]", "Item2", global::Mocklis.Core.Strictness.Lenient);
            this.NonNullableEvent = new global::Mocklis.Core.EventMock<global::System.EventHandler>(this, "TestClass", "ITestClass", "NonNullableEvent", "NonNullableEvent", global::Mocklis.Core.Strictness.Lenient);
            this.NullableEvent = new global::Mocklis.Core.EventMock<global::System.EventHandler>(this, "TestClass", "ITestClass", "NullableEvent", "NullableEvent", global::Mocklis.Core.Strictness.Lenient);
            this.Method1 = new global::Mocklis.Core.FuncMethodMock<string, string>(this, "TestClass", "ITestClass", "Method1", "Method1", global::Mocklis.Core.Strictness.Lenient);
            this.Method2 = new global::Mocklis.Core.FuncMethodMock<string, string>(this, "TestClass", "ITestClass", "Method2", "Method2", global::Mocklis.Core.Strictness.Lenient);
            this.Method3 = new global::Mocklis.Core.FuncMethodMock<(string p1, string p2), string>(this, "TestClass", "ITestClass", "Method3", "Method3", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
