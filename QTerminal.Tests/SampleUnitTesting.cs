using System;
using QTerminal;
using Xunit;

namespace QTerminal.Tests
{
    public class SampleUnitTesting
    {
        [Fact]
        public void SampleFact()
        {
            double expected = 3+7;
            double actual = 3+7;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4,3,(4+3))]
        [InlineData(14,5,(14+5))]
        [InlineData(double.MaxValue, 5, double.MaxValue)]
        public void SampleTheory(double x, double y, double expected)
        {
            double actual = x+y;

            Assert.Equal(expected, actual);
        }
    }
}
