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
        public void TenPlus2()
        {
            string s = "10+2=";
            string r = "";
            foreach(char c in s)
            {
                r = cal.SendKeyPress(c);
                if (r.Equals("-E-"))
                    break;
            }
            Assert.Equal("12", r);
        }

        [Fact]
        public void DivideByZero()
        {
            string s = "10/0=";
            string r = "";
            foreach (char c in s)
            {
                r = cal.SendKeyPress(c);
                if (r.Equals("-E-"))
                    break;
            }
            Assert.Equal("-E-", r);
        }

        [Fact]
        public void MoreThanOneDecimalPoint()
        {
            string s = "00..001";
            string r = "";
            foreach (char c in s)
            {
                r = cal.SendKeyPress(c);
                if (r.Equals("-E-"))
                    break;
            }
            Assert.Equal("0.001", r);
        }

        [Fact]
        public void UseOfS()
        {
            string s = "12+2SSS=";
            string r = "";
            foreach (char c in s)
            {
                r = cal.SendKeyPress(c);
                if (r.Equals("-E-"))
                    break;
            }
            Assert.Equal("10", r);
        }

        [Fact]
        public void UseOfC()
        {
            string s = "1+2+C";
            string r = "";
            foreach (char c in s)
            {
                r = cal.SendKeyPress(c);
                if (r.Equals("-E-"))
                    break;
            }
            Assert.Equal("0", r);
        }

    }
}
