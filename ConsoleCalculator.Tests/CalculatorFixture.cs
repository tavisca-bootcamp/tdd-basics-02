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
    }
}
