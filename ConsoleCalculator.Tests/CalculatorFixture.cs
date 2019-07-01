using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
          [Fact]
        public void NumberTest()
        {
            var Cal = new Calculator();
            Cal.SendKeyPress('1');
            Cal.SendKeyPress('.');
            Cal.SendKeyPress('2');
            Cal.SendKeyPress('3');
            Cal.SendKeyPress('s');
            string result = Cal.SendKeyPress('*');
            Assert.Equal("-1.23", result);
            return;
        }
        [Fact]
        public void DivisionTest()
        {
            var Cal = new Calculator();
            Cal.SendKeyPress('1');
            Cal.SendKeyPress('3');
            Cal.SendKeyPress('s');
            Cal.SendKeyPress('/');
            Cal.SendKeyPress('2');
            string result = Cal.SendKeyPress('=');
            Assert.Equal("-6.5", result);
            return;
        }
        [Fact]
        public void MultiplicationTest()
        {
            var Cal = new Calculator();
            Cal.SendKeyPress('1');
            Cal.SendKeyPress('.');
            Cal.SendKeyPress('3');
            Cal.SendKeyPress('s');
            Cal.SendKeyPress('*');
            Cal.SendKeyPress('2');
            string result = Cal.SendKeyPress('=');
            Assert.Equal("-2.6", result);
            return;
        }
        [Fact]
        public void AdditionTest()
        {
            var Cal = new Calculator();
            Cal.SendKeyPress('1');
            Cal.SendKeyPress('1');
            Cal.SendKeyPress('2');
            Cal.SendKeyPress('3');
            Cal.SendKeyPress('+');
            Cal.SendKeyPress('2');
            string result = Cal.SendKeyPress('=');
            Assert.Equal("1125", result);
            return;
        }
        [Fact]
        public void SubstractionTest()
        {
            var Cal = new Calculator();
            Cal.SendKeyPress('1');
            Cal.SendKeyPress('.');
            Cal.SendKeyPress('2');
            Cal.SendKeyPress('3');
            Cal.SendKeyPress('s');
            Cal.SendKeyPress('-');
            Cal.SendKeyPress('2');
            string result = Cal.SendKeyPress('=');
            Assert.Equal("-3.23", result);
            return;
        }
        [Fact]
        public void ClearTest()
        {
            var Cal = new Calculator();
            Cal.SendKeyPress('1');
            Cal.SendKeyPress('.');
            Cal.SendKeyPress('2');
            Cal.SendKeyPress('3');
            Cal.SendKeyPress('c');
            string result = Cal.SendKeyPress('*');
            Assert.Equal("0", result);
            return;
        }

        [Fact]
        public void SwapTest()
        {
            var Cal = new Calculator();
            Cal.SendKeyPress('2');
            Cal.SendKeyPress('3');
            Cal.SendKeyPress('s');
            string result = Cal.SendKeyPress('*');
            Assert.Equal("-23", result);
            return;
        }
        [Fact]
        public void ErrorTest()
        {
            var Cal = new Calculator();
            Cal.SendKeyPress('2');
            Cal.SendKeyPress('3');
            Cal.SendKeyPress('/');
            Cal.SendKeyPress('0');
            string result = Cal.SendKeyPress('=');
            Assert.Equal("-E-", result);
            return;
        }
    }
}
