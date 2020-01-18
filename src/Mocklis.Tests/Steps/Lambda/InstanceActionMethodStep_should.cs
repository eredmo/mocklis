// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceActionMethodStep_should.cs">
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

    public class InstanceActionMethodStep_should
    {
        public MockMembers MockMembers { get; } = new MockMembers();
        public IMethods Sut => MockMembers;

        [Fact]
        public void RequireNonNullAction()
        {
            Assert.Throws<ArgumentNullException>(() => MockMembers.SimpleAction.InstanceAction((Action<object>)null!));
            Assert.Throws<ArgumentNullException>(() => MockMembers.ActionWithParameter.InstanceAction(null!));
        }

        [Fact]
        public void CallActionWithNoParameters()
        {
            object? callInstance = null;
            MockMembers.SimpleAction.InstanceAction(obj => { callInstance = obj; });

            Sut.SimpleAction();

            Assert.Same(Sut, callInstance);
        }

        [Fact]
        public void CallActionWithParameters()
        {
            object? callInstance = null;
            int callParameter = 0;
            MockMembers.ActionWithParameter.InstanceAction((obj, i) =>
            {
                callInstance = obj;
                callParameter = i;
            });

            Sut.ActionWithParameter(99);

            Assert.Same(Sut, callInstance);
            Assert.Equal(99, callParameter);
        }
    }
}
