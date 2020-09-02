using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator calculator;
        public CalculatorFixture()
        {
            calculator = new Calculator();
        }

        [Fact]
        public void TestSingleDigitNumbers()
        {
            string result;
            result = calculator.SendKeyPress('2');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('=');
            Assert.Equal("5", result);
        }


        [Fact]
        public void TestMultipleDigitsNumbers()
        {
            string result;
            result = calculator.SendKeyPress('1');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('=');
            Assert.Equal("750", result);
        }


        [Fact]
        public void TestDecimalNumbers()
        {
            string result;
            result = calculator.SendKeyPress('9');
            result = calculator.SendKeyPress('.');
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('-');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('.');
            result = calculator.SendKeyPress('8');
            result = calculator.SendKeyPress('=');
            Assert.Equal("2.5", result);
        }
        [Fact]
        public void TestAlphanumericValues()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('k');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('p');
            result = calculator.SendKeyPress('8');
            result = calculator.SendKeyPress('I');
            result = calculator.SendKeyPress('n');
            result = calculator.SendKeyPress('=');
            Assert.Equal("43", result);
        }

         [Fact]
         public void TestMultipleZerosBeforeDecimalPoint()
         {
             string result;
             result = calculator.SendKeyPress('0');
             result = calculator.SendKeyPress('0');
             result = calculator.SendKeyPress('0');
             result = calculator.SendKeyPress('.');
             result = calculator.SendKeyPress('.');
             result = calculator.SendKeyPress('7');
             result = calculator.SendKeyPress('-');
             result = calculator.SendKeyPress('0');
             result = calculator.SendKeyPress('0');
             result = calculator.SendKeyPress('.');
             result = calculator.SendKeyPress('8');
             result = calculator.SendKeyPress('=');
             Assert.Equal("-0.1", result);
         }

        [Fact]
        public void TestAddition()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('4');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('4');
            result = calculator.SendKeyPress('=');
            Assert.Equal("108", result);
        }

        [Fact]
        public void TestSubtraction()
        {
            string result;
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('2');
            result = calculator.SendKeyPress('-');
            result = calculator.SendKeyPress('1');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('=');
            Assert.Equal("16", result);
        }

        [Fact]
        public void TestMultiplication()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('x');
            result = calculator.SendKeyPress('1');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('=');
            Assert.Equal("50", result);
        }

        [Fact]
        public void TestDivision()
        {
            string result;
            result = calculator.SendKeyPress('1');
            result = calculator.SendKeyPress('8');
            result = calculator.SendKeyPress('/');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('=');
            Assert.Equal("3", result);
        }

        [Fact]
        public void TestDivisionByZeroOperation()
        {
            string result;
            result = calculator.SendKeyPress('1');
            result = calculator.SendKeyPress('/');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('=');
            Assert.Equal("-E-", result);
        }

        [Fact]
        public void TestResetOperation()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('C');
            Assert.Equal("0", result);
        }

        [Fact]
         void TestMixedOperations()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('-');
            result = calculator.SendKeyPress('2');
            result = calculator.SendKeyPress('2');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('x');
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('=');
            Assert.Equal("170", result);
        }

        [Fact]
        public void TestSingleToggleOperation()
        {
            string result;
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('-');
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('=');
            Assert.Equal("-6", result);
        }

        [Fact]
        public void TestMultipleToggleOperation()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('-');
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('S');
            result = calculator.SendKeyPress('=');
            Assert.Equal("-2", result);
        }
    }
}
