using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture 
    {
        Calculator calc;

        public CalculatorFixture()
        {
            calc = new Calculator();
        }

        [Fact]
        public void DummyTest()
        {
            return;
        }

        [Fact]
        public void DisplaysPressedDigit()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('2');
            calc.SendKeyPress('.');
            string textOnDisplay = calc.SendKeyPress('3');

            Assert.Equal("12.3", textOnDisplay);
        }

        [Fact]
        public void ClearsScreenWhenPressed_c()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('2');

            string textOnDisplay = calc.SendKeyPress('c');

            Assert.Equal("0", textOnDisplay);
        }


        //Example 1
        //Scenario is 10 + 2 = 12.
        [Fact]
        public void CanAddTwoNumbers()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('0');
            calc.SendKeyPress('+');
            calc.SendKeyPress('2');

            string textOnDisplay = calc.SendKeyPress('=');

            Assert.Equal("12", textOnDisplay);
        }

        //Example 2
        //Scenario is 10 / 0 = -E-
        [Fact]
        public void DisplaysErrorBecauseDidideByZero()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('0');
            calc.SendKeyPress('/');
            calc.SendKeyPress('0');

            string textOnDisplay = calc.SendKeyPress('=');

            Assert.Equal("-E-", textOnDisplay);
        }


        //Example 3.1
        [Fact]
        public void MultipleZerosBeforeDecimalAreIgnored()
        {
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            calc.SendKeyPress('.');

            string textOnDisplay = calc.SendKeyPress('0');

            Assert.Equal("0.0", textOnDisplay);
        }

        //Example 3.2
        [Fact]
        public void MultipleDecimalPointsAreIgnored()
        {
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            calc.SendKeyPress('.');
            calc.SendKeyPress('.');
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');

            string textOnDisplay = calc.SendKeyPress('1');

            Assert.Equal("0.001", textOnDisplay);
        }

        //Example 4
        [Fact]
        public void SignCanBeToggledWith_S()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('2');
            calc.SendKeyPress('+');
            calc.SendKeyPress('2');
            calc.SendKeyPress('S');
            calc.SendKeyPress('S');
            calc.SendKeyPress('S');

            string textOnDisplay = calc.SendKeyPress('=');

            Assert.Equal("10", textOnDisplay);
        }

        //Example 5
        [Fact]
        public void CanPerformCalculation()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('+');
            calc.SendKeyPress('2');
            calc.SendKeyPress('+');
            calc.SendKeyPress('3');
            calc.SendKeyPress('+');

            string textOnDisplay = calc.SendKeyPress('=');

            Assert.Equal("12", textOnDisplay);
        }

        //Example 6
        [Fact]
        public void ScreenCanBeClearedWith_C()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('+');
            calc.SendKeyPress('2');
            calc.SendKeyPress('+');

            string textOnDisplay = calc.SendKeyPress('C');

            Assert.Equal("0", textOnDisplay);
        }

    }
}
