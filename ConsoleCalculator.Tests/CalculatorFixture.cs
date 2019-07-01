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
        
    }
}
