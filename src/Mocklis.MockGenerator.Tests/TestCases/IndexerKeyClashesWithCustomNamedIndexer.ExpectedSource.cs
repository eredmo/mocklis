// <auto-generated />

namespace Test
{
    partial class TestClass
    {
        public global::Mocklis.Core.IndexerMock<int, int> TheIndexerName { get; }

        int global::Test.ITestClass.this[int TheIndexerName_] { get => TheIndexerName[TheIndexerName_]; set => TheIndexerName[TheIndexerName_] = value; }

        public global::Mocklis.Core.IndexerMock<(int TheIndexerName, int OtherItem), int> TheIndexerName0 { get; }

        int global::Test.ITestClass.this[int TheIndexerName, int OtherItem] { get => TheIndexerName0[(TheIndexerName, OtherItem)]; set => TheIndexerName0[(TheIndexerName, OtherItem)] = value; }

        public TestClass() : base()
        {
            this.TheIndexerName = new global::Mocklis.Core.IndexerMock<int, int>(this, "TestClass", "ITestClass", "this[]", "TheIndexerName", global::Mocklis.Core.Strictness.Lenient);
            this.TheIndexerName0 = new global::Mocklis.Core.IndexerMock<(int TheIndexerName, int OtherItem), int>(this, "TestClass", "ITestClass", "this[]", "TheIndexerName0", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
