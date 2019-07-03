using System;
using Xunit;
using ConsoleCalculator;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture : IDisposable
    {
        private Calculator calculator;
        public CalculatorFixture()
        {
            calculator = new Calculator();
        }
        public void Dispose()
        {
            calculator = null;
         
        }
        [Fact]
        public void TestAddition()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('2');
            Assert.Equal("12", calculator.SendKeyPress('='));

        }
        [Fact]
        public void TestMultiplication()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('x');
            calculator.SendKeyPress('2');
            Assert.Equal("2", calculator.SendKeyPress('='));

        }
        [Fact]
        public void TestError()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('/');
            calculator.SendKeyPress('0');
            Assert.Equal("-E-", calculator.SendKeyPress('='));
        }
        [Fact]
        public void TestDivision()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('/');
            calculator.SendKeyPress('2');
            Assert.Equal("50", calculator.SendKeyPress('='));
        }
        [Fact]
        public void TestClear()
        {
            calculator.SendKeyPress('2');
            calculator.SendKeyPress('/');
            calculator.SendKeyPress('0');
            Assert.Equal("0", calculator.SendKeyPress('c'));
        }
        [Fact]
        public void TestToggle()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('2');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('2');
            calculator.SendKeyPress('s');
            calculator.SendKeyPress('S');
            calculator.SendKeyPress('s');
            Assert.Equal("10", calculator.SendKeyPress('='));
        }
        [Fact]
        public void TestDecimal()
        {
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('.');
            calculator.SendKeyPress('.');
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('2');
            Assert.Equal("2.1", calculator.SendKeyPress('='));
        }
        [Fact]
        public void TestSubtraction()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('-');
            calculator.SendKeyPress('1');
            Assert.Equal("0", calculator.SendKeyPress('='));

        }
        [Fact]
        public void TestMultipleExpression()
        {
            calculator.SendKeyPress('2');
            calculator.SendKeyPress('-');
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('3');
            Assert.Equal("4", calculator.SendKeyPress('='));
        }
    }
}
