using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator Calculator = new Calculator();
        string SendMultipleKey(char[] Key)
        {
            int KeyIndex = 0;
            for (KeyIndex = 0; KeyIndex < Key.Length-1; KeyIndex++)
                Calculator.SendKeyPress(Key[KeyIndex]);

            return Calculator.SendKeyPress(Key[KeyIndex]);
        }

        [Fact]
        public void DummyTest()
        {
            return;
        }

        [Fact]
        public void SingleKeyPressTest()
        {
            char Key = '1';
            string Actual = Calculator.SendKeyPress(Key);
            Assert.Equal("1", Actual);
        }

        [Fact]
        public void MultipleKeyPressTest()
        {
            char[] Key = new char[] {'2','3' };
            string Actual = SendMultipleKey(Key);
            Assert.Equal("23", Actual);
        }

        [Fact]
        public void OperatorPressTest()
        {
            char[] Key = new char[] { '6', '3', '+'};
            string Actual = SendMultipleKey(Key);
            Assert.Equal("63", Actual);
        }

        [Fact]
        public void OperatorAndKeyPressTest()
        {
            char[] Key = new char[] { '1', '9', '+', '6'};
            string Actual = SendMultipleKey(Key);
            Assert.Equal("6", Actual);
        }

        [Fact]
        public void AdditionTest()
        {
            char[] Key = new char[] { '1', '9' ,'+', '4', '='};
            string Actual = SendMultipleKey(Key);
            Assert.Equal("23", Actual);
        }

        [Fact]
        public void SubtractionTest()
        {
            char[] Key = new char[] { '1', '9', '-', '4', '=' };
            string Actual = SendMultipleKey(Key);
            Assert.Equal("15", Actual);
        }

        [Fact]
        public void MultiplicationTest()
        {
            char[] Key = new char[] { '1', '9', 'x', '4', '=' };
            string Actual = SendMultipleKey(Key);
            Assert.Equal("76", Actual);
        }

        [Fact]
        public void DivsionTest()
        {
            char[] Key = new char[] { '1', '6', '/', '4', '=' };
            string Actual = SendMultipleKey(Key);
            Assert.Equal("4", Actual);
        }

        [Fact]
        public void DivisionByZeroTest()
        {
            char[] Key = new char[] { '1', '/', '0', '=' };
            string Actual = SendMultipleKey(Key);
            Assert.Equal("-E-", Actual);
        }

        [Fact]
        public void SignToggleTest()
        {
            char[] Key = new char[] { '1', '2', '+', '2', 'S', 's', 'S', '=' };
            string Actual = SendMultipleKey(Key);
            Assert.Equal("10", Actual);
        }

        [Fact]
        public void ResetKeyPressedTest()
        {
            char[] Key = new char[] { '1', '+', '2', 'C',};
            string Actual = SendMultipleKey(Key);
            Assert.Equal("0", Actual);
        }

        [Fact]
        public void AggregateCalculationTest()
        {
            char[] Key = new char[] { '1', '+', '2', '+', '3', '+', '=' };
            string Actual = SendMultipleKey(Key);
            Assert.Equal("12", Actual);
        }

        [Fact]
        public void MultipleZeroAndDecimalPointTest()
        {
            char[] Key = new char[] { '0', '0', '.', '.', '0', '0', '1'};
            string Actual = SendMultipleKey(Key);
            Assert.Equal("0.001", Actual);
        }
    }
}
