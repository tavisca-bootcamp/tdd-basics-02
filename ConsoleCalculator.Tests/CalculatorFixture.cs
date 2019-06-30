using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void TestOne()
        {
            var calculator = new Calculator();
            var expression = new char[]{ '1', '0', '+', '2', '=' };
            var expected = new string[]{ "1", "10", "10", "2", "12" };
            int length = expression.Length;
            var actual = new string[length];
            for (int i = 0; i < length; i++)
                actual[i] = calculator.SendKeyPress(expression[i]);
            Assert.Equal(expected, actual);
            
        }
    }
}
