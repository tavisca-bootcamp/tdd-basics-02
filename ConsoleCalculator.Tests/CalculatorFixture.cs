using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator calculator;
        public CalculatorFixture()
        {
            calculator = new Calculator();
        }

        [Fact]
        public void SingleKeyPressTest()
        {
            char key = '5';
            var result = calculator.SendKeyPress(key);
            Assert.NotEmpty(result);
        }
    }
}
