// <auto-generated />

namespace Test
{
    partial class TestClass
    {
        public global::Mocklis.Core.ActionMethodMock<string> DoStuff { get; }

        void global::InterfaceyStuff.ITest.DoStuff(string stuff) => DoStuff.Call(stuff);

        public TestClass() : base()
        {
            this.DoStuff = new global::Mocklis.Core.ActionMethodMock<string>(this, "TestClass", "ITest", "DoStuff", "DoStuff", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
