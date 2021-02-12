using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void SimpleAdditionTest()
        {
            string expression = "10+2=";
            string result = Calculate(expression);

            Assert.Equal("12", result);
        }

        [Fact]
        public void SimpleSubtractionTest()
        {
            string expression = "10-2=";
            string result = Calculate(expression);

            Assert.Equal("8", result);
        }

        [Fact]
        public void SimpleMultiplicationTest()
        {
            string expression = "10x2=";
            string result = Calculate(expression);

            Assert.Equal("20", result);
        }

        [Fact]
        public void SimpleDivisionTest()
        {
            string expression = "10/2=";
            string result = Calculate(expression);

            Assert.Equal("5", result);
        }

        [Fact]
        public void DivideByZeroTest()
        {
            string expression = "10/0=";
            string result = Calculate(expression);

            Assert.Equal("-E-", result);
        }

        [Fact]
        public void MultipleZeroTest()
        {
            string expr = "00..001";
            string result = Calculate(expr);

            Assert.Equal("0.001", result);
        }

        [Fact]
        public void SignToggleTest()
        {
            string expression = "12+2SSS=";
            string result = Calculate(expression);

            Assert.Equal("10", result);
        }

        [Fact]
        public void MultipleAdditionTest()
        {
            string expression = "1+2+3+=";
            string result = Calculate(expression);

            Assert.Equal("12", result);
        }

        [Fact]
        public void ClearTest()
        {
            string expression = "1+2+C";
            string result = Calculate(expression);

            Assert.Equal("0", result);
        }
  
        private string Calculate(string expression)
        {
            string result = "";
            Calculator calculator = new Calculator();
            foreach (char c in expression)
            {
                result = calculator.SendKeyPress(c);
            }
            return result;
        }

    }
}