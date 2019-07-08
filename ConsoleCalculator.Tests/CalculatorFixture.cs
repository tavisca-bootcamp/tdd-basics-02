using System;
using Xunit;
using ConsoleCalculator;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void DummyTest()
        {
            return;
        }
        [Fact]
        public void Test_when_UserEntersSingleDigitNumbers_should_ReturnCorrectAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('+');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('=');

            Assert.Equal("10", result);
        }

        [Fact]
        public void Test_when_UserEntersMultipleDigitNumbers_should_ReturnCorrectAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('8');
            result = c.SendKeyPress('+');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('=');

            Assert.Equal("110", result);
        }

        [Fact]
        public void Test_when_UserEntersAdditionSign_should_ReturnCorrectAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('9');
            result = c.SendKeyPress('6');
            result = c.SendKeyPress('+');
            result = c.SendKeyPress('3');
            result = c.SendKeyPress('4');
            result = c.SendKeyPress('=');

            Assert.Equal("130", result);
        }

        [Fact]
        public void Test_when_UserEntersSubtractionSign_should_ReturnCorrectAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('8');
            result = c.SendKeyPress('-');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('=');

            Assert.Equal("66", result);
        }

        [Fact]
        public void Test_when_UserEntersMultiplicationSign_should_ReturnCorrectAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('8');
            result = c.SendKeyPress('x');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('=');

            Assert.Equal("1936", result);
        }

        [Fact]
        public void Test_when_UserEntersDivisionOperation_should_ReturnFloatAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('8');
            result = c.SendKeyPress('/');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('1');
            result = c.SendKeyPress('=');

            Assert.Equal("4.190476", result);
        }

        [Fact]
        public void Test_when_UserEntersFloatingNumbers_should_ReturnFloatAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('1');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('x');
            result = c.SendKeyPress('1');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('9');
            result = c.SendKeyPress('=');

            Assert.Equal("15.39", result);
        }


        [Fact]
        public void Test_when_UserTogglesSignOfFirstNumber_should_ReturnCorrectAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('s');
            result = c.SendKeyPress('+');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('=');

            Assert.Equal("-6", result);
        }

        [Fact]
        public void Test_when_UserTogglesSignOfSecondNumber_should_ReturnCorrectAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('x');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('s');
            result = c.SendKeyPress('=');

            Assert.Equal("-16", result);
        }

        [Fact]
        public void Test_when_UserTogglesSignOfBothNumber_should_ReturnCorrectAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('s');
            result = c.SendKeyPress('+');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('8');
            result = c.SendKeyPress('s');
            result = c.SendKeyPress('=');

            Assert.Equal("-11", result);
        }

        [Fact]
        public void Test_when_UserTogglesMultipleTimes_should_ReturnCorrectAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('+');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('8');
            result = c.SendKeyPress('s');
            result = c.SendKeyPress('s');
            result = c.SendKeyPress('=');

            Assert.Equal("11", result);
        }

        [Fact]
        public void Test_when_UserEntersCSign_should_ReturnToDefaultState()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('1');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('x');
            result = c.SendKeyPress('1');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('9');
            result = c.SendKeyPress('=');
            result = c.SendKeyPress('c');

            Assert.Equal("0", result);
        }

        [Fact]
        public void Test_when_UserEntersInvalidValues_should_ReturnErrorCode()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('b');

            Assert.Equal("-E-", result);
        }

        [Fact]
        public void Test_when_UserDividesByZero_should_ReturnErrorCode()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('/');
            result = c.SendKeyPress('0');
            result = c.SendKeyPress('=');

            Assert.Equal("-E-", result);
        }
        [Fact]
        public void Test_when_UserEntersMultipleDecimals_should_ReturnNumberItself()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('8');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('.');

            Assert.Equal("8.2", result);
        }

        [Fact]
        public void Test_when_UserEntersLeadingZeros_should_ReturnNumberWithoutLeadingZeroes()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('0');
            result = c.SendKeyPress('0');
            result = c.SendKeyPress('.');
            result = c.SendKeyPress('0');
            result = c.SendKeyPress('0');
            result = c.SendKeyPress('1');

            Assert.Equal("0.001", result);
        }


        [Fact]
        public void Test_when_UserEntersOnlyEqualSign_should_ReturnDefaultState()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('=');

            Assert.Equal("0", result);
        }

        [Fact]
        public void Test_when_UserEntersEqualSignBeforeEnteringSecondNumber_should_ReturnFirstNumber()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('6');
            result = c.SendKeyPress('+');
            result = c.SendKeyPress('=');

            Assert.Equal("6", result);
        }
        [Fact]
        public void Test_when_UserEntersMultipleOperationsSimultaneously_should_ReturnCorrectAnswer()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('6');
            result = c.SendKeyPress('+');
            result = c.SendKeyPress('9');
            result = c.SendKeyPress('-');
            result = c.SendKeyPress('8');
            result = c.SendKeyPress('+');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('+');

            Assert.Equal("9", result);
        }

        [Fact]
        public void Test_when_UserClearsScreenWhileOperating_should_ReturnDefaultState()
        {
            string result;

            Calculator c = new Calculator();

            result = c.SendKeyPress('6');
            result = c.SendKeyPress('+');
            result = c.SendKeyPress('9');
            result = c.SendKeyPress('-');
            result = c.SendKeyPress('8');
            result = c.SendKeyPress('+');
            result = c.SendKeyPress('2');
            result = c.SendKeyPress('C');

            Assert.Equal("0", result);
        }
    }
}
