// <auto-generated />

namespace Test
{
    partial class TestClass
    {
        public global::Mocklis.Core.IndexerMock<(int Item0, int Item2, int Item02, int Item_, int ItemTest), int> Item { get; }

        int global::Test.ITestClass.this[int Item0, int Item2, int Item02, int Item_, int ItemTest] { get => Item[(Item0, Item2, Item02, Item_, ItemTest)]; set => Item[(Item0, Item2, Item02, Item_, ItemTest)] = value; }

        public global::Mocklis.Core.IndexerMock<int, int> Item0 { get; }

        int global::Test.ITestClass.this[int Item0_] { get => Item0[Item0_]; set => Item0[Item0_] = value; }

        public TestClass() : base()
        {
            this.Item = new global::Mocklis.Core.IndexerMock<(int Item0, int Item2, int Item02, int Item_, int ItemTest), int>(this, "TestClass", "ITestClass", "this[]", "Item", global::Mocklis.Core.Strictness.Lenient);
            this.Item0 = new global::Mocklis.Core.IndexerMock<int, int>(this, "TestClass", "ITestClass", "this[]", "Item0", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
