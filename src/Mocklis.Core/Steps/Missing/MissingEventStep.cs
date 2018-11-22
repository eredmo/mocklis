// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissingEventStep.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Steps.Missing
{
    #region Using Directives

    using System;
    using Mocklis.Core;

    #endregion

    public sealed class MissingEventStep<THandler> : IEventStep<THandler> where THandler : Delegate
    {
        public static readonly MissingEventStep<THandler> Instance = new MissingEventStep<THandler>();

        private MissingEventStep()
        {
        }

        public void Add(object instance, MemberMock memberMock, THandler value)
        {
            throw new MockMissingException(MockType.EventAdd, memberMock);
        }

        public void Remove(object instance, MemberMock memberMock, THandler value)
        {
            throw new MockMissingException(MockType.EventRemove, memberMock);
        }
    }
}