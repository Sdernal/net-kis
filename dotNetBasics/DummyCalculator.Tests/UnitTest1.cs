using System;
using Xunit;

namespace DummyCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Test_Sum()
        {
            int a = 5;
            int b = 6;
            Calculator calculator = new Calculator();
            Assert.Equal(11, calculator.Sum(a, b));
        }

        [Theory]
        [InlineData(3.0, 4.0, 7.0)]
        [InlineData(1.0, 1.0, 2.0)]
        public void Test_SumTheory(double a, double b, double expected)
        {
            Calculator calculator = new Calculator();
            Assert.Equal(expected, calculator.Sum(a, b));
        }
    }
}
