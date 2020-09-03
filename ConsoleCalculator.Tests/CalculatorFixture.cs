using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void SendKeyPress_addTwoNumbsers()
        {
            Calculator calc = new Calculator();

            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("10", calc.SendKeyPress('0'));
            Assert.Equal("10", calc.SendKeyPress('+'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("12", calc.SendKeyPress('='));

        }

        [Fact]
        public void SendKeyPress_subtractTwoNumbsers()
        {
            Calculator calc = new Calculator();
            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("10", calc.SendKeyPress('0'));
            Assert.Equal("10", calc.SendKeyPress('-'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("8", calc.SendKeyPress('='));
        }

        [Fact]
        public void SendKeyPress_multiplyTwoNumbsers()
        {
            Calculator calc = new Calculator();
            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("10", calc.SendKeyPress('0'));
            Assert.Equal("10", calc.SendKeyPress('x'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("20", calc.SendKeyPress('='));
        }

        [Fact]
        public void SendKeyPress_divideTwoNumbsers()
        {
            Calculator calc = new Calculator();
            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("10", calc.SendKeyPress('0'));
            Assert.Equal("10", calc.SendKeyPress('/'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("5", calc.SendKeyPress('='));
        }
        [Fact]
        public void SendKeyPress_changeSignAndDoOperation()
        {
            Calculator calc = new Calculator();

            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("10", calc.SendKeyPress('0'));
            Assert.Equal("-10", calc.SendKeyPress('s'));
            Assert.Equal("-10", calc.SendKeyPress('+'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("-8", calc.SendKeyPress('='));
        }



        [Fact]
        public void SendKeyPress_divideByZero()
        {
            Calculator calc = new Calculator();
            string expected = "-E-";

            calc.SendKeyPress('1');
            calc.SendKeyPress('0');
            calc.SendKeyPress('/');
            calc.SendKeyPress('0');
            string actual = calc.SendKeyPress('=');

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SendKeyPress_ignoreLeadingZeroes()
        {
            Calculator calc = new Calculator();

            Assert.Equal("0", calc.SendKeyPress('0'));
            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("10", calc.SendKeyPress('0'));
            Assert.Equal("10", calc.SendKeyPress('+'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("12", calc.SendKeyPress('='));
        }

        [Fact]
        public void SendKeyPress_multipleOperations()
        {
            Calculator calc = new Calculator();

            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("10", calc.SendKeyPress('0'));
            Assert.Equal("10", calc.SendKeyPress('+'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("12", calc.SendKeyPress('/'));
            Assert.Equal("4", calc.SendKeyPress('4'));
            Assert.Equal("3", calc.SendKeyPress('='));
        }



    }
}
