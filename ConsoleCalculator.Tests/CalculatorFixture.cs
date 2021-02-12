using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calObject;
        public CalculatorFixture()
        {
            calObject = new Calculator(); //assigning memory to the calObject
        }

        [Fact]
        public void NumbersCheck()
        {
            string input = "1456923";     //to test valid keys
            string OutputExpected = "1456923";
            string Output = CallCalculatorFun(input); 
            Assert.Equal(Output, OutputExpected);
        }
        [Fact]
        public void NumbersValidOrNotCheck()
        {
            string input = "14+@"; //to test valid keys(z,t are invalid)
            string OutputExpected = "0";
            string Output = CallCalculatorFun(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void DecimalCheck()
        {
            string input = "0.....004";
            string OutputExpected = "0.004";
            string Output = CallCalculatorFun(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void DoubleDecimalCheck()
        {
            string input = "0.....0...9"; // decimals presses after once should be ignored like real life calc.
            string OutputExpected = "0.09";
            string Output = CallCalculatorFun(input);
            Assert.Equal(Output, OutputExpected);
        }
        [Fact]
        public void DoubleDeciCheck()
        {
            string input = "0.....000...9"; // decimals presses after once should be ignored like real life calc.
            string OutputExpected = "0.0009";
            string Output = CallCalculatorFun(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void DivideByZeroErrorCheck()
        {
            string input = "10/0=";
            string OutputExpected = "-E-";
            string Output = CallCalculatorFun(input);
            Assert.Equal(Output, OutputExpected);
        }
        [Fact]
        public void MultiplicationTestCheck()
        {
            string input = "40x20x10=";
            string OutputExpected = "8000";
            string Output = CallCalculatorFun(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void PositiveSubtractionTestCheck()
        {
            string input = "450-400=";
            string OutputExpected = "50";
            string Output = CallCalculatorFun(input);
            Assert.Equal(Output, OutputExpected);
        }
        [Fact]
        public void NegativeSubtractionTestCheck()
        {
            string input = "400-450=";
            string OutputExpected = "-50";
            string Output = CallCalculatorFun(input);
            Assert.Equal(Output, OutputExpected);
        }

        
        [Fact]
        public void AdditionTestCheck()
        {
            string input = "10+2=";
            string OutputExpected = "12";
            string Output = CallCalculatorFun(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void TogglingCheck()
        {
            string input = "1SsSsS";
            string OutputExpected = "-1";
            string Output = CallCalculatorFun(input);
            Assert.Equal(Output, OutputExpected);
        }

        [Fact]
        public void CharacterKeyCheck()
        {
            string input = "$";
            string OutputExpected = "0";
            string Output = CallCalculatorFun(input);
            Assert.Equal(Output, OutputExpected);
        }

    
        public string CallCalculatorFun(string input)
        { 
            //SendKeyPress function has char type parameter and output return is string
            //so convert input into char array
            char[] arr = input.ToCharArray();
            string output = "";
            for (int i = 0; i < arr.Length; i++)
            {
                output = calObject.SendKeyPress(arr[i]);
            }
            return output;
        }
    }
}