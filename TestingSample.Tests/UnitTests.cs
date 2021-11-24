using System;
using TestingSample.Web.BusinessLogic;
using Xunit;
using Xunit.Abstractions;

namespace TestingSample.Tests
{
    public class UnitTests
    {
        private readonly ITestOutputHelper _output;

        public UnitTests(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void CheckAdditionCalc()
        {
            _output.WriteLine("Performing CheckCalcTest");

            var calculations = new Calculations();
            int result = calculations.AddInts(2, 3);

            Assert.Equal(5, result);

        }
    }
}