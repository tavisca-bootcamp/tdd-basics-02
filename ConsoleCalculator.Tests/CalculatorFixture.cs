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
        public void ToggleSignTest()
        {
            string expression1 = "10+2s=";
            string expression2 = "3+2ss=";

            string evaluatedResult1 = EvaluateExpression(expression1);
            string evaluatedResult2 = EvaluateExpression(expression2);

            Assert.Equal("8", evaluatedResult1);
            Assert.Equal("5", evaluatedResult2);
        }

        [Fact]
        public void ClearSignTest()
        {
            string expression1 = "1+2xC=";
            string expression2 = "1/0c=";

            string evaluatedResult1 = EvaluateExpression(expression1);
            string evaluatedResult2 = EvaluateExpression(expression2);

            Assert.Equal("0", evaluatedResult1);
            Assert.Equal("0", evaluatedResult2);
        }

        [Fact]
        public void ErrorStateTest()
        {
            string expression1 = "10/0=";
            string expression2 = "0/0=";

            string evaluatedResult1 = EvaluateExpression(expression1);
            string evaluatedResult2 = EvaluateExpression(expression2);

            Assert.Equal("-E-", evaluatedResult1);
            Assert.Equal("-E-", evaluatedResult2);
        }

        [Fact]
        public void MultipleperatorsTest()
        {
            string expression1 = "1+2-1x3/3=";

            string evaluatedResult1 = EvaluateExpression(expression1);

            Assert.Equal("2", evaluatedResult1);
        }

        public string EvaluateExpression(string exp)
        {
            calculator.SendKeyPress('c');
            string evaluatedResult = null ;

            foreach (char ch in exp)
            {
                evaluatedResult = calculator.SendKeyPress(ch);
            }
            return evaluatedResult;
        }
    }
}
