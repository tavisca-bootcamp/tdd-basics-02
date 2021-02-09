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
        public void KeyCTest()
        {
            string temp = "1234C";
            var cc = new Calculator();
            string result=string.Empty;
            for(int i=0;i<temp.Length;i++)
            {
                result = cc.SendKeyPress(temp[i]);
            }
            Assert.Equal("0", result);


        }
        [Fact]
        public void multpleZeroTest()
        {
            string temp = "00000000";
            var cc = new Calculator();
            string result = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                result = cc.SendKeyPress(temp[i]);
            }
            Assert.Equal("0", result);
        }
        [Fact]
        public void negativeSignTest()
        {
            string temp = "2s";
            var cc = new Calculator();
            string result = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                result = cc.SendKeyPress(temp[i]);
            }
            Assert.Equal("-2", result);
        }
        [Fact]
        public void checkingDivedbyZeroTest()
        {
            string temp = "12/0=";
            var cc = new Calculator();
            string result = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                result = cc.SendKeyPress(temp[i]);
            }
            Assert.Equal("-E-", result);
        }
        [Fact]
        public void simpleExpressionTest()
        {
            string temp = "12+2=";
            var cc = new Calculator();
            string result = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                result = cc.SendKeyPress(temp[i]);
            }
            Assert.Equal("14", result);
        }
        [Fact]
        public void LargeExpresionTest()
        {
            string temp = "1+2+3+6=";
            var cc = new Calculator();
            string result = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                result = cc.SendKeyPress(temp[i]);
            }
            Assert.Equal("12", result);
        }
    }
}
