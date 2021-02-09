using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Theory]
        [InlineData("10+2=","12")]
        //[InlineData("1.7976931348623157E+308", "1.7976931348623157E+308")]
        public void Addition(string input,string expected)
        {
            Assert.Equal(Calculator(input), expected);
            return;
        }

        [Fact]
        public void Subtraction()
        {
            String expected = "3";
            Assert.Equal(Calculator("10-7="), expected);
            return;
        }

        [Fact]
        public void DivideByZero()
        {
            string expected = "-E-";
            Assert.Equal(Calculator("10/0="), expected);
            return;
        }
        [Theory]
        [InlineData("12+2S=")]
        [InlineData("12+2s=")]
        public void SKeyTest(string input)
        {
            string expected = "10";
            Assert.Equal(Calculator(input), expected);
            return;
        }

        [Fact]
        public void DecimalTest()
        {
            string expected = "0.001";
            Assert.Equal(Calculator("00..001"), expected);
            return;
        }

        [Theory]
        [InlineData("1+2+C")]
        [InlineData("1+2+c")]
        public void CKeyTest(string input)
        {
            string expected = "0";
            Assert.Equal(Calculator(input), expected);
            return;
        }

        [Theory]
        [InlineData("13x15=")]
        [InlineData("13X15=")]
        public void MultiplicationTest(string input)
        {
            string expected = "195";
            Assert.Equal(Calculator(input), expected);
            return;
        }

        [Theory]
        [InlineData("5/2=","2.5")]
        [InlineData("5/3=", "1.666667")]
        public void DivisionTest(string input,string expected)
        {
            Assert.Equal(Calculator(input), expected);
            return;
        }

        [Fact]
        public void RepeatingEquals()
        {
            string expected = "5";
            Assert.Equal(Calculator("5/2=x2="), expected);
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
