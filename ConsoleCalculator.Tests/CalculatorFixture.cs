
    
using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void ShouldAddTwoNumbers()
        {
            string equation = "10+2=";
            string expected = "12";


            string actual = ProcessString(equation);
            

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldHandleDivideByZero_returnBusinessLogic()
        {
            string equation = "10/0=";
            string expected = "-E-";


            string actual = ProcessString(equation);
           

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RedundantZeroShouldBeRemoved()
        {
            string equation = "00..001";
            string expected = "0.001";


            string actual = ProcessString(equation);
           

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldHandleToggleCondtion()
        {
            string equation = "12+2sSs=";
            string expected = "10";

            string actual = ProcessString(equation);
            

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PropertyOfEqualSignTest()
        {
            string equation = "1+2+3+=";
            string expected = "12";

            string actual = ProcessString(equation);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClearConditionTest()
        {
            string equation = "1+2+C";
            string expected = "0";


            string actual = ProcessString(equation);
            

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultiplicationSignTest()
        {
            string equation = "5x2X7=";
            string expected = "70";


            string actual = ProcessString(equation);
            

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IgnoreInputsOtherThanValidDigitsAndOperators()
        {
            string equation = "1aidb5+2tbjd#$@0 - 5=";
            string expected = "30";

            actual = ProcessString(equation);            

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldIgnoreRedundantDecimals()
        {
            string equation = "7..1 + 10...2 = ";
            string expected = "17.3";


            string actual = ProcessString(equation);
            

            Assert.Equal(expected, actual);
        }
        
        public string ProcessString(string equation)
        {
            Calculator calc = new Calculator();
            string output = "";
            foreach (char ch in equation)
            {
                output = calc.SendKeyPress(ch);
            }
            return output;
        }
    }
}
