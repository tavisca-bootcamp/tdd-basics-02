using System;
using Xunit;
using ConsoleCalculator;
namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator = new Calculator();

        [Fact]
        public void TestWithoutOperation()
        {
            string expression = "12";
            string expected = "12";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestAddition()
        {
            string expression = "10+";
            string expected = "10";
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
        public void TestFirstOperandNegative()
        {
            string expression = "54s+10=";
            string expected = "-44";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestSecondOperandSigned()
        {
            string expression = "54+10s=";
            string expected = "44";
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
        public void TestDivision()
        {
            string expression = "30/10=";
            string expected = "3";
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
        public void TestDividedByZero()
        {
            string expression = "10/0=";
            string expected = "-E-";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestMultipleAddition()
        {
            string expression = "10+20+30=";
            string expected = "60";
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
            string result = "";
            foreach (var key in expression)
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
        public void TestWithMultiplication()
        {
            string expression = "15x10+10=";
            string expected = "160";
            string actual = GetResult(expression);
            Assert.Equal(expected, actual);
        }

    }
}