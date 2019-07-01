using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator c = new Calculator();
        [Fact]
        public void IgnoreUnwantedChar()
        {
            Assert.Equal("0", c.SendKeyPress('d'));
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("1", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("3", c.SendKeyPress('='));
        }
        [Fact]
        public void IgnoreUnwantedChar1()
        {
            
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("1", c.SendKeyPress('d'));
            Assert.Equal("1", c.SendKeyPress('/'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("0.5", c.SendKeyPress('='));
        }
        [Fact]
        public void MultipleDigitsAndOperations()
        {

            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("10", c.SendKeyPress('0'));
            Assert.Equal("10", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("12", c.SendKeyPress('-'));
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("10", c.SendKeyPress('0'));
            Assert.Equal("2", c.SendKeyPress('='));
        }
        [Fact]
        public void MultipleDecimalsAndZeros()
        {
            Assert.Equal("0", c.SendKeyPress('0'));
            Assert.Equal("0", c.SendKeyPress('0'));
            Assert.Equal("0.", c.SendKeyPress('.'));
            Assert.Equal("0.", c.SendKeyPress('.'));
            Assert.Equal("0.0", c.SendKeyPress('0'));
            Assert.Equal("0.00", c.SendKeyPress('0'));
            Assert.Equal("0.001", c.SendKeyPress('1'));   
        }
        [Fact]
        public void decimaloperations()
        {
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("2", c.SendKeyPress('/'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("1", c.SendKeyPress('/'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("0.5", c.SendKeyPress('+'));
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("1.5", c.SendKeyPress('-'));
            Assert.Equal("0", c.SendKeyPress('0'));
            Assert.Equal("0.", c.SendKeyPress('.'));
            Assert.Equal("0.0", c.SendKeyPress('0'));
            Assert.Equal("0.01", c.SendKeyPress('1'));
            Assert.Equal("1.49", c.SendKeyPress('='));
        }
        [Fact]
        public void ToggleAndClear()
        {

            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("10", c.SendKeyPress('0'));
            Assert.Equal("10", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("-2", c.SendKeyPress('s'));
            Assert.Equal("2", c.SendKeyPress('S'));
            Assert.Equal("12", c.SendKeyPress('-'));
            Assert.Equal("0", c.SendKeyPress('c'));
        }
        [Fact]
        public void decimalOperations1()
        {

            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("1", c.SendKeyPress('d'));
            Assert.Equal("1", c.SendKeyPress('/'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("0.5", c.SendKeyPress('x'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("1", c.SendKeyPress('='));
        }
        [Fact]
        public void EqualFollowedOperator()
        {
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("1", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("3", c.SendKeyPress('+'));
            Assert.Equal("3", c.SendKeyPress('3'));
            Assert.Equal("6", c.SendKeyPress('+'));
            Assert.Equal("12", c.SendKeyPress('='));
        }

    }
}
