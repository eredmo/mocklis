using System;
using Mocklis.Core;

namespace Test
{
    public interface ITestClass
    {
        ref int this[int i] { get; }
        ref readonly int this[string s] { get; }
    }

    [MocklisClass(MockReturnsByRef = true, MockReturnsByRefReadonly = false)]
    public class TestClass : ITestClass
    {
        public TestClass()
        {
            Item = new IndexerMock<int, int>(this, "TestClass", "ITestClass", "this[]", "Item");
        }

        public IndexerMock<int, int> Item { get; }

        ref int ITestClass.this[int i] => ref ByRef<int>.Wrap(Item[i]);

        protected virtual ref int Item0(string s)
        {
            throw new MockMissingException(MockType.VirtualIndexerGet, "TestClass", "ITestClass", "this[]", "Item0");
        }

        ref readonly int ITestClass.this[string s] => ref Item0(s);
    }
}
