// <auto-generated />

namespace Test
{
    partial class TestClass
    {
        // Adding line for Property Based Property Mock

        public global::Mocklis.Core.ActionMethodMock<string> DoSomething { get; }

        void global::Test.ITest2.DoSomething(string task) => DoSomething.Call(task);

        public TestClass() : base()
        {
            this.DoSomething = new global::Mocklis.Core.ActionMethodMock<string>(this, "TestClass", "ITest2", "DoSomething", "DoSomething", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
