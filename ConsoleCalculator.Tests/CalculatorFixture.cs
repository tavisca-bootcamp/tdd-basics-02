using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void TestForError()
        {
            string expr = "10/0=";
            string actual = CalculateAnswer(expr);

            Assert.Equal("-E-", actual);
        }
        [Fact]
        public void TestForOnlyOperator()
        {
            string expr = "+";
            string actual = CalculateAnswer(expr);

            Assert.Equal("0", actual);
        }
        [Fact]
        public void TestForOperatorInEnd()
        {
            string expr = "10x2+";
            string actual = CalculateAnswer(expr);

            Assert.Equal("20", actual);
        }

        [Fact]
        public void TestForNull()
        {
            string expr = "  ";
            string actual = CalculateAnswer(expr);

            Assert.Equal("0", actual);
        }


        [Fact]
        public void TestForZeroCondition()
        {
            string expr = "00.001+10=";
            string actual = CalculateAnswer(expr);

            Assert.Equal("10.001", actual);
        }
        [Fact]
        public void TestForMultipleDecimals()
        {
            string expr = "10..001-5=";
            string actual = CalculateAnswer(expr);

            Assert.Equal("5.001", actual);
        }
        [Fact]
        public void TestForMultipleZerosAndDecimalsInGap()
        {
            string expr = "0.0000.00011";
            string actual = CalculateAnswer(expr);

            Assert.Equal("0.000000011", actual);
        }
        [Fact]
        public void TestForMultipleZerosAndDecimalsInContinuous()
        {
            string expr = "00..001";
            string actual = CalculateAnswer(expr);

            Assert.Equal("0.001", actual);
        }
        [Fact]

        public void TestForToggle()
        {
            string expr = "10+20ssS=";
            string actual = CalculateAnswer(expr);

            Assert.Equal("-10", actual);
        }
        [Fact]
        public void TestForClear()
        {
            string expr = "1+2C";
            string actual = CalculateAnswer(expr);

            Assert.Equal("0", actual);
        }
        [Fact]
        public void TestForEqualSignProperty()
        {
            string expr = "1+2+=";
            string actual = CalculateAnswer(expr);

            Assert.Equal("3", actual);

        }
        [Fact]
        public void TestForIgnoringExtraCharacters()
        {
            string expr = "ajbjbw5+jnknd2jd5-5bvf=";
            string actual = CalculateAnswer(expr);

            Assert.Equal("25", actual);
        }
        [Fact]
        public void TestForMultipleOperations()
        {
            string expr = "1+2X3-1/2=";
            string actual = CalculateAnswer(expr);

            Assert.Equal("4", actual);
        }
        [Fact]
        public void TestForAllOperations()
        {
            string expr = "1+2x3-1/2S+3c-4+10=";
            string actual = CalculateAnswer(expr);

            Assert.Equal("6", actual);
        }
        [Fact]
        public void TestForEquationWithoutEqual()
        {
            string expr = "10/0";
            string actual = CalculateAnswer(expr);

            Assert.Equal("0", actual);
        }
        [Fact]
        public void TestForAdditionInDecimals()
        {
            string expr = "10.001+2=";
            string actual = CalculateAnswer(expr);

            Assert.Equal("12.001", actual);
        }
        [Fact]
        public void TestForMinusInFront()
        {
            string expr = "-10+2=";
            string actual = CalculateAnswer(expr);

            Assert.Equal("-8", actual);
        }

        private string CalculateAnswer(string expr)
        {
            Calculator calculator = new Calculator();
            string ans = "";
            foreach (char key in expr)
            {
                ans = calculator.SendKeyPress(key);
            }
            return ans;
        }
    }
}
