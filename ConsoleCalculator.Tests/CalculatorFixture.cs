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
            c = new Program();
            string keys = "2+3+5/5-1=";
            keyPressed(keys);
            Assert.Equal("1", c.getAnswer());
        }
        [Fact]
        public void checkDivideByZero()
        {
            c = new Program();
            string keys = "10/0=";
            keyPressed(keys);
            Assert.Equal("-E-", c.getAnswer());
        }

        [Fact]
        public void ignoringGabage()
        {
            c = new Program();
            string keys = "2+2abde+2="; ;
            keyPressed(keys);
            Assert.Equal("6", c.getAnswer());
        }
        [Fact]
        public void checkMultipleZero()
        {
            c = new Program();
            string keys = "000000="; ;
            keyPressed(keys);
            Assert.Equal("0", c.getAnswer());
        }

        [Fact]
        public void checkDecimal()
        {
            c = new Program();
            string keys = "0.0001+1="; ;
            keyPressed(keys);
            Assert.Equal("1.0001", c.getAnswer());
        }
        [Fact]
        public void checkMultipleSymbol()
        {
            c = new Program();
            string keys = "10/2+-3=";
            keyPressed(keys);
            Assert.Equal("2", c.getAnswer());
        }
        [Fact]
        public void checkClear()
        {
            c = new Program();
            string keys = "10/2+3c=";
            keyPressed(keys);
            Assert.Equal("0", c.getAnswer());
        }

        [Fact]
        public void checkToggle()
        {
            c = new Program();
            string keys = "10/2+3s=";
            keyPressed(keys);
            Assert.Equal("-2", c.getAnswer());
        }

        [Fact]
        public void checkLongEquation()
        {
            c = new Program();
            string keys = "10/5-1+2+3*5=";
            keyPressed(keys);
            Assert.Equal("30", c.getAnswer());
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
