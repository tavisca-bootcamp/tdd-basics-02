using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator c = new Calculator();
        [Fact]
        public void ignoreunwantedchar()
        {
            Assert.Equal("0", c.SendKeyPress('d'));
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("1", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("3", c.SendKeyPress('='));
        }
    }
}
