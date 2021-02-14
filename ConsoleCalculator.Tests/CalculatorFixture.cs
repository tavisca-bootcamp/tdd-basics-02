using System;
using Xunit;
namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator = new Calculator();

       

        [Fact]
        public void TestOperationAdd()
        {
            string Test = "20+30=";
            string expected = "";

            for (int i = 0; i < Test.Length; i++)
            {
                expected = calculator.SendKeyPress(Test[i]);

            }
            Assert.Equal("50", expected);
        }

        [Fact]
        public void TestOperationSubtract()
        {
            string Test = "54-27=";
            string expected = "";           

            for (int i=0;i<Test.Length;i++)
            {
                expected = calculator.SendKeyPress(Test[i]);
                
            }
            Assert.Equal("27", expected);
            
        }

        [Fact]
        public void TestOperationMultiply()
        {
            string Test = "20x30=";
            string expected = "";

            for (int i = 0; i < Test.Length; i++)
            {
                expected = calculator.SendKeyPress(Test[i]);

            }
            Assert.Equal("600", expected);
        }

        [Fact]
        public void TestOperationDivide()
        {
            string Test = "60/10=";
            string expected = "";

            for (int i = 0; i < Test.Length; i++)
            {
                expected = calculator.SendKeyPress(Test[i]);

            }
            Assert.Equal("6", expected);
        }

        [Fact]
        public void TestOperationDivideByZero()
        {
            string Test = "40/0=";
            string expected = "";

            for (int i = 0; i < Test.Length; i++)
            {
                expected = calculator.SendKeyPress(Test[i]);

            }
            Assert.Equal("-E-", expected);
        }

        [Fact]
        public void TestDecimal()
        {
            string Test = "2.3+3.7=";
            string expected = "";

            for (int i = 0; i < Test.Length; i++)
            {
                expected = calculator.SendKeyPress(Test[i]);

            }
            Assert.Equal("6", expected);
        }

        [Fact]
        public void TestToggle()
        {
            string Test = "25+5s=";
            string expected = "";

            for (int i = 0; i < Test.Length; i++)
            {
                expected = calculator.SendKeyPress(Test[i]);

            }
            Assert.Equal("20", expected);
        }
    }
}
