using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calc = new Calculator();

        [Fact]
        public void SimpleAddition()
        {
            Assert.Equal("1",calc.SendKeyPress('1'));
            Assert.Equal("10",calc.SendKeyPress('0'));
            Assert.Equal("10",calc.SendKeyPress('+'));
            Assert.Equal("2",calc.SendKeyPress('2'));
            Assert.Equal("12",calc.SendKeyPress('='));
        }

        [Fact]
        public void DivideByZero()
        {
            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("10", calc.SendKeyPress('0'));
            Assert.Equal("10", calc.SendKeyPress('/'));
            Assert.Equal("0", calc.SendKeyPress('0'));
            Assert.Equal("-E-", calc.SendKeyPress('='));
        }

        [Fact]
        public void TestForDecimal()
        {
            Assert.Equal("0", calc.SendKeyPress('0'));
            Assert.Equal("0", calc.SendKeyPress('0'));
            Assert.Equal("0.", calc.SendKeyPress('.'));
            Assert.Equal("0.", calc.SendKeyPress('.'));
            Assert.Equal("0.0", calc.SendKeyPress('0'));
            Assert.Equal("0.00", calc.SendKeyPress('0'));
            Assert.Equal("0.001", calc.SendKeyPress('1'));
        }

        [Fact]
        public void MultipleOperands()
        {
            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("1", calc.SendKeyPress('+'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("3", calc.SendKeyPress('+'));
            Assert.Equal("3", calc.SendKeyPress('3'));
            Assert.Equal("6", calc.SendKeyPress('+'));
            Assert.Equal("12", calc.SendKeyPress('='));
        }

        [Fact]
        public void TestForSignToggle()
        {
            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("12", calc.SendKeyPress('2'));
            Assert.Equal("12", calc.SendKeyPress('+'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("-2", calc.SendKeyPress('S'));
            Assert.Equal("2", calc.SendKeyPress('S'));
            Assert.Equal("-2", calc.SendKeyPress('S'));
            Assert.Equal("10", calc.SendKeyPress('='));
        }

        [Fact]
        public void TestForC()
        {
            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("1", calc.SendKeyPress('+'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("3", calc.SendKeyPress('+'));
            Assert.Equal("0", calc.SendKeyPress('C'));
        }

        [Fact]
        public void TestForDecimalMultiplication()
        {
            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("12", calc.SendKeyPress('2'));
            Assert.Equal("12.", calc.SendKeyPress('.'));
            Assert.Equal("12.2", calc.SendKeyPress('2'));
            Assert.Equal("12.25", calc.SendKeyPress('5'));
            Assert.Equal("12.25", calc.SendKeyPress('x'));
            Assert.Equal("-", calc.SendKeyPress('-'));
            Assert.Equal("-3", calc.SendKeyPress('3'));
            Assert.Equal("-3.", calc.SendKeyPress('.'));
            Assert.Equal("-3.5", calc.SendKeyPress('5'));
            Assert.Equal("-42.875", calc.SendKeyPress('='));
        }
    }
}
