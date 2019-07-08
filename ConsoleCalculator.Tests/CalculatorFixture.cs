using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator MyCalculator;
        public CalculatorFixture()
        {
            MyCalculator = new Calculator();
        }
        [Fact]
        public void NumberPressedTest()
        {
            string expectedResult,actualResult;
            expectedResult = "4";
            actualResult=MyCalculator.SendKeyPress('4');
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void ToggleTest()
        {
            string expectedResult, actualResult;
            expectedResult = "-4";
            actualResult = MyCalculator.SendKeyPress('4');
            actualResult = MyCalculator.SendKeyPress('S');
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void AdditionTest()
        {
            string expectedResult, actualResult;
            expectedResult = "9";
            actualResult = MyCalculator.SendKeyPress('4');
            actualResult = MyCalculator.SendKeyPress('+');
            actualResult = MyCalculator.SendKeyPress('5');
            actualResult = MyCalculator.SendKeyPress('=');
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void SubstractionTest()
        {
            string expectedResult, actualResult;
            expectedResult = "4";
            actualResult = MyCalculator.SendKeyPress('9');
            actualResult = MyCalculator.SendKeyPress('-');
            actualResult = MyCalculator.SendKeyPress('5');
            actualResult = MyCalculator.SendKeyPress('=');
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void MultiplicationTest()
        {
            string expectedResult, actualResult;
            expectedResult = "20";
            actualResult = MyCalculator.SendKeyPress('4');
            actualResult = MyCalculator.SendKeyPress('x');
            actualResult = MyCalculator.SendKeyPress('5');
            actualResult = MyCalculator.SendKeyPress('=');
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void DivisionTest()
        {
            string expectedResult, actualResult;
            expectedResult = "2";
            actualResult = MyCalculator.SendKeyPress('4');
            actualResult = MyCalculator.SendKeyPress('/');
            actualResult = MyCalculator.SendKeyPress('2');
            actualResult = MyCalculator.SendKeyPress('=');
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void DecimalDivisionTest()
        {
            string expectedResult, actualResult;
            expectedResult = "0.8";
            actualResult = MyCalculator.SendKeyPress('4');
            actualResult = MyCalculator.SendKeyPress('/');
            actualResult = MyCalculator.SendKeyPress('5');
            actualResult = MyCalculator.SendKeyPress('=');
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ResetTest()
        {
            string expectedResult, actualResult;
            expectedResult = "0";
            actualResult = MyCalculator.SendKeyPress('4');
            actualResult = MyCalculator.SendKeyPress('C');
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Scenario_1()
        {
            string expectedResult, actualResult;
            bool flag1, flag2, flag3, flag4, flag5;

            expectedResult = "1";
            actualResult = MyCalculator.SendKeyPress('1');
            flag1 = expectedResult.Equals(actualResult);

            expectedResult = "10";
            actualResult = MyCalculator.SendKeyPress('0');
            flag2 = expectedResult.Equals(actualResult);

            expectedResult = "10";
            actualResult = MyCalculator.SendKeyPress('+');
            flag3 = expectedResult.Equals(actualResult);

            expectedResult = "2";
            actualResult = MyCalculator.SendKeyPress('2');
            flag4 = expectedResult.Equals(actualResult);

            expectedResult = "12";
            actualResult = MyCalculator.SendKeyPress('=');
            flag5 = expectedResult.Equals(actualResult);

            if (flag1 && flag2 && flag3 && flag4 && flag5)
            {
                return;
            }
            throw new Exception("Didn't pass test");
        }
        [Fact]
        public void Scenario_2()
        {
            string expectedResult, actualResult;
            bool flag1, flag2, flag3, flag4, flag5;

            expectedResult = "1";
            actualResult = MyCalculator.SendKeyPress('1');
            flag1 = expectedResult.Equals(actualResult);

            expectedResult = "10";
            actualResult = MyCalculator.SendKeyPress('0');
            flag2 = expectedResult.Equals(actualResult);

            expectedResult = "10";
            actualResult = MyCalculator.SendKeyPress('/');
            flag3 = expectedResult.Equals(actualResult);

            expectedResult = "0";
            actualResult = MyCalculator.SendKeyPress('0');
            flag4 = expectedResult.Equals(actualResult);

            expectedResult = "-E-";
            actualResult = MyCalculator.SendKeyPress('=');
            flag5 = expectedResult.Equals(actualResult);

            if (flag1 && flag2 && flag3 && flag4 && flag5)
            {
                return;
            }
            throw new Exception("Didn't pass test");
        }
        [Fact]
        public void Scenario_3()
        {
            string expectedResult, actualResult;
            bool flag1, flag2, flag3, flag4, flag5, flag6, flag7;

            expectedResult = "0";
            actualResult = MyCalculator.SendKeyPress('0');
            flag1 = expectedResult.Equals(actualResult);

            expectedResult = "0";
            actualResult = MyCalculator.SendKeyPress('0');
            flag2 = expectedResult.Equals(actualResult);

            expectedResult = "0.";
            actualResult = MyCalculator.SendKeyPress('.');
            flag3 = expectedResult.Equals(actualResult);

            expectedResult = "0.";
            actualResult = MyCalculator.SendKeyPress('.');
            flag4 = expectedResult.Equals(actualResult);

            expectedResult = "0.0";
            actualResult = MyCalculator.SendKeyPress('0');
            flag5 = expectedResult.Equals(actualResult);

            expectedResult = "0.00";
            actualResult = MyCalculator.SendKeyPress('0');
            flag6 = expectedResult.Equals(actualResult);

            expectedResult = "0.001";
            actualResult = MyCalculator.SendKeyPress('1');
            flag7 = expectedResult.Equals(actualResult);

            if (flag1 && flag2 && flag3 && flag4 && flag5 && flag6 && flag7)
            {
                return;
            }
            throw new Exception("Didn't pass test");
        }
        [Fact]
        public void Scenario_4()
        {
            string expectedResult, actualResult;
            bool flag1, flag2, flag3, flag4, flag5, flag6, flag7, flag8;

            expectedResult = "1";
            actualResult = MyCalculator.SendKeyPress('1');
            flag1 = expectedResult.Equals(actualResult);

            expectedResult = "12";
            actualResult = MyCalculator.SendKeyPress('2');
            flag2 = expectedResult.Equals(actualResult);

            expectedResult = "12";
            actualResult = MyCalculator.SendKeyPress('+');
            flag3 = expectedResult.Equals(actualResult);

            expectedResult = "2";
            actualResult = MyCalculator.SendKeyPress('2');
            flag4 = expectedResult.Equals(actualResult);

            expectedResult = "-2";
            actualResult = MyCalculator.SendKeyPress('S');
            flag5 = expectedResult.Equals(actualResult);

            expectedResult = "2";
            actualResult = MyCalculator.SendKeyPress('S');
            flag6 = expectedResult.Equals(actualResult);

            expectedResult = "-2";
            actualResult = MyCalculator.SendKeyPress('S');
            flag7 = expectedResult.Equals(actualResult);

            expectedResult = "10";
            actualResult = MyCalculator.SendKeyPress('=');
            flag8 = expectedResult.Equals(actualResult);

            if (flag1 && flag2 && flag3 && flag4 && flag5 && flag6 && flag7 && flag8)
            {
                return;
            }
            throw new Exception("Didn't pass test");
        }
        [Fact]
        public void Scenario_5()
        {
            string expectedResult, actualResult;
            bool flag1, flag2, flag3, flag4, flag5, flag6, flag7;

            expectedResult = "1";
            actualResult = MyCalculator.SendKeyPress('1');
            flag1 = expectedResult.Equals(actualResult);

            expectedResult = "1";
            actualResult = MyCalculator.SendKeyPress('+');
            flag2 = expectedResult.Equals(actualResult);

            expectedResult = "2";
            actualResult = MyCalculator.SendKeyPress('2');
            flag3 = expectedResult.Equals(actualResult);

            expectedResult = "3";
            actualResult = MyCalculator.SendKeyPress('+');
            flag4 = expectedResult.Equals(actualResult);

            expectedResult = "3";
            actualResult = MyCalculator.SendKeyPress('3');
            flag5 = expectedResult.Equals(actualResult);

            expectedResult = "6";
            actualResult = MyCalculator.SendKeyPress('+');
            flag6 = expectedResult.Equals(actualResult);

            expectedResult = "12";
            actualResult = MyCalculator.SendKeyPress('=');
            flag7 = expectedResult.Equals(actualResult);

            if (flag1 && flag2 && flag3 && flag4 && flag5 && flag6 && flag7)
            {
                return;
            }
            throw new Exception("Didn't pass test");
        }
        [Fact]
        public void Scenario_6()
        {
            string expectedResult, actualResult;
            bool flag1, flag2, flag3, flag4, flag5;

            expectedResult = "1";
            actualResult = MyCalculator.SendKeyPress('1');
            flag1 = expectedResult.Equals(actualResult);

            expectedResult = "1";
            actualResult = MyCalculator.SendKeyPress('+');
            flag2 = expectedResult.Equals(actualResult);

            expectedResult = "2";
            actualResult = MyCalculator.SendKeyPress('2');
            flag3 = expectedResult.Equals(actualResult);

            expectedResult = "3";
            actualResult = MyCalculator.SendKeyPress('+');
            flag4 = expectedResult.Equals(actualResult);

            expectedResult = "0";
            actualResult = MyCalculator.SendKeyPress('C');
            flag5 = expectedResult.Equals(actualResult);

            if (flag1 && flag2 && flag3 && flag4 && flag5)
            {
                return;
            }
            throw new Exception("Didn't pass test");
        }
    }
}
