using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator cal;
        public CalculatorFixture()
        {
            cal = new Calculator();
        }

        [Fact]
        public void SummationTest()
        {
            string expression = "10+2=";
            string expected = "";
            string actual = "12";

            foreach (char c in expression)
            {
                expected = cal.SendKeyPress(c);
                if (expected.Equals("-E-"))
                    break;
            }
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void DivideByZeroTest()
        {
            string expression = "10/0=";
            string expected = "";
            string actual = "-E-";

            foreach (char c in expression)
            {
                expected = cal.SendKeyPress(c);
                if (expected.Equals("-E-"))
                    break;
            }
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void ExtraDecimalsTest()
        {
            string expression = "00..001";
            string expected = "";
            string actual = "0.001";

            foreach (char c in expression)
            {
                expected = cal.SendKeyPress(c);
                if (expected.Equals("-E-"))
                    break;
            }
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void SignToggleTest()
        {
            string expression = "12+2SSS=";
            string expected = "";
            string actual = "10";

            foreach (char c in expression)
            {
                expected = cal.SendKeyPress(c);
                if (expected.Equals("-E-"))
                    break;
            }
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void CancelButtonCheck()
        {
            string expression = "1+2+C";
            string expected = "";
            string actual = "0";


            foreach (char c in expression)
            {
                expected = cal.SendKeyPress(c);
                if (expected.Equals("-E-"))
                    break;
            }
            Assert.Equal(actual, expected);
        }

        [Fact]

        public void MoreThanTwoArguementsTest()
        {
            string expression = "12+13+14=";
            string expected = "";
            string actual = "39";


            foreach (char c in expression)
            {
                expected = cal.SendKeyPress(c);
                if (expected.Equals("-E-"))
                    break;
            }
            Assert.Equal(actual, expected);
        }

    }
}
