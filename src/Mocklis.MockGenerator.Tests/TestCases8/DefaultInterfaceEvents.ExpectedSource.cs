// <auto-generated />

namespace Test
{
    partial class TestClass
    {
        public global::Mocklis.Core.EventMock<global::System.EventHandler> Normal { get; }

        event global::System.EventHandler global::Test.ITestClass.Normal { add => Normal.Add(value); remove => Normal.Remove(value); }

        public TestClass() : base()
        {
            this.Normal = new global::Mocklis.Core.EventMock<global::System.EventHandler>(this, "TestClass", "ITestClass", "Normal", "Normal", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}