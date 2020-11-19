using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator;
        public CalculatorFixture()
        {
            this.calculator = new Calculator();
        }
        [Fact]
        public void ProcessSingleDigitDecimalInput()
        {           
            calculator.PressSingleKey('1');
            Assert.Equal("1", calculator.ShowDisplayValue());
            return;
        }
        [Fact]
        public void TestMultiDigitDecimalInput()
        {           
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('5');
            Assert.Equal("55", calculator.ShowDisplayValue());
            return;
        }
        [Fact]
        public void TestBinarySum()
        {          
            calculator.PressSingleKey('5');
            calculator.PressSingleKey('1');
            calculator.PressSingleKey('+');
            calculator.PressSingleKey('2');
            calculator.PressSingleKey('3');
            calculator.PressSingleKey('=');
            Assert.Equal("74", calculator.DisplayValue);
        }
        [Fact]
        public void TestBinaryDiffrence()
        {        
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
            calculator.PressSingleKey('0');
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