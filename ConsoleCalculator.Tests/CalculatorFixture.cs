using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void DummyTest()
        {
            return;
        }
        [Fact]
        public void TestCalculateSimpleAddition()
        {
            string exp = "10+2=";
            string expexted = "12";
            Assert.Equal(expexted, EvaluateExpression(exp));
        }
        [Fact]
        public void TestDivisibleByZero()
        {
            string exp = "10/0=";
            string expexted = "-E-";
            Assert.Equal(expexted, EvaluateExpression(exp));
        }
        [Fact]
        public void TestMultipleZeros()
        {
            string exp = "0000";
            string expexted = "0";
            Assert.Equal(expexted, EvaluateExpression(exp));
        }
        [Fact]
        public void TestMultipleDecimals()
        {
            string exp = "00..001";
            string expexted = "0.001";
            Assert.Equal(expexted, EvaluateExpression(exp));
        }
        [Fact]
        public void TestAddMultipleDecimals()
        {
            string exp = "2..5+7..5=";
            string expexted = "10";
            Assert.Equal(expexted, EvaluateExpression(exp));
        }

        [Fact]
        public void TestForClearScreen()
        {
            string exp = "1+2+C";
            string expected = "0";
            Assert.Equal(expected, EvaluateExpression(exp));
        }
        private string EvaluateExpression(string exp)
        {
            Calculator calculate = new Calculator();
            var result = string.Empty;
            foreach (char character in exp)
            {
                result = calculate.SendKeyPress(character);
            }
            return result;
        }
    }
}
