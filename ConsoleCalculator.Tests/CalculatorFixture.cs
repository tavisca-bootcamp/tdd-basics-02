using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void TestNormalAddition()
        {
            Calculator cal = new Calculator();
            string result = cal.SendKeyPress('1');
            Assert.Equal(1, double.Parse(result));

            result = cal.SendKeyPress('0');
            Assert.Equal(10, double.Parse(result));

            result = cal.SendKeyPress('+');
            Assert.Equal(10, double.Parse(result));

            result = cal.SendKeyPress('2');
            Assert.Equal(2, double.Parse(result));

            result = cal.SendKeyPress('=');
            Assert.Equal(12, double.Parse(result));

        }

        [Fact]
        public void TestDivisionByZero()
        {
            Calculator cal = new Calculator();
            string result = cal.SendKeyPress('1');
            Assert.Equal(1, double.Parse(result));

            result = cal.SendKeyPress('0');
            Assert.Equal(10, double.Parse(result));

            result = cal.SendKeyPress('/');
            Assert.Equal(10, double.Parse(result));

            result = cal.SendKeyPress('0');
            Assert.Equal(0, double.Parse(result));

            result = cal.SendKeyPress('=');
            Assert.Equal("-E-", result);

        }

        [Fact]
        public void TestDecimal()
        {
            Calculator cal = new Calculator();
            string result = cal.SendKeyPress('0');
            Assert.Equal(0, double.Parse(result));

            result = cal.SendKeyPress('0');
            Assert.Equal(0, double.Parse(result));

            result = cal.SendKeyPress('.');
            Assert.Equal("0.", result);

            result = cal.SendKeyPress('.');
            Assert.Equal("0.", result);

            result = cal.SendKeyPress('0');
            Assert.Equal("0.0", result);

            result = cal.SendKeyPress('0');
            Assert.Equal("0.00", result);

            result = cal.SendKeyPress('1');
            Assert.Equal("0.001", result);

        }

        [Fact]
        public void TestToggle()
        {
            Calculator cal = new Calculator();
            string result = cal.SendKeyPress('1');
            Assert.Equal(1, double.Parse(result));

            result = cal.SendKeyPress('2');
            Assert.Equal(12, double.Parse(result));

            result = cal.SendKeyPress('+');
            Assert.Equal(12, double.Parse(result));

            result = cal.SendKeyPress('2');
            Assert.Equal(2, double.Parse(result));

            result = cal.SendKeyPress('S');
            Assert.Equal(-2, double.Parse(result));

            result = cal.SendKeyPress('S');
            Assert.Equal(2, double.Parse(result));

            result = cal.SendKeyPress('S');
            Assert.Equal(-2, double.Parse(result));

            result = cal.SendKeyPress('=');
            Assert.Equal(10, double.Parse(result));

        }

        [Fact]
        public void TestMultipleAddition()
        {
            Calculator cal = new Calculator();
            string result = cal.SendKeyPress('1');
            Assert.Equal(1, double.Parse(result));

            result = cal.SendKeyPress('+');
            Assert.Equal(1, double.Parse(result));

            result = cal.SendKeyPress('2');
            Assert.Equal(2, double.Parse(result));

            result = cal.SendKeyPress('+');
            Assert.Equal(3, double.Parse(result));

            result = cal.SendKeyPress('3');
            Assert.Equal(3, double.Parse(result));

            result = cal.SendKeyPress('+');
            Assert.Equal(6, double.Parse(result));

            result = cal.SendKeyPress('=');
            Assert.Equal(9, double.Parse(result));
        }

        [Fact]
        public void TestReset()
        {
            Calculator cal = new Calculator();
            string result = cal.SendKeyPress('1');
            Assert.Equal(1, double.Parse(result));

            result = cal.SendKeyPress('+');
            Assert.Equal(1, double.Parse(result));

            result = cal.SendKeyPress('2');
            Assert.Equal(2, double.Parse(result));

            result = cal.SendKeyPress('+');
            Assert.Equal(3, double.Parse(result));

            result = cal.SendKeyPress('C');
            Assert.Equal(0, double.Parse(result));
        }

    }
}
