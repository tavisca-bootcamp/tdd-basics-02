using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator c = new Calculator();
        [Fact]
        public void DummyTest()
        {

            return;

        }

        [Fact]
        public void TestCase1()
        {
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("10", c.SendKeyPress('0'));
            Assert.Equal("10", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("12", c.SendKeyPress('='));
        }
        [Fact]
        public void TestCase2()
        {
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("10", c.SendKeyPress('0'));
            Assert.Equal("10", c.SendKeyPress('/'));
            Assert.Equal("0", c.SendKeyPress('0'));
            Assert.Equal("--E--", c.SendKeyPress('='));
        }
        [Fact]
        public void TestCase3()
        {
            Assert.Equal("0", c.SendKeyPress('0'));
            Assert.Equal("0", c.SendKeyPress('0'));
            Assert.Equal("0.", c.SendKeyPress('.'));
            Assert.Equal("0.", c.SendKeyPress('.'));
            Assert.Equal("0.1", c.SendKeyPress('1'));

        }
        [Fact]
        public void TestCase4()
        {
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("12", c.SendKeyPress('2'));
            Assert.Equal("12", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("-2", c.SendKeyPress('s'));
            Assert.Equal("2", c.SendKeyPress('s'));
            Assert.Equal("-2", c.SendKeyPress('s'));
            Assert.Equal("10", c.SendKeyPress('='));
        }
        [Fact]
        public void TestCase5()
        {
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("1", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("3", c.SendKeyPress('+'));
            Assert.Equal("3", c.SendKeyPress('3'));
            Assert.Equal("6", c.SendKeyPress('+'));
            Assert.Equal("12", c.SendKeyPress('='));
        }
        [Fact]
        public void TestCase6()
        {
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("1", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("3", c.SendKeyPress('+'));
            Assert.Equal("0", c.SendKeyPress('c'));
            
        }
    }
}
