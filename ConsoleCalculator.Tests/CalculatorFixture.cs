using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator _calculator;

        public CalculatorFixture()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void SingleDigitDecimal()
        {
            _calculator.SendKeyPress('9');
            Assert.Equal("9", _calculator.GetDisplayValue());
        }

        [Fact]
        public void MultipleDigitDecimal()
        {
            _calculator.SendKeyPress('7');
            _calculator.SendKeyPress('9');
            Assert.Equal("79", _calculator.GetDisplayValue());
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
            Assert.Equal("163", _calculator.GetDisplayValue());
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
            Assert.Equal("24", _calculator.GetDisplayValue());
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
            Assert.Equal("-24", _calculator.GetDisplayValue());
        }

        [Fact]
        public void TestDivision()
        {
            _calculator.SendKeyPress('7');
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('/');
            _calculator.SendKeyPress('2');
            _calculator.SendKeyPress('=');
            Assert.Equal("35", _calculator.GetDisplayValue());
        }

        [Fact]
        public void TestDivisionDivideBy0()
        {
            _calculator.SendKeyPress('7');
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('/');
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('=');
            Assert.Equal("-E-",_calculator.GetDisplayValue());
        }

        [Fact]
        public void TestMultiplication()
        {
            _calculator.SendKeyPress('9');
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('*');
            _calculator.SendKeyPress('5');
            _calculator.SendKeyPress('=');
            Assert.Equal("450", _calculator.GetDisplayValue());
        }

        [Fact]
        public void TestResetCalculator()
        {
            _calculator.SendKeyPress('9');
            _calculator.SendKeyPress('5');
            _calculator.SendKeyPress('/');
            _calculator.SendKeyPress('5');
            _calculator.SendKeyPress('=');
            _calculator.SendKeyPress('c');

            Assert.Equal("0", _calculator.GetDisplayValue());
            Assert.Equal(0, _calculator.currentOperand);
            Assert.Equal('\0', _calculator.currentOperator);
            Assert.Equal(0, _calculator.result);
        }

        [Fact]
        public void OperandSignChange()
        {
            _calculator.SendKeyPress('9');
            _calculator.SendKeyPress('5');
            _calculator.SendKeyPress('/');
            _calculator.SendKeyPress('5');
            _calculator.SendKeyPress('2');
            _calculator.SendKeyPress('s');
            Assert.Equal("-52", _calculator.GetDisplayValue());
            Console.WriteLine();
        }

        [Fact]
        public void EqualToAfterAddOperandDoublesDisplayValue()
        {
            _calculator.SendKeyPress('1');
            _calculator.SendKeyPress('+');
            _calculator.SendKeyPress('2');
            _calculator.SendKeyPress('+');
            _calculator.SendKeyPress('3');
            _calculator.SendKeyPress('+');
            _calculator.SendKeyPress('=');
            Assert.Equal("12", _calculator.GetDisplayValue());

        }

        [Fact]
        public void MultipleZeroesBeforeDecimalDisplaysSingleZero()
        {
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('0');
            Assert.Equal("0", _calculator.GetDisplayValue());
        }

        [Fact]
        public void DisplayAllValuesAfterDecimal()
        {
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('.');
            _calculator.SendKeyPress('0');
            _calculator.SendKeyPress('1');
            Assert.Equal("0.01", _calculator.GetDisplayValue());
            _calculator.SendKeyPress('2');
            _calculator.SendKeyPress('1');
            Assert.Equal("0.0121", _calculator.GetDisplayValue());
        }

    }
}
