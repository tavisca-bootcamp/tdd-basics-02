using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator c;

        [Fact]
        public void checkAdd()
        {
            c = new Calculator();
            string keys = "2+3=";
            keyPressed(keys);
            Assert.Equal("5", c.getAnswer());
        }
        [Fact]
        public void checkEquation()
        {
            c = new Calculator();
            string keys = "2+3+5/5-1=";
            keyPressed(keys);
            Assert.Equal("1", c.getAnswer());
        }
        [Fact]
        public void checkDivideByZero()
        {
            c = new Calculator();
            string keys = "10/0=";
            keyPressed(keys);
            Assert.Equal("-E-", c.getAnswer());
        }

        [Fact]
        public void ignoringGabage()
        {
            c = new Calculator();
            string keys = "2+2abde+2="; ;
            keyPressed(keys);
            Assert.Equal("6", c.getAnswer());
        }
        [Fact]
        public void checkMultipleZero()
        {
            c = new Calculator();
            string keys = "000000="; ;
            keyPressed(keys);
            Assert.Equal("0", c.getAnswer());
        }

        [Fact]
        public void checkDecimal()
        {
            c = new Calculator();
            string keys = "0.0001+1="; ;
            keyPressed(keys);
            Assert.Equal("1.0001", c.getAnswer());
        }

        [Fact]
        public void checkMultipleDecimal()
        {
            c = new Calculator();
            string keys = "0....01=";
            keyPressed(keys);
            Assert.Equal("0.01", c.getAnswer());
        }

        [Fact]
        public void checkMultipleSymbol()
        {
            c = new Calculator();
            string keys = "10/2+-3=";
            keyPressed(keys);
            Assert.Equal("2", c.getAnswer());
        }
        [Fact]
        public void checkClear()
        {
            c = new Calculator();
            string keys = "10/2+3c=";
            keyPressed(keys);
            Assert.Equal("0", c.getAnswer());
        }

        [Fact]
        public void checkToggle()
        {
            c = new Calculator();
            string keys = "10/2+3s=";
            keyPressed(keys);
            Assert.Equal("2", c.getAnswer());
        }


        [Fact]
        public void checkToggleWithMultipleDecimal()
        {
            c = new Calculator();
            string keys = "0....112s=";
            keyPressed(keys);
            Assert.Equal("-0.112", c.getAnswer());
        }
        private void keyPressed(string keys)
        {
            foreach (char x in keys)
            {
                c.SendKeyPress(x);
            }
        }
    }
}
