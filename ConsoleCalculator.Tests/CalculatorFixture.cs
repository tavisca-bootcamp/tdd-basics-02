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

        private string SendMultipleKey(char[] key)
        {
            int i;
            for (i = 0; i < key.Length - 1; i++)
                calculator.SendKeyPress(key[i]);
            return calculator.SendKeyPress(key[i]);
        }

        [Fact]
        public void SingleKeyPressTest()
        {
            char key = '5';
            var result = calculator.SendKeyPress(key);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestingSimpleOperandsOperation()
        {
            char[] key = { '1', '2', '+', '3', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("15", result);
        }

        [Fact]
        public void DivByZeroTest()
        {
            char[] key = { '1', '2', '/', '0', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("-E-", result);
        }

        [Fact]
        public void MultipleZeroesAndDecimalTest()
        {
            char[] key = { '0', '0', '.', '.', '0', '0', '1' };
            var result = SendMultipleKey(key);
            Assert.Equal("0.001", result);
        }

    }
}
