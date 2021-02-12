using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calc;
        public CalculatorFixture()
        {
            calc = new Calculator();
        }

        [Fact]
        public void NumbersCheck()
        {
            string input = "995249743917038";
            string OutputExpected = "995249743917038";
            string Output = FinalOutput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void DecimalCheck()
        {
            string input = "0..1..0";
            string OutputExpected = "0.1";
            string Output = FinalOutput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void DivideByZeroCheck()
        {
            string input = "1/0=";
            string OutputExpected = "-E-";
            string Output = FinalOutput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void AdditionCheck()
        {
            string input = "10+2=";
            string OutputExpected = "12";
            string Output = FinalOutput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void SubtractionCheck()
        {
            string input = "50-10=";
            string OutputExpected = "40";
            string Output = FinalOutput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void MultiplyCheck()
        {
            string input = "4X4X4X4=";
            string OutputExpected = "256";
            string Output = FinalOutput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void DivideCheck()
        {
            string input = "50/5=";
            string OutputExpected = "10";
            string Output = FinalOutput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void SignCheck()
        {
            string input = "s6ssSSs";
            string OutputExpected = "6";
            string Output = FinalOutput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void NotValidCharacterCheck()
        {
            string input = "aavqwr198-fa4#";
            string OutputExpected = "194";
            string Output = FinalOutput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void OverallCheck()
        {
            string input = "15-5+9s+3=";
            string OutputExpected = "4";
            string Output = FinalOutput(input);
            Assert.Equal(Output, OutputExpected);
        }

        public string FinalOutput(string input)
        {
            char[] A = input.ToCharArray();
            string output = "";
            for (int i = 0; i < A.Length; i++)
            {
                output = calc.SendKeyPress(A[i]);
            }
            return output;
        }
    }
}
