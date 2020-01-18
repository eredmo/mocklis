// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceRemoveActionEventStep.cs">
//   SPDX-License-Identifier: MIT
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Steps.Lambda
{
    #region Using Directives

    using System;
    using Mocklis.Core;

    #endregion

    /// <summary>
    ///     Class that represents a 'RemoveAction' event step, where the action receives a reference to the mock instance.
    ///     Inherits from the <see cref="EventStepWithNext{THandler}" /> class.
    /// </summary>
    /// <typeparam name="THandler">The event handler type for the event.</typeparam>
    /// <seealso cref="EventStepWithNext{THandler}" />
    public class InstanceRemoveActionEventStep<THandler> : EventStepWithNext<THandler> where THandler : Delegate
    {
        private readonly Action<object, THandler?> _action;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RemoveActionEventStep{THandler}" /> class.
        /// </summary>
        /// <param name="action">An action to be invoked when an event handler is removed.</param>
        public InstanceRemoveActionEventStep(Action<object, THandler?> action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        /// <summary>
        ///     Called when an event handler is being removed from the mocked event.
        ///     This implementation invokes the action with the mocked instance and the event handler.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the event handler is being removed.</param>
        /// <param name="value">The event handler that is being removed.</param>
        public override void Remove(IMockInfo mockInfo, THandler? value)
        {
            _action(mockInfo.MockInstance, value);
        }
    }
}
