// <auto-generated />

namespace Test.Test2
{
    partial class TestClass
    {
        public global::Mocklis.Core.PropertyMock<int> GetOnly { get; }

        int global::Test.ITestClass.GetOnly => GetOnly.Value;

        public TestClass() : base()
        {
            this.GetOnly = new global::Mocklis.Core.PropertyMock<int>(this, "TestClass", "ITestClass", "GetOnly", "GetOnly", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
