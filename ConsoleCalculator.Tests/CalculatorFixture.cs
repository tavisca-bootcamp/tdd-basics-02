using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void SuccessfullArithmeticOperationTest()
        {
            string equation;
            string actual;
            string expected;

            equation = "10+2=";
            actual = utilityFuntionToProcessOperandsEquation(equation);
            expected = "12";

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void ErrorConditionTest()
        {
            string equation;
            string actual;
            string expected;

            equation = "10/0=";
            actual = utilityFuntionToProcessOperandsEquation(equation);
            expected = "-E-";

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void ZerosConditionsTest()
        {
            string equation;
            string actual;
            string expected;

            equation = "00..001";
            actual = utilityFuntionToProcessOperandsEquation(equation);
            expected = "0.001";

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void ToggleConditionTest()
        {
            string equation;
            string actual;
            string expected;

            equation = "12+2sSs=";
            actual = utilityFuntionToProcessOperandsEquation(equation);
            expected = "10";

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void PropertyOfEqualSignTest()
        {
            string equation;
            string actual;
            string expected;

            equation = "1+2+3+=";
            actual = utilityFuntionToProcessOperandsEquation(equation);
            expected = "12";

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void ClearConditionTest()
        {
            string equation;
            string actual;
            string expected;

            equation = "1+2+C";
            actual = utilityFuntionToProcessOperandsEquation(equation);
            expected = "0";

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void MultiplicationSignTest()
        {
            string equation;
            string actual;
            string expected;

            equation = "5x2X7=";
            actual = utilityFuntionToProcessOperandsEquation(equation);
            expected = "70";

            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void IgnoreInputsOtherThanValidDigitsAndOperators()
        {
            string equation;
            string actual;
            string expected;

            equation = "1aidb5+2tbjd#$@0 - 5=";
            actual = utilityFuntionToProcessOperandsEquation(equation);
            expected = "30";

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void CheckDecimalPointWorkingTest()
        {
            string equation;
            string actual;
            string expected;

            equation = "7..1 + 10...2 = ";
            actual = utilityFuntionToProcessOperandsEquation(equation);
            expected = "17.3";

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void DefaultValueOfCalculatorTest()
        {
            string equation;
            string actual;
            string expected;

            equation = " ";
            actual = utilityFuntionToProcessOperandsEquation(equation);
            expected = "0";

            Assert.Equal(expected,actual);
        }

        /*
            Utility funtion to process operands equation in a string format.
        */

        public string utilityFuntionToProcessOperandsEquation(string equation){
            Calculator calc = new Calculator();
            string output = "";
            foreach(char ch in equation){
                output = calc.SendKeyPress(ch);
            }
            return output;
        }
    }
}
