using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {

        [Fact]
        public void testResetOperation()
        {
            Assert.Equal("0", extractCharactersFromEquation("C"));
        }

        [Fact]
        public void testToggleOperation()
        {
            Assert.Equal("-45", extractCharactersFromEquation("45S"));
        }

        [Fact]
        public void testDivideByZero()
        {
            Assert.Equal("-E-", extractCharactersFromEquation("45/0="));
        }

        [Fact]
        public void testAllNumbers()
        {
            Assert.Equal("123456789", extractCharactersFromEquation("123456789"));
        }

        [Fact]
        public void testEachOperator()
        {
            Assert.Equal("10",extractCharactersFromEquation("9+1="));
            Assert.Equal("8", extractCharactersFromEquation("9-1="));
            Assert.Equal("9", extractCharactersFromEquation("9x1="));
            Assert.Equal("3", extractCharactersFromEquation("9/3="));
        }


        [Fact]
        public void testMoreThanOneOperationinEquaton()
        {
            Assert.Equal("20", extractCharactersFromEquation("123-120x5+5="));
        }

        [Fact]
        public void testDecimalOperations()
        {
            Assert.Equal("19.9", extractCharactersFromEquation("10.5+9.4="));
            Assert.Equal("0.7", extractCharactersFromEquation("3.4-2.7="));
            Assert.Equal("2", extractCharactersFromEquation("2.5x0.8="));
            Assert.Equal("2", extractCharactersFromEquation("3.4/1.7="));
        }

        [Fact]
        public void testOperationsForDecimalAndNonDecimalNumbers()
        {
            Assert.Equal("19.7", extractCharactersFromEquation("5x2+9.7="));
            Assert.Equal("10.7", extractCharactersFromEquation("0.5x2+9.7="));
            Assert.Equal("5", extractCharactersFromEquation("5+95/20.0="));
        }

        [Fact]
        public void testForMultipleToggle()
        {
            Assert.Equal("2", extractCharactersFromEquation("2SS"));
            Assert.Equal("-2", extractCharactersFromEquation("10+2SSS"));
        }

        private string extractCharactersFromEquation(string equation)
        {
            Calculator obj = new Calculator();
            string result = "";
            foreach (char ch in equation)
                result = obj.SendKeyPress(ch);

            return result;
        }
    }
}
