using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void Test1()
        {
            Calculator.SendKeyPress('C');
            Calculator.SendKeyPress('1');
            Calculator.SendKeyPress('0');
            Calculator.SendKeyPress('+');
            Calculator.SendKeyPress('2');
            Assert.Equal("12", Calculator.SendKeyPress('='));


        }

        [Fact]
        public void Test2()
        {
         
            Calculator.SendKeyPress('1');
            Calculator.SendKeyPress('0');
            Calculator.SendKeyPress('/');
            Calculator.SendKeyPress('0');
            Assert.Equal("-E-",Calculator.SendKeyPress('='));
        }

        [Fact]
        public void Test3()
        {
            Calculator.SendKeyPress('C');
            Calculator.SendKeyPress('0');
            Calculator.SendKeyPress('0');
            Calculator.SendKeyPress('.');
            Calculator.SendKeyPress('.');
            Calculator.SendKeyPress('0');
            Calculator.SendKeyPress('0');    
            Assert.Equal("0.001", Calculator.SendKeyPress('1'));
        }

        [Fact]
        public void Test4()
        {
            Calculator.SendKeyPress('C');
            Calculator.SendKeyPress('1');
            Calculator.SendKeyPress('2');
            Calculator.SendKeyPress('+');
            Calculator.SendKeyPress('2');
            Calculator.SendKeyPress('S');
            Calculator.SendKeyPress('s');
            Calculator.SendKeyPress('S');
            Assert.Equal("10", Calculator.SendKeyPress('='));
        }

        [Fact]
        public void Test5()
        {
            Calculator.SendKeyPress('C');
            Calculator.SendKeyPress('1');
            Calculator.SendKeyPress('+');
            Calculator.SendKeyPress('2');
            Calculator.SendKeyPress('+');
            Calculator.SendKeyPress('3');
            Calculator.SendKeyPress('+');
            Assert.Equal("12", Calculator.SendKeyPress('='));
        }

        [Fact]
        public void Test6()
        {
            Calculator.SendKeyPress('C');
            Calculator.SendKeyPress('1');
            Calculator.SendKeyPress('+');
            Calculator.SendKeyPress('2');
            Calculator.SendKeyPress('+');
            Assert.Equal("0", Calculator.SendKeyPress('c'));
        }
    }
}
