// <auto-generated />

namespace Test
{
    partial class TestClass
    {
        public global::Mocklis.Core.FuncMethodMock<(T1 parameter, T3 parameter2, T4 anotherParameter), T2> Test { get; }

        T2 global::Test.ITestClass.Test(T1 parameter, T3 parameter2, T4 anotherParameter) => Test.Call((parameter, parameter2, anotherParameter));

        public TestClass() : base()
        {
            this.Test = new global::Mocklis.Core.FuncMethodMock<(T1 parameter, T3 parameter2, T4 anotherParameter), T2>(this, "TestClass", "ITestClass", "Test", "Test", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
