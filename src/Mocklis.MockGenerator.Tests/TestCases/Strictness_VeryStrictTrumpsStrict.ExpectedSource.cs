// <auto-generated />

namespace Test
{
    partial class TestClass
    {
        // Adding line for Property Based Property Mock

        // Adding line for Property Based Indexer Mock

        public global::Mocklis.Core.FuncMethodMock<string, string> MyMethod { get; }

        string global::Test.ITestClass.MyMethod(string param) => MyMethod.Call(param);

        // Adding line for Property Based Event Mock

        public TestClass() : base()
        {
            this.MyMethod = new global::Mocklis.Core.FuncMethodMock<string, string>(this, "TestClass", "ITestClass", "MyMethod", "MyMethod", global::Mocklis.Core.Strictness.VeryStrict);
        }
    }
}
