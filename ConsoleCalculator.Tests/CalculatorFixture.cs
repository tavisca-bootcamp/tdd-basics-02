using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator = new Calculator();
        
        [Fact]
        public void DummyTest()
        {
            return;
        }

        [Fact]
        public void TestOperand()
        {
            calculator.SendKeyPress('1');
            Assert.Equal("15", calculator.SendKeyPress('5'));
            return;

        }

        [Fact]
        public void TestOperator()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('5');
            Assert.Equal("6", calculator.SendKeyPress('='));
            Assert.Equal("0", calculator.SendKeyPress('c'));            
        }


        [Fact]
        public void TestOperationAdd()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('5');
            Assert.Equal("15", calculator.SendKeyPress('='));
            calculator.SendKeyPress('c');
        }

        [Fact]
        public void TestOperationSubtract()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('-');
            calculator.SendKeyPress('5');
            Assert.Equal("5", calculator.SendKeyPress('='));
            calculator.SendKeyPress('c');
            
        }

        [Fact]
        public void TestOperationMultiply()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('x');
            calculator.SendKeyPress('5');
            Assert.Equal("50", calculator.SendKeyPress('='));
            calculator.SendKeyPress('c');
        }

        [Fact]
        public void TestOperationDivide()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('/');
            calculator.SendKeyPress('5');
            Assert.Equal("2", calculator.SendKeyPress('='));
            calculator.SendKeyPress('c');
        }

        [Fact]
        public void TestOperationDivideByZero()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('/');
            calculator.SendKeyPress('0');
            Assert.Equal("-E-", calculator.SendKeyPress('='));
            calculator.SendKeyPress('c');
        }

        [Fact]
        public void TestInvalidKey()
        {            
            Assert.Equal("-E-", calculator.SendKeyPress('o'));
            calculator.SendKeyPress('c');
            Assert.Equal("0", calculator.SendKeyPress('0'));
            calculator.SendKeyPress('c');
        }


        [Fact]
        public void TestDecimalFirstOperand()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('.');
            calculator.SendKeyPress('5');
            Assert.Equal("10.50", calculator.SendKeyPress('0'));
            calculator.SendKeyPress('c');
        }

        [Fact]
        public void TestDecimalSecondOperand()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('5');
            calculator.SendKeyPress('.');
            calculator.SendKeyPress('8');
            Assert.Equal("6.8", calculator.SendKeyPress('='));
            calculator.SendKeyPress('c');
        }

        [Fact]
        public void TestToggleSign()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('5');
            calculator.SendKeyPress('s');           
            Assert.Equal("5", calculator.SendKeyPress('='));
            calculator.SendKeyPress('c');
        }

        /*[Fact]
        public void FailTestOperand()
        {
            calculator.SendKeyPress('1');
            Assert.Equal("5", calculator.SendKeyPress('5'));
            return;

        }
        

        [Fact]
        public void FailTestOperator()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('5');
            Assert.Equal("5", calculator.SendKeyPress('='));
            Assert.Equal("0", calculator.SendKeyPress('c'));
        }
                
        [Fact]
        public void FailTestInvalidKey()
        {
            Assert.Equal("o", calculator.SendKeyPress('o'));
            calculator.SendKeyPress('c');
            Assert.Equal("0", calculator.SendKeyPress('0'));
            calculator.SendKeyPress('c');
        }      
      */          
    }
}

