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

    }
}
