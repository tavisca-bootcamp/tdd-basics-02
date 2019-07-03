using System;
using Xunit;
using ConsoleCalculator;
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
            var i = 0;
            for (i = 0; i < key.Length - 1; i++)
                calculator.SendKeyPress(key[i]);
            return calculator.SendKeyPress(key[i]);
        }



        [Fact]
        public void SingleKeyPressTest()
        {
            //simplest test case
            char key = '5';

            var result = calculator.SendKeyPress(key);

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestConsideringOnlyTwoOperandsForAddOperator()
        {
            char[] key = { '1', '.', '2', '+', '3', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("4.2", result);
        }

        [Fact]
        public void DivByZeroForTwoOperands()
        {
            char[] key = { '1', '2', '/', '0', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("-E-", result);
        }

        [Fact]
        public void DoubleDivisionForTwoOperands()
        {
            char[] key = { '1', '.', '2', '/', '3', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("0.4", result);
        }

        [Fact]
        public void DoubleDecimalTwoOperands()
        {
            char[] key = { '1', '.', '.', '2', '/', '3', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("0.4", result);
        }

        [Fact]
        public void SignInversionTest()
        {
            char[] key = { '1', '2', '/', '2', 's', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("-6", result);
        }

        [Fact]
        public void MultipleZeroesAndDecimalTest()
        {
            char[] key = { '0', '0', '.', '.', '2', '/', '2', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("0.1", result);
        }

        [Fact]
        public void PressingClearTest()
        {
            char[] key = { '0', '0', '.', '.', 'C', '1', '2', '/', '2', 's', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("-6", result);
        }

        [Fact]
        public void FirstTest()
        {
            char[] key = { '1', '0', '+', '2', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("12", result);
        }

        [Fact]
        public void SecondTest()
        {
            char[] key = { '1', '0', '/', '0', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("-E-", result);
        }
        [Fact]
        public void ThirdTest()
        {
            char[] key = { '0', '0', '.', '.', '0', '0', '1' };
            var result = SendMultipleKey(key);
            Assert.Equal("0.001", result);
        }


        [Fact]
        public void FourthTest()
        {
            char[] key = { '1', '2', '+', '2', 'S', 'S', 'S', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("10", result);
        }

        [Fact]
        public void FifthTest()
        {
            char[] key = { '1', '+', '2', '+', '3', '+', '6', '=' };
            var result = SendMultipleKey(key);
            Assert.Equal("12", result);
        }

        [Fact]
        public void SixthTest()
        {
            char[] key = { '1', '+', '2', '+', '3', 'C' };
            var result = SendMultipleKey(key);
            Assert.Equal("0", result);
        }





    }
}
