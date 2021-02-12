using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void TestForAddition()
        {
            string expression = "10+2=";
            Assert.Equal("12", Calculate(expression));
        }
        [Fact]
        public void TestForDivideError()
        {
            string expression = "10/0=";
            Assert.Equal("-E-", Calculate(expression));
        }
        [Fact]
        public void TestZeros()
        {
            string expression = "0000000";
            Assert.Equal("0", Calculate(expression));
        }
        [Fact]
        public void TestForDecimalZeros()
        {
            string expression = "00..001";
            Assert.Equal("0.001", Calculate(expression));
        }
        [Fact]
        public void TestForSignToggle()
        {
            string expression = "12+2sss=";
            Assert.Equal("10", Calculate(expression));
        }
        [Fact]
        public void TestForNormalOperation()
        {
            string expression = "1+2+3+=";
            Assert.Equal("12", Calculate(expression));
        }
        [Fact]
        public void TestForDecimalOperation()
        {
            string expression = "00..12+000...12=";
            Assert.Equal("0.24", Calculate(expression));
        }
        [Fact]
        public void TestForReset()
        {
            string expression = "1+2+C";
            Assert.Equal("0", Calculate(expression));
        }
        private string Calculate(string expression)
        {
            Calculator calculator = new Calculator();
            string result = string.Empty;
            foreach (var item in expression)
            {
                result = calculator.SendKeyPress(item);
            }
            calculator.ResetAll();
            return result;
        }
    }
}
