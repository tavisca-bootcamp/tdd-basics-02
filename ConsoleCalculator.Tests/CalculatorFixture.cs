using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator _calculator = null;

        public CalculatorFixture()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void SingleDigitDecimal()
        {
            _calculator.SendKeyPress('9');
            Assert.Equal("9", _calculator.ShowDisplayValue());
        }

        [Fact]
        public void MultipleDigitDecimal()
        {
            _calculator.SendKeyPress('7');
            _calculator.SendKeyPress('9');
            Assert.Equal("79", _calculator.ShowDisplayValue());
        }

        [Fact]
        public void TestAddition()
        {
            _calculator.SendKeyPress('9');
            _calculator.SendKeyPress('8');
            _calculator.SendKeyPress('+');
            _calculator.SendKeyPress('6');
            _calculator.SendKeyPress('5');
            _calculator.SendKeyPress('=');
            Assert.Equal("163", _calculator.ShowDisplayValue());
        }

        [Fact]
        public void TestSubstraction()
        {
            _calculator.SendKeyPress('5');
            _calculator.SendKeyPress('6');
            _calculator.SendKeyPress('-');
            _calculator.SendKeyPress('3');
            _calculator.SendKeyPress('2');
            _calculator.SendKeyPress('=');
            Assert.Equal("24", _calculator.ShowDisplayValue());
        }

        [Fact]
        public void TestNegativeResultSubstraction()
        {
            _calculator.SendKeyPress('3');
            _calculator.SendKeyPress('2');
            _calculator.SendKeyPress('-');
            _calculator.SendKeyPress('5');
            _calculator.SendKeyPress('6');
            _calculator.SendKeyPress('=');
            Assert.Equal("-24", _calculator.ShowDisplayValue());
        }

        [Fact]
        public void TestDivision()
        {
            _calculator.SendKeyPress('7');
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('/');
            _calculator.SendKeyPress('2');
            _calculator.SendKeyPress('=');
            Assert.Equal("35", _calculator.ShowDisplayValue());
        }

        [Fact]
        public void TestDivisionDivideBy0()
        {
            _calculator.SendKeyPress('7');
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('/');
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('=');
            Assert.Equal("-E-",_calculator.ShowDisplayValue());
        }

        [Fact]
        public void TestMultiplication()
        {
            _calculator.SendKeyPress('9');
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('*');
            _calculator.SendKeyPress('5');
            _calculator.SendKeyPress('=');
            Assert.Equal("450", _calculator.ShowDisplayValue());
        }

        
    }
}
