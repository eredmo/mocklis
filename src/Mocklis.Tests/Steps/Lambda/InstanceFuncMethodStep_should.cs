// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceFuncMethodStep_should.cs">
//   SPDX-License-Identifier: MIT
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Tests.Steps.Lambda
{
    #region Using Directives

    using System;
    using Mocklis.Tests.Interfaces;
    using Mocklis.Tests.Mocks;
    using Xunit;

    #endregion

    public class InstanceFuncMethodStep_should
    {
        public MockMembers MockMembers { get; } = new MockMembers();
        public IMethods Sut => MockMembers;

        [Fact]
        public void RequireNonNullAction()
        {
            Assert.Throws<ArgumentNullException>(() => MockMembers.SimpleFunc.InstanceFunc((Func<object, int>)null!));
            Assert.Throws<ArgumentNullException>(() => MockMembers.FuncWithParameter.InstanceFunc(null!));
        }

        [Fact]
        public void CallFuncWithNoParameters()
        {
            object? callInstance = null;
            MockMembers.SimpleFunc.InstanceFunc(obj =>
            {
                callInstance = obj;
                return 42;
            });

            var result = Sut.SimpleFunc();

            Assert.Same(Sut, callInstance);
            Assert.Equal(42, result);
        }

        [Fact]
        public void CallFuncWithParameters()
        {
            object? callInstance = null;
            int callParameter = 0;
            MockMembers.FuncWithParameter.InstanceFunc((obj, i) =>
            {
                callInstance = obj;
                callParameter = i;
                return 42;
            });

            var result = Sut.FuncWithParameter(99);

            Assert.Same(Sut, callInstance);
            Assert.Equal(99, callParameter);
            Assert.Equal(42, result);
        }
    }
}
