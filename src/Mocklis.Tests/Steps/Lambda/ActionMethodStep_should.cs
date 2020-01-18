// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionMethodStep_should.cs">
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

    public class ActionMethodStep_should
    {
        public MockMembers MockMembers { get; } = new MockMembers();
        public IMethods Sut => MockMembers;

        [Fact]
        public void RequireNonNullAction()
        {
            Assert.Throws<ArgumentNullException>(() => MockMembers.SimpleAction.Action((Action)null!));
            Assert.Throws<ArgumentNullException>(() => MockMembers.ActionWithParameter.Action(null!));
        }

        [Fact]
        public void CallActionWithNoParameters()
        {
            bool isCalled = false;
            MockMembers.SimpleAction.Action(() => { isCalled = true; });

            Sut.SimpleAction();

            Assert.True(isCalled);
        }

        [Fact]
        public void CallActionWithParameters()
        {
            int callParameter = 0;
            MockMembers.ActionWithParameter.Action(i => callParameter = i);

            Sut.ActionWithParameter(99);

            Assert.Equal(99, callParameter);
        }
    }
}
