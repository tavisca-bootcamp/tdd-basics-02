using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void DummyTest()
        {
            return;
        }
        [Fact]
        public void SingleDigitInput()
        {
            Calculator calc = new Calculator();
            char[] input = { '7', '+', '2', '=' };
            string result = null;
            foreach(char val in input)
            {
                result = calc.SendKeyPress(val);
            }

            Assert.Equal("9", result);
        }
        [Fact]
        public void DoubleDigitInput()
        {
            Calculator calc = new Calculator();
            char[] input = { '7', '2', '-', '1', '4', '=' };
            string result = null;
            foreach (char val in input)
            {
                result = calc.SendKeyPress(val);
            }

            Assert.Equal("58", result);
        }
        [Fact]
        public void DividedByZero()
        {
            Calculator calc = new Calculator();
            char[] input = { '7', '/', '0', '=' };
            string result = null;
            foreach (char val in input)
            {
                result = calc.SendKeyPress(val);
            }

            Assert.Equal("-E-", result);
        }
        [Fact]
        public void MultiplicationByZero()
        {
            Calculator calc = new Calculator();
            char[] input = { '7','7', '*', '0', '=' };
            string result = null;
            foreach (char val in input)
            {
                result = calc.SendKeyPress(val);
            }

            Assert.Equal("0", result);
        }
        [Fact]
        public void PrecedingZeros()
        {
            Calculator calc = new Calculator();
            char[] input = { '0', '0', '0' };
            string result = null;
            foreach (char val in input)
            {
                result = calc.SendKeyPress(val);
            }

            Assert.Equal("0", result);
        }
        [Fact]
        public void MultipleDecimal()
        {
            Calculator calc = new Calculator();
            char[] input = { '5', '.', '.' };
            string result = null;
            foreach (char val in input)
            {
                result = calc.SendKeyPress(val);
            }

            Assert.Equal("5.", result);
        }
        [Fact]
        public void GivenExample()
        {
            Calculator calc = new Calculator();
            char[] input = { '1', '+', '2', '+', '3','+', '=' };
            string result = null;
            foreach (char val in input)
            {
                result = calc.SendKeyPress(val);
            }

            Assert.Equal("12", result);
        }
        [Fact]
        public void CheckToggle()
        {
            Calculator calc = new Calculator();
            char[] input = { '1', '2', '+', '2', 's' };
            string result = null;
            foreach (char val in input)
            {
                result = calc.SendKeyPress(val);
            }

            Assert.Equal("-2", result);
        }

        [Fact]
        public void CheckReset()
        {
            Calculator calc = new Calculator();
            char[] input = { '1', '2', '+', '2', 'c' };
            string result = null;
            foreach (char val in input)
            {
                result = calc.SendKeyPress(val);
            }

            Assert.Equal("0", result);
        }

    }
}
