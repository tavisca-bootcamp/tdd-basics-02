using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calc;

        private void setUp()
        {
            this.calc = new Calculator();
        }

        [Fact]
        public void ProcessSingleDigitDecimalInput()
        {
            setUp();
            calc.OnKeyPress('5');
            Assert.Equal("5", calc.ShowDisplayValue());
            return;
        }

        [Fact]
        public void TestMultiDigitDecimalInput()
        {
            setUp();
            calc.OnKeyPress('5');
            calc.OnKeyPress('5');
            Assert.Equal("55", calc.ShowDisplayValue());
            return;
        }

        [Fact]
        public void TestBinarySum()
        {
            setUp();
            calc.OnKeyPress('5');
            calc.OnKeyPress('4');
            calc.OnKeyPress('+');
            calc.OnKeyPress('2');
            calc.OnKeyPress('3');
            calc.OnKeyPress('=');
            Assert.Equal("77", calc.DisplayValue);
        }

        [Fact]
        public void TestBinaryDiffrence()
        {
            setUp();
            calc.OnKeyPress('5');
            calc.OnKeyPress('4');
            calc.OnKeyPress('-');
            calc.OnKeyPress('2');
            calc.OnKeyPress('3');
            calc.OnKeyPress('=');
            Assert.Equal("31", calc.DisplayValue);
        }

        [Fact]
        public void TestBinaryDivision()
        {
            setUp();
            calc.OnKeyPress('5');
            calc.OnKeyPress('0');
            calc.OnKeyPress('/');
            calc.OnKeyPress('5');
            calc.OnKeyPress('=');
            Assert.Equal("10", calc.DisplayValue);
        }

        [Fact]
        public void TestBinaryMultiPlication()
        {
            setUp();
            calc.OnKeyPress('5');
            calc.OnKeyPress('0');
            calc.OnKeyPress('x');
            calc.OnKeyPress('5');
            calc.OnKeyPress('=');
            Assert.Equal("250", calc.DisplayValue);
        }

        [Fact]
        public void TestResetCalculator()
        {
            setUp();
            calc.OnKeyPress('5');
            calc.OnKeyPress('0');
            calc.OnKeyPress('/');
            calc.OnKeyPress('5');
            calc.OnKeyPress('=');
            calc.OnKeyPress('c');
            Assert.Equal("0", calc.DisplayValue);
            Assert.Equal(0, calc.CurrentOperand);
            Assert.Equal('\0', calc.CurrentOperator);
            Assert.Equal(0, calc.Result);
        }


        [Fact]
        public void DivideByZeroDisplayError()
        {
            setUp();
            calc.OnKeyPress('5');
            calc.OnKeyPress('0');
            calc.OnKeyPress('/');
            calc.OnKeyPress('0');
            calc.OnKeyPress('=');
            Assert.Equal("-E-", calc.DisplayValue);
        }

        [Fact]
        public void ChangeOperandSign()
        {
            setUp();
            calc.OnKeyPress('5');
            calc.OnKeyPress('0');
            calc.OnKeyPress('/');
            calc.OnKeyPress('2');
            calc.OnKeyPress('3');
            calc.OnKeyPress('s');
            Assert.Equal("-23", calc.DisplayValue);
        }

        [Fact]
        public void EqualToAfterAddOperandDoublesDisplayValue()
        {
            setUp();
            calc.OnKeyPress('1');
            calc.OnKeyPress('+');
            calc.OnKeyPress('2');
            calc.OnKeyPress('+');
            calc.OnKeyPress('3');
            calc.OnKeyPress('+');
            calc.OnKeyPress('=');
            Assert.Equal("12", calc.DisplayValue);
        }

        [Fact]
        public void InputMultipleZeroBeforeDecimalDisplaysSingleZero()
        {
            setUp();
            calc.OnKeyPress('0');
            calc.OnKeyPress('0');
            calc.OnKeyPress('0');
            calc.OnKeyPress('0');
            Assert.Equal("0", calc.DisplayValue);
            calc.OnKeyPress('+');
            calc.OnKeyPress('1');
            calc.OnKeyPress('=');
            Assert.Equal("1", calc.DisplayValue);
        }

        [Fact]
        public void AfterDecimalDisplaysAllValuesIncludingZeros()
        {
            setUp();
            calc.OnKeyPress('0');
            calc.OnKeyPress('.');
            calc.OnKeyPress('0');
            calc.OnKeyPress('0');
            Assert.Equal("0.00", calc.DisplayValue);
            calc.OnKeyPress('1');
            Assert.Equal("0.001", calc.DisplayValue);
        }
    }
}
