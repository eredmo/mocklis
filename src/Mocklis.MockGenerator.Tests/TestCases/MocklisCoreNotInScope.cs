using System;

namespace Test
{
    public interface ITest
    {
        void DoStuff(string stuff);
    }

    [Mocklis.Core.MocklisClass]
    public [PARTIAL] class TestClass : ITest
    {
    }
}
