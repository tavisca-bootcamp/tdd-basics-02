using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator calculator;

        public CalculatorFixture()
        {
            this.calculator = new Calculator();
        }


        [Fact]
        public void DummyTest()
        {
            return;
        }

        [Fact]
        public void NumberTest()
        {
            String inputString = "12345";
            String expectedResult = "12345";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult,actualResult);
        }


        [Fact]
        public void DecimalTest()
        {
            String inputString = "123.45";
            String expectedResult = "123.45";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void DoubleDecimalTest()
        {
            String inputString = "123..45";
            String expectedResult = "123.45";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AlphabetTest()
        {
            String inputString = "123abd45";
            String expectedResult = "12345";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AdditionTest()
        {
            String inputString = "111+111+111=";
            String expectedResult = "333";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void SubstractionTest()
        {
            String inputString = "1000-750=";
            String expectedResult = "250";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void DivisionTest()
        {
            String inputString = "1000/5=";
            String expectedResult = "200";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void MultiplicationTest()
        {
            String inputString = "10x5x2=";
            String expectedResult = "100";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void DivisionByZeroTest()
        {
            String inputString = "100/0=";
            String expectedResult = "-E-";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ClearTest()
        {
            String inputString = "100+100c";
            String expectedResult = "0";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void SignConversionTest()
        {
            String inputString = "2sss";
            String expectedResult = "-2";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CaseInsensitivityTest()
        {
            String inputString = "2x2X2sS=";
            String expectedResult = "8";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Example1_Test()
        {
            String inputString = "10+2=";
            String expectedResult = "12";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Example2_Test()
        {
            String inputString = "10/0=";
            String expectedResult = "-E-";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Example3_Test()
        {
            String inputString = "00..001";
            String expectedResult = "0.001";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Example5_Test()
        {
            String inputString = "1+2+3+=";
            String expectedResult = "12";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Example6_Test()
        {
            String inputString = "1+2+c";
            String expectedResult = "0";
            String actualResult = GenerateResult(inputString);
            Assert.Equal(expectedResult, actualResult);
        }


        private String GenerateResult( String inputString)
        {
            char[] input = inputString.ToCharArray();
            String result = "";
            for (int i = 0; i < input.Length; i++)
            {
                result = calculator.SendKeyPress(input[i]);
            }
            return result;
        }
    }
}
