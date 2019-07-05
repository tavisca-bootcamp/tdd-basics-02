using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void TestAdditon()
        {
            string expectedResult = "12";
            string actualResult = GetResult("10 + 2 =");
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestSubtraction()
        {
            string expectedResult = "8";
            string actualResult = GetResult("10 - 2 =");
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestDivision()
        {
            string expectedResult = "5";
            string actualResult = GetResult("10 / 2 =");
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestMultiplication()
        {
            string expectedResult = "20";
            string actualResult = GetResult("10 * 2 =");
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestMultipleDecimal()
        {
            string expectedResult = "0.001";
            string actualResult = GetResult("00..001");
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestSignOperation()
        {
            string expectedResult = "10";
            string actualResult = GetResult("12+2sss=");
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestEndWithAddition()
        {
            string expectedResult = "-E-";
            string actualResult = GetResult("1+2+3+=");
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestEndWithSubtraction()
        {
            string expectedResult = "-E-";
            string actualResult = GetResult("1+2+3-=");
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestEndWithMultiplication()
        {
            string expectedResult = "-E-";
            string actualResult = GetResult("1+2+3*=");
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestEndWithDivision()
        {
            string expectedResult = "-E-";
            string actualResult = GetResult("1+2+3/=");
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestClear()
        {
            string expectedResult = "0";
            string actualResult = GetResult("1+2+C");
            Assert.Equal(expectedResult, actualResult);
        }

        public string GetResult(string expression)
        {
            var calc = new Calculator();
            string result = "";
            foreach (char exp in expression)
            {
                result=calc.SendKeyPress(exp);
            }
            return result;
        }
    }
}
