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
        //[Fact]
        //public void DummyTest()
        //{
        //    return;
        //}

        [Fact]
        public void Test_SingleDigitNumbers()
        {
            string result;
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('=');
            Assert.Equal("6", result);
        }

        [Fact]
        public void Test_MultipleDigitsNumbers()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('4');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('7');
            result = calculator.SendKeyPress('8');
            result = calculator.SendKeyPress('8');
            result = calculator.SendKeyPress('=');
            Assert.Equal("842", result);
        }

        [Fact]
        public void TestNotAllowedCharacters()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('4');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('7');
            result = calculator.SendKeyPress('J');
            result = calculator.SendKeyPress('8');
            result = calculator.SendKeyPress('I');
            result = calculator.SendKeyPress('n');
            result = calculator.SendKeyPress('=');
            Assert.Equal("132", result);
        }


        [Fact]
        public void TestCombinationOfAllowedNotAllowedCharacters()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('4');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('7');
            result = calculator.SendKeyPress('J');
            result = calculator.SendKeyPress('8');
            result = calculator.SendKeyPress('C');
            result = calculator.SendKeyPress('n');
            result = calculator.SendKeyPress('=');
            Assert.Equal("-E-", result);
        }

        [Fact]
        public void TestFloatNumbers()
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
        public void TestMultipleDecimalPointsEnterByUser()
        {
            string result;
            result = calculator.SendKeyPress('9');
            result = calculator.SendKeyPress('.');
            result = calculator.SendKeyPress('.');
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('-');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('.');
            result = calculator.SendKeyPress('.');
            result = calculator.SendKeyPress('8');
            result = calculator.SendKeyPress('=');
            Assert.Equal("2.5", result);
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
        public void TestCombinationNumbers()
        {
            string result;
            result = calculator.SendKeyPress('9');
            result = calculator.SendKeyPress('4');
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('-');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('.');
            result = calculator.SendKeyPress('8');
            result = calculator.SendKeyPress('=');
            Assert.Equal("876.2", result);
        }

        [Fact]
        public void TestAdditionOperation()
        {
            string result;
            result = calculator.SendKeyPress('9');
            result = calculator.SendKeyPress('4');
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('=');
            Assert.Equal("1009", result);
        }

        [Fact]
        public void TestSubtractionOperation()
        {
            string result;
            result = calculator.SendKeyPress('9');
            result = calculator.SendKeyPress('4');
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('-');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('2');
            result = calculator.SendKeyPress('=');
            Assert.Equal("281", result);
        }

        [Fact]
        public void TestMultiplicationOperation()
        {
            string result;
            result = calculator.SendKeyPress('9');
            result = calculator.SendKeyPress('x');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('=');
            Assert.Equal("54", result);
        }

        [Fact]
        public void TestDivisionOperation()
        {
            string result;
            result = calculator.SendKeyPress('1');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('/');
            result = calculator.SendKeyPress('2');
            result = calculator.SendKeyPress('=');
            Assert.Equal("8", result);
        }

        [Fact]
        public void TestDivisionByZeroOperation()
        {
            string result;
            result = calculator.SendKeyPress('1');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('/');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('=');
            Assert.Equal("-E-", result);
        }

        [Fact]
        public void TestMultipleOperations()
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
        public void TestCalculatorResetOperation()
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
        public void TestAfterResetMathOperations()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('C');
            result = calculator.SendKeyPress('2');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('=');
            Assert.Equal("26", result);
        }

        [Fact]
        public void TestFirstNumberSingleToggleOperation()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('=');
            Assert.Equal("1", result);
        }

        [Fact]
        public void TestFirstNumberMultipleToggleOperation()
        {
            string result;
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('+');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('=');
            Assert.Equal("11", result);
        }

        [Fact]
        public void TestMultipleNumbersSingleToggleOperation()
        {
            string result;
            result = calculator.SendKeyPress('3');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('-');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('=');
            Assert.Equal("-24", result);
        }

        [Fact]
        public void TestMultipleNumbersMultipleToggleOperations()
        {
            string result;
            result = calculator.SendKeyPress('1');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('x');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('x');
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('=');
            Assert.Equal("300", result);
        }


        [Fact]
        public void TestCaseInsufficiencyForAllowedCharacters()
        {
            string result;
            result = calculator.SendKeyPress('1');
            result = calculator.SendKeyPress('0');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('S');
            result = calculator.SendKeyPress('x');
            result = calculator.SendKeyPress('6');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('S');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('x');
            result = calculator.SendKeyPress('5');
            result = calculator.SendKeyPress('s');
            result = calculator.SendKeyPress('=');
            Assert.Equal("300", result);
        }
    }
}
