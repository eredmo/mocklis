// <auto-generated />

#nullable enable

namespace Test
{
    partial class TestClass
    {
        public global::Mocklis.Core.EventMock<global::System.EventHandler> NonNullableEvent { get; }

        event global::System.EventHandler global::Test.ITestClass.NonNullableEvent { add => NonNullableEvent.Add(value); remove => NonNullableEvent.Remove(value); }

        public global::Mocklis.Core.EventMock<global::System.EventHandler> NullableEvent { get; }

        event global::System.EventHandler? global::Test.ITestClass.NullableEvent { add => NullableEvent.Add(value); remove => NullableEvent.Remove(value); }

        protected TestClass() : base()
        {
            this.NonNullableEvent = new global::Mocklis.Core.EventMock<global::System.EventHandler>(this, "TestClass", "ITestClass", "NonNullableEvent", "NonNullableEvent", global::Mocklis.Core.Strictness.Lenient);
            this.NullableEvent = new global::Mocklis.Core.EventMock<global::System.EventHandler>(this, "TestClass", "ITestClass", "NullableEvent", "NullableEvent", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
