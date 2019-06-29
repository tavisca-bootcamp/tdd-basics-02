using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calci = new Calculator();
        string query = "";
        string actualOutput = "";
        [Fact]
        public void DivisibilityByZero()
        {
            query = "1/0=";
            actualOutput = FetchActualOutput(query);
            Assert.Equal("-E-", actualOutput);
        }

        [Fact]
        public void TestForClearScreen()
        {
            query = "1/99=c";
            actualOutput = FetchActualOutput(query);
            Assert.Equal("0", actualOutput);
        }

        [Fact]
        public void IsValidOutput()
        {
            query = "18x2-20+1/1=";
            actualOutput = FetchActualOutput(query);
            Assert.Equal("17", actualOutput);
        }

        [Fact]
        public void CanHandleCaseSensitivityForSign()
        {
            query = "1+2S=";
            actualOutput = FetchActualOutput(query);
            Assert.Equal("-1", actualOutput);
        }

        [Fact]
        public void CanHandleCaseSensitivityForClear()
        {
            query = "1+2sS=c1+2C";
            actualOutput = FetchActualOutput(query);
            Assert.Equal("0", actualOutput);
        }

        [Fact]
        public void CanHandleCaseSensitivityForMuliplication()
        {
            query = "2x2X2=";
            actualOutput = FetchActualOutput(query);
            Assert.Equal("8", actualOutput);
        }

        [Fact]
        public void CanHandlePositiveNegativeNumbers()
        {
            query = "1+-1=";
            actualOutput = FetchActualOutput(query);
            Assert.Equal("0", actualOutput);
        }


        public string FetchActualOutput(string query) {
            string temp = "";
            foreach (char input in query)
            {
                temp = calci.SendKeyPress(input);
            }
            return temp;
        }
    }
}
