// <auto-generated />

namespace Test
{
    partial class TestClass
    {
        public global::Mocklis.Core.PropertyMock<int> ReturnsByRef { get; }

        ref int global::Test.ITestClass.ReturnsByRef => ref global::Mocklis.Core.ByRef<int>.Wrap(ReturnsByRef.Value);

        protected virtual ref int ReturnsByRefReadonly()
        {
            throw new global::Mocklis.Core.MockMissingException(global::Mocklis.Core.MockType.VirtualPropertyGet, "TestClass", "ITestClass", "ReturnsByRefReadonly", "ReturnsByRefReadonly");
        }

        ref readonly int global::Test.ITestClass.ReturnsByRefReadonly => ref ReturnsByRefReadonly();

        public TestClass() : base()
        {
            this.ReturnsByRef = new global::Mocklis.Core.PropertyMock<int>(this, "TestClass", "ITestClass", "ReturnsByRef", "ReturnsByRef", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
