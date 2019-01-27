using System;
using Mocklis.Core;

namespace Test
{
    public interface ITestClass
    {
        int this[int i] { get; set; }
        int this[string s] { set; }
        int this[char c] { get; }
    }

    [MocklisClass]
    public class TestClass : ITestClass
    {
        public TestClass()
        {
            Item = new IndexerMock<int, int>(this, "TestClass", "ITestClass", "this[]", "Item");
            Item0 = new IndexerMock<string, int>(this, "TestClass", "ITestClass", "this[]", "Item0");
            Item1 = new IndexerMock<char, int>(this, "TestClass", "ITestClass", "this[]", "Item1");
        }

        public IndexerMock<int, int> Item { get; }

        int ITestClass.this[int i] { get => Item[i]; set => Item[i] = value; }

        public IndexerMock<string, int> Item0 { get; }

        int ITestClass.this[string s] { set => Item0[s] = value; }

        public IndexerMock<char, int> Item1 { get; }

        int ITestClass.this[char c] => Item1[c];
    }
}
