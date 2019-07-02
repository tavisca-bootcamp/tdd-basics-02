using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact] 
        public void TestAddTwoNumbers()
        {
            string equation = "10+2=";
            Assert.Equal("12", ComputeEquation(equation));
        }

        [Fact]
        public void TestDivideByZeroException()
        {
            string equation = "10/0=";
            Assert.Equal("-E-", ComputeEquation(equation));
        }

        [Fact]
        public void TestHandlingOfMultipleZeros()
        {
            string equation = "000.001";
            Assert.Equal("0.001", ComputeEquation(equation));
        }

        [Fact]
        public void TestHandlingSignToggle()
        {
            string equation = "12+2sSs=";
            Assert.Equal("10", ComputeEquation(equation));
        }

        [Fact]
        public void TestPropertyOfEqualityOperator()
        {
            string equation = "1+2+3+=";
            Assert.Equal("12", ComputeEquation(equation));
        }

        [Fact]
        public void TestResetCondition()
        {
            string equation = "1+2+C";
            Assert.Equal("0", ComputeEquation(equation));
        }

        [Fact]
        public void TestMultiplicationOperation()
        {
            string equation = "5x2X7=";
            Assert.Equal("70", ComputeEquation(equation));
        }

        [Fact] 
        public void TestHandlingInvalidInputs()
        {
            string equation = "1aidb5+2tbjd#$@0 - 5=";
            Assert.Equal("30", ComputeEquation(equation));
        }

        [Fact]
        public void TestHandlingMultipleDecimals()
        {
            string equation = "7..1 + 10...2 = ";
            Assert.Equal("17.3", ComputeEquation(equation));
        }

        public string ComputeEquation(string equation)
        {
            Calculator calculator = new Calculator();
            string observedResultOnDisplay = "";
            int lengthOfEquation = equation.Length;
            for(int i=0;i<lengthOfEquation;i++)
            {
                observedResultOnDisplay = calculator.SendKeyPress(equation[i]);
            }
            return observedResultOnDisplay;
        }       
    }
}
