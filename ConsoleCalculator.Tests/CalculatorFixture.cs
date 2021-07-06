using System;
using Xunit;
using ConsoleCalculator;
namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator = new Calculator();
        
        [Fact]
        public void TestIntegersWithoutOperation()
        {
            string expression = "12";
            string expected = "12";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestWithAdditionOperator()
        {
            string expression = "10+";
            string expected = "10";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestExpressionWhenFirstNumberIsNegative()
        {
            string expression = "10s+5=";
            string expected = "-5";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestExpressionWhenSecondNumberIsNegative()
        {
            string expression = "10+5s=";
            string expected = "5";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestAdditionOperation()
        {
            string expression = "10+20=";
            string expected = "30";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestDivsionOperation()
        {
            string expression = "10/20=";
            string expected = "0.5";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestWithCapitalS()
        {
            string expression = "2S";
            string expected = "-2";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestWithSmallS()
        {
            string expression = "2s";
            string expected = "-2";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestDividedByZero()
        {
            string expression = "10/0=";
            string expected = "-E-";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestMultipleAdditionOperationInAExpression()
        {
            string expression = "10+10+20=";
            string expected = "40";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestMultipleAdditionOperationInAExpressionWithoutEqual()
        {
            string expression = "10+10+20";
            string expected = "20";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        public string GetResult(string expression)
        {
            string result="";
            foreach(var key in expression)
            {
                result = calculator.SendKeyPress(key);
            }
            return result;
            throw new NotImplementedException();
        }
        [Fact]
        public void TestDecimalNumber()
        {
            string expression = "1..001";
            string expected = "1.001";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestExpressionWithDecimalNumber()
        {
            string expression = "1..05+1..35=";
            string expected = "2.4";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestResetKey()
        {
            string expression = "1..05+1.35=c";
            string expected = "0";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestWithMultiplication()
        {
            string expression = "15x10+10=";
            string expected = "160";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }

    }
}
