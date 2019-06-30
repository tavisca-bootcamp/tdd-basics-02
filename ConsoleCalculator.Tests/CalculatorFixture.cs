using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void DummyTest()
        {
            return;
        }
        [Fact]
        public void TypeOfCalculatorObjectTest()
        {
            Calculator calculator = new Calculator();
            Assert.IsType<Calculator>(calculator);
            
        }
        [Fact]
        public void TestOfInvalidDigitPassedToSendKeyMethod()
        {
            Calculator calculator = new Calculator();
            Assert.Equal("0", calculator.SendKeyPress('f'));
        }
        [Fact]
        public void TestOfWhiteCharPassedToSendKeyMethod()
        {
            Calculator calculator = new Calculator();
            Assert.Equal("0", calculator.SendKeyPress(' '));
        }
        [Fact]
        public void TestOfMoreThanOneDecimalPointOnFirstOperand()
        {
            
            Assert.Equal("7.1", ProcessEquation("7..1"));
        }
        [Fact]
        public void TestOfMoreThanOneDecimalPointOnSecondOperand()
        {
            Assert.Equal("2.3", ProcessEquation("1+1..3="));
        }
        [Fact]
        public void TestOfPerfectEquation()
        {
            Assert.Equal("16", ProcessEquation("5+11="));
        }
        [Fact]
        public void TestOfLeadingZeroOnDecimalPoint()
        {
            Assert.Equal("0.29", ProcessEquation("0..29="));
        }
        [Fact]
        public void TestOfToggleButton()
        {
            Assert.Equal("-5", ProcessEquation("5s"));
        }
        [Fact]
        public void TestOfShortHandOperator()
        {
            Assert.Equal("10", ProcessEquation("5+="));
        }
        [Fact]
        public void TestOfShortHandOperatorPlusEquation()
        {
            Assert.Equal("10", ProcessEquation("2+3+="));
        }
        [Fact]
        public void TestOfResetCalculator()
        {
            Assert.Equal("0", ProcessEquation("2+3+c="));
        }
        [Fact]
        public void TestOfInvalidCharacter()
        {
            Assert.Equal("30", ProcessEquation("1aidb5+2tbjd#$@0 - 5="));
        }
        [Fact]
        public void TestOfDecimalPointWorking()
        {
            Assert.Equal("17.3", ProcessEquation("7..1 + 10...2 = "));
        }
        [Fact]
        public void TestOfDivideByZero()
        {
            Assert.Equal("-E-", ProcessEquation("7/0="));
        }
        [Fact]
        public void TestOfMultiplication()
        {
            Assert.Equal("35", ProcessEquation("7*5="));
        }
        [Fact]
        public void TestOfMultiplicationVariant2()
        {
            Assert.Equal("70", ProcessEquation("7*5*2="));
        }
        [Fact]
        public void TestOfDivison()
        {
            Assert.Equal("25", ProcessEquation("50/2="));
        }
        [Fact]
        public void TestOfMixOperator()
        {
            Assert.Equal("3", ProcessEquation("2+3-2="));
        }
        [Fact]
        public void TestOfMixOperatorVariant2()
        {
            Assert.Equal("3", ProcessEquation("2+3--2="));
        }
        [Fact]
        public void TestOfDivisonVariant2()
        {
            Assert.Equal("1", ProcessEquation("50/2/="));
        }
        public string ProcessEquation(string equation)
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
