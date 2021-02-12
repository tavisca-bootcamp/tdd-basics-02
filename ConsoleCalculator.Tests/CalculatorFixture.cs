using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calc = new Calculator();

        //test for addition
        [Fact]
        public void Add()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('0');
            calc.SendKeyPress('+');
            calc.SendKeyPress('2');
            string temp = calc.SendKeyPress('=');
            Assert.Equal("12", temp);
        }
        
        //test for division
        [Fact]
        public void Divide()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('0');
            calc.SendKeyPress('/');
            calc.SendKeyPress('0');
            string temp = calc.SendKeyPress('=');
            Assert.Equal("E", temp);
        }

        //test for using dot operator
        [Fact]
        public void DotOperator()
        {
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            calc.SendKeyPress('.');
            calc.SendKeyPress('.');
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            string temp = calc.SendKeyPress('1');
            Assert.Equal("00.001", temp);
        }

        //test for using s operator
        [Fact]
        public void SOperator()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('2');
            calc.SendKeyPress('+');
            calc.SendKeyPress('2');
            calc.SendKeyPress('S');
            calc.SendKeyPress('S');
            calc.SendKeyPress('S');
            string temp = calc.SendKeyPress('=');
            Assert.Equal("10", temp);
        }

        //test to check multiple addition
        [Fact]
        public void MultipleAddition()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('+');
            calc.SendKeyPress('2');
            calc.SendKeyPress('+');
            calc.SendKeyPress('3');
            calc.SendKeyPress('+');
           calc.SendKeyPress('6');
            string temp = calc.SendKeyPress('=');
            Assert.Equal("12", temp);
        }

        //test to check c operator
        [Fact]
        public void COperator()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('+');
            calc.SendKeyPress('2');
            calc.SendKeyPress('+');
            string temp = calc.SendKeyPress('C');
            Assert.Equal("0", temp);
        }
    }
}
