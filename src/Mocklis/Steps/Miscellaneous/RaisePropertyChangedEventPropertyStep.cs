// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RaisePropertyChangedEventPropertyStep.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Steps.Miscellaneous
{
    #region Using Directives

    using System;
    using System.ComponentModel;
    using Mocklis.Core;
    using Mocklis.Verification;

    #endregion

    public class RaisePropertyChangedEventPropertyStep<TValue> : MedialPropertyStep<TValue>
    {
        private readonly IStoredEvent<PropertyChangedEventHandler> _propertyChangedEvent;

        public RaisePropertyChangedEventPropertyStep(IStoredEvent<PropertyChangedEventHandler> propertyChangedEvent)
        {
            _propertyChangedEvent = propertyChangedEvent ?? throw new ArgumentNullException(nameof(propertyChangedEvent));
        }

        public override void Set(object instance, MemberMock memberMock, TValue value)
        {
            base.Set(instance, memberMock, value);
            _propertyChangedEvent.EventHandler?.Invoke(instance, new PropertyChangedEventArgs(memberMock.MemberName));
        }
    }
}