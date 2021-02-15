using System;
using Xunit;
using ConsoleCalculator;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void Addition()
        {
            string expected = "14";
            Assert.Equal(Calculator("10+4="), expected);
        }

        [Fact]
        public void Subtraction()
        {
            String expected = "3";
            Assert.Equal(Calculator("10-7="), expected);
        }

        [Fact]
        public void DivideByZero()
        {
            string expected = "-E-";
            Assert.Equal(Calculator("10/0="), expected);
            return;
        }

        [Fact]
        private void DummyTest()
        { 
            return;
        }

        [Fact]
        public void DecimalTest()
        {
            string expected = "0.001";
            Assert.Equal(Calculator("00..001"), expected);
            return;
        }
        private string Calculator(string input)
        {
            Calculator calc = new Calculator();
            string result = calc.Calculate(input);
            return result;
        }
    }
}
