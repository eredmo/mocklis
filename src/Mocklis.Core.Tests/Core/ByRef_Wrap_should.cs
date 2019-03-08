// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ByRef_Wrap_should.cs">
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Core.Tests.Core
{
    #region Using Directives

    using Xunit;

    #endregion

    public class ByRef_Wrap_should
    {
        [Fact]
        public void create_new_reference_with_passed_value()
        {
            ref var wrapped = ref ByRef<int>.Wrap(15);
            Assert.Equal(15, wrapped);
        }
    }
}