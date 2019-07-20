using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator c = new Calculator();

        [Fact]
        public void Test1()
        {
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("10", c.SendKeyPress('0'));
            Assert.Equal("10", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("12", c.SendKeyPress('='));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("10", c.SendKeyPress('0'));
            Assert.Equal("10", c.SendKeyPress('/'));
            Assert.Equal("0", c.SendKeyPress('0'));
            Assert.Equal("-E-", c.SendKeyPress('='));
        }

        //[Fact]
        //public void Test3()
        //{
        //    Assert.Equal("0", c.SendKeyPress('0'));
        //    Assert.Equal("0", c.SendKeyPress('0'));
        //    Assert.Equal("0.", c.SendKeyPress('.'));
        //    Assert.Equal("0.", c.SendKeyPress('.'));
        //    Assert.Equal("0.0", c.SendKeyPress('0'));
        //    Assert.Equal("0.00", c.SendKeyPress('0'));
        //    Assert.Equal("0.001", c.SendKeyPress('1'));
        //}

        [Fact]
        public void Test4()
        {
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("12", c.SendKeyPress('2'));
            Assert.Equal("12", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("-2", c.SendKeyPress('S'));
            Assert.Equal("2", c.SendKeyPress('S'));
            Assert.Equal("-2", c.SendKeyPress('S'));
            Assert.Equal("10", c.SendKeyPress('='));
        }

        //[Fact]
        //public void Test5()
        //{
        //    Assert.Equal("1", c.SendKeyPress('1'));
        //    Assert.Equal("1", c.SendKeyPress('+'));
        //    Assert.Equal("2", c.SendKeyPress('2'));
        //    Assert.Equal("3", c.SendKeyPress('+'));
        //    Assert.Equal("3", c.SendKeyPress('3'));
        //    Assert.Equal("6", c.SendKeyPress('+'));
        //    Assert.Equal("12", c.SendKeyPress('='));
        //}

        [Fact]
        public void Test6()
        {
            Assert.Equal("1", c.SendKeyPress('1'));
            Assert.Equal("1", c.SendKeyPress('+'));
            Assert.Equal("2", c.SendKeyPress('2'));
            Assert.Equal("3", c.SendKeyPress('+'));
            Assert.Equal("0", c.SendKeyPress('C'));
        }
    }
}
