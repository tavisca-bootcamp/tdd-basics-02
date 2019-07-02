using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator cl = new Calculator();

        [Fact]
        public void ForAddition()
        {
            string input = "10+2=";
            string result = pressedButton(input);
            Assert.Equal("12", result);
        }

        [Fact]
        public void ForSubtraction()
        {
            string input = "10-2=";
            string result = pressedButton(input);
            Assert.Equal("8", result);
        }

        [Fact]
        public void ForDecimal()
        {
            string input = "1.2+3=";
            string result = pressedButton(input);
            Assert.Equal("4.2", result);
        }

        [Fact]
        public void forDivision()
        {
            string input = "10/2=";
            string result = pressedButton(input);
            Assert.Equal("5", result);
        }

        [Fact]
        public void forDivision2()
        {
            string input = "10/0=";
            string result = pressedButton(input);
            Assert.Equal("-E-", result);
        }

        [Fact]
        public void forManyDecimals()
        {
            string input = "00..001";
            string result = pressedButton(input);
            Assert.Equal("0.001", result);
        }

        [Fact]
        public void forToggle()
        {
            string input = "12+2SSS=";
            string result = pressedButton(input);
            Assert.Equal("10", result);
        }

        [Fact]
        public void forClear()
        {
            string input = "1+2+c";
            string result = pressedButton(input);
            Assert.Equal("0", result);
        }

        [Fact]
        public void TestForMultipleOperations()
        {
            string input = "1+2*3-1/2=";
            string result = pressedButton(input);
            Assert.Equal("4", result);
        }

        public string pressedButton(string key)
        {
            string result = "";
            foreach(char k in key)
            {
                result = cl.SendKeyPress(k);
            }
            return result;
        }
    }
}
