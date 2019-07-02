using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator _calculator = null;

        public CalculatorFixture()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void SingleDigitDecimal()
        {
            _calculator.SendKeyPress('9');
            Assert.Equal("9", _calculator.ShowDisplayValue());
        }

        [Fact]
        public void MultipleDigitDecimal()
        {
            _calculator.SendKeyPress('7');
            _calculator.SendKeyPress('9');
            Assert.Equal("79", _calculator.ShowDisplayValue());
        }

    }
}
