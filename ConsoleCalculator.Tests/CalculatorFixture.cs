using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calci = new Calculator();
        string query = "";
        string actualResult = "";
        [Fact]
        public void TestDivisibilityByZero()
        {
            query = "1/0=";
			string expectedResult = "-E-";
            actualResult = FetchOutput(query);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestForClearScreen()
        {
            query = "1/99=c";
			string expectedResult = "0";
            actualResult = FetchOutput(query);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void IsValidOutput()
        {
            query = "18x2-20+1/1=";
			string expectedResult = "17";
            actualResult = FetchOutput(query);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestCaseSensitivityForSign()
        {
            query = "1+2S=";
			string expectedResult = "-1";
            actualResult = FetchOutput(query);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestCaseSensitivityForClear()
        {
            query = "1+2sS=c1+2C";
			string expectedResult = "0";
            actualResult = FetchOutput(query);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestCaseSensitivityForMuliplication()
        {
            query = "2x2X2=";
			string expectedResult = "8";
            actualResult = FetchOutput(query);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestPositiveNegativeNumbers()
        {
            query = "1+-1=";
			string expectedResult = "0";
            actualResult = FetchOutput(query);
            Assert.Equal(expectedResult, actualResult);
        }


        public string FetchOutput(string query) 
		{
            string temp = "";
            foreach (char input in query)
            {
                temp = calci.SendKeyPress(input);
            }
            return temp;
        }
    }
}
