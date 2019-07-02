using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator c;
        public CalculatorFixture()
        {
            c = new Calculator();
        }

        [Fact]
        public void NumbersCheck()
        {
            string input = "9530006004";
            string OutputExpected = "9530006004";
            string Output= PassTheInput(input);
            Assert.Equal(Output,OutputExpected);
        }

        [Fact]
        public void DecimalCheck()
        {
            string input = "0.....01";
            string OutputExpected = "0.01";
            string Output = PassTheInput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void DecimalAdvanceCheck()
        {
            string input = "0.....0..1"; // decimals presses after once should be ignored like real life calc.
            string OutputExpected = "0.01";
            string Output = PassTheInput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void DivideByZeroErrorCheck()
        {
            string input = "10/0=";
            string OutputExpected = "-E-";
            string Output = PassTheInput(input);
            Assert.Equal(Output, OutputExpected);
        }
        [Fact]
        public void MultiplicationCheck()
        {
            string input = "10x10x10=";
            string OutputExpected = "1000";
            string Output = PassTheInput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void SubtractionCheck()
        {
            string input = "90-91=";
            string OutputExpected = "-1";
            string Output = PassTheInput(input);
            Assert.Equal(Output, OutputExpected);
        }


        [Fact]
        public void DivideCheck()
        {
            string input = "10/2=";
            string OutputExpected = "5";
            string Output = PassTheInput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void AdditionCheck()
        {
            string input = "10+2=";
            string OutputExpected = "12";
            string Output = PassTheInput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void SignCheck()
        {
            string input = "1SsSsS";
            string OutputExpected = "-1";
            string Output = PassTheInput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void NotAllowedCharacterCheck()
        {
            string input = "@";
            string OutputExpected = "0";
            string Output = PassTheInput(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void RandomCheck()
        {
            string input = "12+2SsS=";
            string OutputExpected = "10";
            string Output = PassTheInput(input);
            Assert.Equal(Output, OutputExpected);
        }


        [Fact]
        public void NotAllowedCharacterCheck_2()
        {
            string input = "007+vibhu1=";
            string OutputExpected = "8";
            string Output = PassTheInput(input);
            Assert.Equal(Output, OutputExpected);
        }

        public string PassTheInput(string input)
        {
            char[] arr = input.ToCharArray();
            string output = "";
            for(int i=0; i<arr.Length;i++)
            {
                output=c.SendKeyPress(arr[i]);
            }
            return output;
        }
    }
}
