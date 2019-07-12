using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator calculator;

        [Fact]
        public void SingleInputTests()
        {
            string input1 = "2";
            string input2 = "12";
            string input3 = "10203";

            string evaluatedResult1 = EvaluateExpression(input1);
            string evaluatedResult2 = EvaluateExpression(input2);
            string evaluatedResult3 = EvaluateExpression(input3);

            Assert.Equal("2", evaluatedResult1);
            Assert.Equal("12", evaluatedResult2);
            Assert.Equal("10203", evaluatedResult3);
        }

        [Fact]
        public void OperatorPassTest()
        {
            string input1 = "123+";
            string input2 = "2x";

            string evaluatedResult1 = EvaluateExpression(input1);
            string evaluatedResult2 = EvaluateExpression(input2);

            Assert.Equal("123", evaluatedResult1);
            Assert.Equal("2", evaluatedResult2);
        }

        [Fact]
        public void InputAfterOperatorTest()
        {
            string input1 = "1+2";
            string input2 = "25/5";

            string evaluatedResult1 = EvaluateExpression(input1);
            string evaluatedResult2 = EvaluateExpression(input2);

            Assert.Equal("2", evaluatedResult1);
            Assert.Equal("5", evaluatedResult2);
        }

        [Fact]
        public void EqualsTest()
        {
            string input1 = "1+2=";
            string input2 = "25/5=";

            string evaluatedResult1 = EvaluateExpression(input1);
            string evaluatedResult2 = EvaluateExpression(input2);

            Assert.Equal("3", evaluatedResult1);
            Assert.Equal("5", evaluatedResult2);
        }

        public string EvaluateExpression(string input)
        {
            Calculator calculator = new Calculator();

            calculator.SendKeyPress('c');
            string evaluatedResult = "";

            foreach(char ch in input)
                evaluatedResult = calculator.SendKeyPress(ch);

            return evaluatedResult;
        }
    }
}
