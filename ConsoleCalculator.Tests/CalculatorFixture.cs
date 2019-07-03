using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void TestAddition()
        {
            string expression = "10+2trf=";
            string actual = GetResult(expression);
            Assert.Equal("12", actual);
        }
        [Fact]
        public void TestMultipleZero()
        {
            string expression = "10+000000....10.";
            string actual = GetResult(expression);
            Assert.Equal("0.10", actual);
        }
        [Fact]
        public void TestDivideByZero()
        {
            string expression = "12/0.0=";
            string actual = GetResult(expression);
            Assert.Equal("-E-", actual);
        }
        [Fact]
        public void TestClearHistory()
        {
            string expression = "1+2+C";
            string actual = GetResult(expression);
            Assert.Equal("0", actual);
        }
        [Fact]
        public void TestToggleSIgn()
        {
            string expression = "100sss-90s=";
            string actual = GetResult(expression);
            Assert.Equal("-10", actual);
        }

        public string GetResult(string expression)
        {
            Calculator calculatorObj = new Calculator();
            string result = "";
            foreach(char key in expression)
            {
                result = calculatorObj.SendKeyPress(key);
            }
            return result;
        }
    }
}
