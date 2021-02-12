using System;
using Xunit;
using ConsoleCalculator;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void DummyTest()
        {
            return;
        }
        // Test 1
        [Fact]
        public void SimpleSummationTest()
        {
            string inputArguement = "10+2=";
            string output = Operations.FindCalculatorOutput(inputArguement);
            string expected = "12";

            Assert.Equal(expected, output);
        }

        //Test 2
        [Fact]

        public void DivisionByZeroTest()
        {
            string inputArguement = "10/0=";
            string output = Operations.FindCalculatorOutput(inputArguement);
            string expected = "-E-";

            Assert.Equal(expected, output);
        }

        //Test 3
        [Fact]

        public void ExtraDecimalsTest()
        {
            string inputArguement = "00..001";
            string output = Operations.FindCalculatorOutput(inputArguement);
            string expected = "0.001";

            Assert.Equal(expected, output);
        }

        //Test 4
        [Fact]

        public void SignToggleTest()
        {
            string inputArguement = "12+2SSS=";
            string output = Operations.FindCalculatorOutput(inputArguement);
            string expected = "10";

            Assert.Equal(expected, output);
        }

        //Test 5
        [Fact]

        public void MoreThanTwoArguementsTest()
        {
            string inputArguement = "1+2+3+=";
            string output = Operations.FindCalculatorOutput(inputArguement);
            string expected = "12";

            Assert.Equal(expected, output);
        }

        //Test 6
        [Fact]

        public void CancelButtonCheck()
        {
            string inputArguement = "1+2+C";
            string output = Operations.FindCalculatorOutput(inputArguement);
            string expected = "0";

            Assert.Equal(expected, output);
        }
    }
}
