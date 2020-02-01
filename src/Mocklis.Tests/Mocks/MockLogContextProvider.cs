// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockLogContextProvider.cs">
//   SPDX-License-Identifier: MIT
//   Copyright © 2019-2020 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Tests.Mocks
{
    #region Using Directives

    using Mocklis.Core;
    using Mocklis.Steps.Log;

    #endregion

    [MocklisClass]
    public class MockLogContextProvider : ILogContextProvider
    {
        // The contents of this class were created by the Mocklis code-generator.
        // Any changes you make will be overwritten if the contents are re-generated.

        public MockLogContextProvider()
        {
            LogContext = new PropertyMock<ILogContext>(this, "MockLogContextProvider", "ILogContextProvider", "LogContext", "LogContext", Strictness.Lenient);
        }

        public PropertyMock<ILogContext> LogContext { get; }

        ILogContext ILogContextProvider.LogContext => LogContext.Value;
    }
}
