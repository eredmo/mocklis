// <auto-generated />

namespace Test
{
    partial class TestClass
    {
        public global::Mocklis.Core.PropertyMock<int> Test { get; }

        int global::Test.ITestClass.Test => Test.Value;

        public TestClass(int i) : base(i)
        {
            this.Test = new global::Mocklis.Core.PropertyMock<int>(this, "TestClass", "ITestClass", "Test", "Test", global::Mocklis.Core.Strictness.Lenient);
        }

        public TestClass(string s) : base(s)
        {
            this.Test = new global::Mocklis.Core.PropertyMock<int>(this, "TestClass", "ITestClass", "Test", "Test", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
