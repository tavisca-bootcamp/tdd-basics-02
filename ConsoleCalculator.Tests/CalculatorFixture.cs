using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void DummyTest()
        {
            string expected = "6";
            string actual = "";
            Calculator calculator = new Calculator();
            actual = calculator.SendKeyPress('2');
            actual = calculator.SendKeyPress('x');
            actual = calculator.SendKeyPress('3');
            actual = calculator.SendKeyPress('=');

            Assert.Equal(expected, actual);
        }
    }
}
