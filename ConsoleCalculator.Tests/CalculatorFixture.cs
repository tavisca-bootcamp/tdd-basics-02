using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator = new Calculator();

        [Fact]
        public void AdditionTest()
        {
            string input = "10+2=";
            string Output = calculatortestx(input);
            Assert.Equal("12", Output);
        }

        [Fact]
        public void SubtractionTest()
        {
            string input = "190-56=";
            string Output = calculatortestx(input);
            Assert.Equal("134", Output);
        }

        [Fact]
        public void MultiplicationTest()
        {
            string input = "77x5=";
            string Output = calculatortestx(input);
            Assert.Equal("385", Output);
        }

        [Fact]
        public void DivisionTest()
        {
            string input = "123/3=";
            string Output = calculatortestx(input);
            Assert.Equal("41", Output);
        }

        [Fact]
        public void DivideByZeroCheck()
        {
            string input = "10/0=";
            string result = calculatortestx(input);
            Assert.Equal( "-E-",result);
        }

        [Fact]
        public void DoubleDecimalCheck()
        {
            string input = "0..001";
            string Output = calculatortestx(input);
            Assert.Equal("0.001", Output);
        }

        [Fact]
        public void MultipleToggleSignWithAdditioncheck()
        {
            string input = "12+2SSS=";
            string output = calculatortestx(input);
            Assert.Equal("10", output);
        }

        [Fact]
        public void MultipleAdditionCheck()
        {
            string input = "1+2+3+6=";
            string output = calculatortestx(input);
            Assert.Equal("12", output);
        }

        [Fact]
        public void MultipleAdditionwithClearConsoleCheck()
        {
            string input = "1+2+c";
            string output = calculatortestx(input);
            Assert.Equal("0", output);
        }

        [Fact]
        public void TogglingCheck()
        {
            string input = "1234SsS";
            string Output = calculatortestx(input);
            Assert.Equal("-1234", Output);
        }

        [Fact]
        public void MultipleZerosTest()
        {
            string input = "00000000";
            string Output = calculatortestx(input);
            Assert.Equal("0", Output);
        }

        [Fact]
        public void MultipleZerosAfterDecimalPointTest()
        {
            string input = "1232.00000000";
            string Output = calculatortestx(input);
            Assert.Equal("1232.00000000", Output);
        }

        [Fact]
        public void MultipleDecimalPointTest()
        {
            string input = "11...23";
            string Output = calculatortestx(input);
            Assert.Equal("11.23", Output);
        }

        [Fact]
        public void ConsoleClearTest()
        {
            string input = "1+2-12x7C";
            string Output = calculatortestx(input);
            Assert.Equal("0", Output);
        }

        private string calculatortestx(string input)
        {
            string Output = "";
            for(int i = 0; i < input.Length; i++)
            {
                Output = calculator.SendKeyPress(input[i]);
            }
            
            return Output;
        }
    }
}
