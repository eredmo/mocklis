// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FuncMethodMock_SetNextStep_should.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Core.Tests.Core
{
    #region Using Directives

    using System;
    using Mocklis.Core.Tests.Mocks;
    using Xunit;

    #endregion

    public class FuncMethodMock_SetNextStep_should
    {
        private readonly FuncMethodMock<string> _parameterLessFuncMock;
        private readonly FuncMethodMock<int, string> _funcMock;


        public FuncMethodMock_SetNextStep_should()
        {
            _parameterLessFuncMock = new FuncMethodMock<string>(new object(), "ClassName", "InterfaceName", "MemberName", "MockName");
            _funcMock = new FuncMethodMock<int, string>(new object(), "ClassName", "InterfaceName", "MemberName", "MockName");
        }

        [Fact]
        public void require_step()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                ((IMethodStepCaller<int, string>)_funcMock).SetNextStep((IMethodStep<int, string>)null));
            Assert.Equal("step", exception.ParamName);
        }

        [Fact]
        public void return_new_step()
        {
            var newStep = new MockMethodStep<int, string>();
            var returnedStep = ((IMethodStepCaller<int, string>)_funcMock).SetNextStep(newStep);
            Assert.Same(newStep, returnedStep);
        }

        [Fact(DisplayName = "set step used by call (parameterless)")]
        public void set_step_used_by_call_X28parameterlessX29()
        {
            bool called = false;
            var newStep = new MockMethodStep<ValueTuple, string>();

            newStep.Call.Func(_ =>
            {
                called = true;
                return string.Empty;
            });
            ((IMethodStepCaller<ValueTuple, string>)_parameterLessFuncMock).SetNextStep(newStep);
            _parameterLessFuncMock.Call();
            Assert.True(called);
        }

        [Fact]
        public void set_step_used_by_call()
        {
            bool called = false;
            var newStep = new MockMethodStep<int, string>();
            newStep.Call.Func(_ =>
            {
                called = true;
                return string.Empty;
            });
            ((IMethodStepCaller<int, string>)_funcMock).SetNextStep(newStep);
            _funcMock.Call(5);
            Assert.True(called);
        }
    }
}