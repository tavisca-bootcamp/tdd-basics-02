using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator;

        private void setUp()
        {
            this.calculator = new Calculator();
        }

        [Fact]
        public void ProcessSingleDigitDecimalInput()
        {
            setUp();
            calculator.PressSingleKey('5');
            Assert.Equal("5", calculator.ShowDisplayValue());
            return;
        }

        [Fact]
        public void TestMultiDigitDecimalInput()
        {
            setUp();
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('5');
            Assert.Equal("55", calculator.ShowDisplayValue());
            return;
        }

        [Fact]
        public void TestBinarySum()
        {
            setUp();
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('4');
            calculator.PressSingleKey('+');
            calculator.PressSingleKey('2');
            calculator.PressSingleKey('3');
            calculator.PressSingleKey('=');
            Assert.Equal("77", calculator.DisplayValue);
        }

        [Fact]
        public void TestBinaryDiffrence()
        {
            setUp();
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('4');
            calculator.PressSingleKey('-');
            calculator.PressSingleKey('2');
            calculator.PressSingleKey('3');
            calculator.PressSingleKey('=');
            Assert.Equal("31", calculator.DisplayValue);
        }

        [Fact]
        public void TestBinaryDivision()
        {
            setUp();
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('0');
            calculator.PressSingleKey('/');
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('=');
            Assert.Equal("10", calculator.DisplayValue);
        }

        [Fact]
        public void TestBinaryMultiPlication()
        {
            setUp();
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('0');
            calculator.PressSingleKey('x');
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('=');
            Assert.Equal("250", calculator.DisplayValue);
        }

        [Fact]
        public void TestResetCalculator()
        {
            setUp();
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('0');
            calculator.PressSingleKey('/');
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('=');
            calculator.PressSingleKey('c');
            Assert.Equal("0", calculator.DisplayValue);
            Assert.Equal(0, calculator.CurrentOperand);
            Assert.Equal('\0', calculator.CurrentOperator);
            Assert.Equal(0, calculator.Result);
        }


        [Fact]
        public void DivideByZeroDisplayError()
        {
            setUp();
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('0');
            calculator.PressSingleKey('/');
            calculator.PressSingleKey('0');
            calculator.PressSingleKey('=');
            Assert.Equal("-E-", calculator.DisplayValue);
        }

        [Fact]
        public void ChangeOperandSign()
        {
            setUp();
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('0');
            calculator.PressSingleKey('/');
            calculator.PressSingleKey('2');
            calculator.PressSingleKey('3');
            calculator.PressSingleKey('s');
            Assert.Equal("-23", calculator.DisplayValue);
        }

        [Fact]
        public void EqualToAfterAddOperandDoublesDisplayValue()
        {
            setUp();
            calculator.PressSingleKey('1');
            calculator.PressSingleKey('+');
            calculator.PressSingleKey('2');
            calculator.PressSingleKey('+');
            calculator.PressSingleKey('3');
            calculator.PressSingleKey('+');
            calculator.PressSingleKey('=');
            Assert.Equal("12", calculator.DisplayValue);
        }

        [Fact]
        public void InputMultipleZeroBeforeDecimalDisplaysSingleZero()
        {
            setUp();
            calculator.PressSingleKey('0');
            calculator.PressSingleKey('0');
            calculator.PressSingleKey('0');
            calculator.PressSingleKey('0');
            Assert.Equal("0", calculator.DisplayValue);
            calculator.PressSingleKey('+');
            calculator.PressSingleKey('1');
            calculator.PressSingleKey('=');
            Assert.Equal("1", calculator.DisplayValue);
        }

        [Fact]
        public void AfterDecimalDisplaysAllValuesIncludingZeros()
        {
            setUp();
            calculator.PressSingleKey('0');
            calculator.PressSingleKey('.');
            calculator.PressSingleKey('0');
            calculator.PressSingleKey('0');
            Assert.Equal("0.00", calculator.DisplayValue);
            calculator.PressSingleKey('1');
            Assert.Equal("0.001", calculator.DisplayValue);
        }
    }
}