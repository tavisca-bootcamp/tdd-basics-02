using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator cal = new Calculator();

        [Fact]
        public void TestOperand()
        {
            Assert.Equal("0", cal.SendKeyPress('0'));
            Assert.Equal("0", cal.SendKeyPress('0'));
            Assert.Equal("0.", cal.SendKeyPress('.')); 
            Assert.Equal("0.", cal.SendKeyPress('.'));
            Assert.Equal("0.0", cal.SendKeyPress('0'));
            Assert.Equal("0.02", cal.SendKeyPress('2'));
        }

        [Fact]
        public void TestAddition()
        {
            Assert.Equal("1", cal.SendKeyPress('1'));
            Assert.Equal("1", cal.SendKeyPress('+'));
            Assert.Equal("2", cal.SendKeyPress('2'));
            Assert.Equal("3", cal.SendKeyPress('+'));
            
        }
        [Fact]
        public void TestAllOperators()
        {
            Assert.Equal("1", cal.SendKeyPress('1'));
            Assert.Equal("1", cal.SendKeyPress('+'));
            Assert.Equal("2", cal.SendKeyPress('2'));
            Assert.Equal("3", cal.SendKeyPress('x'));
            Assert.Equal("2", cal.SendKeyPress('2'));
            Assert.Equal("6", cal.SendKeyPress('-'));
            Assert.Equal("5", cal.SendKeyPress('5'));
            Assert.Equal("1", cal.SendKeyPress('/'));

        }
        [Fact]
        public void TestToggle()
        {
            Assert.Equal("1", cal.SendKeyPress('1'));
            Assert.Equal("12", cal.SendKeyPress('2'));
            Assert.Equal("12", cal.SendKeyPress('+'));
            Assert.Equal("2", cal.SendKeyPress('2'));
            Assert.Equal("-2", cal.SendKeyPress('s'));
            Assert.Equal("2", cal.SendKeyPress('S'));
            Assert.Equal("14", cal.SendKeyPress('='));
        }


    }
}
