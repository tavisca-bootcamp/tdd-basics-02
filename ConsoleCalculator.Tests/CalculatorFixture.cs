using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator = new Calculator();

        [Fact]
        public void AddTwoNumbers()
        {
            string result = GetResultForGivenExpression("10+2=");
            Assert.Equal("12", result);
        }

        [Fact]
        public void SubtractTwoNumbers()
        {
            string result = GetResultForGivenExpression("10-2=");
            Assert.Equal("8", result);
        }

        [Fact]
        public void MultiplyTwoNumbersUsingUpperCaseX()
        {
            string result = GetResultForGivenExpression("10X2=");
            Assert.Equal("20", result);
        }

        [Fact]
        public void MultiplyTwoNumbersUsingLowerCaseX()
        {
            string result = GetResultForGivenExpression("10x2=");
            Assert.Equal("20", result);
        }

        [Fact]
        public void DivideTwoNumbers()
        {
            string result = GetResultForGivenExpression("10/2=");
            Assert.Equal("5", result);
        }

        [Fact]
        public void DivideByZero()
        {
            string result = GetResultForGivenExpression("10/0=");
            Assert.Equal("-E-", result);
        }

        [Fact]
        public void FloatingPointDivision()
        {
            string result = GetResultForGivenExpression("10/3=");
            Assert.Equal("3.333333", result);
        }

        [Fact]
        public void SignChange()
        {
            string result = GetResultForGivenExpression("10s");
            Assert.Equal("-10", result);
        }

        [Fact]
        public void ClearScreen()
        {
            string result = GetResultForGivenExpression("1+2+C");
            Assert.Equal("0", result);
        }

        [Fact]
        public void MultipleZerosBeforeDecimalPoint()
        {
            string result = GetResultForGivenExpression("00.001");
            Assert.Equal("0.001", result);
        }



        private string GetResultForGivenExpression(string expression)
        {
            string result = "";
            foreach (char key in expression)
            {
                result = calculator.SendKeyPress(key);
            }
            return result;
        }
    }
}
