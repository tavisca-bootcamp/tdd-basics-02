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
        [Theory]
        [InlineData("0",'1','2','s','*','0','=')]
        [InlineData("1230",'1','2','3','*', '1', '0', '=')]
        [InlineData("-E-",'1','2','3','/','0', '=')]
        [InlineData("1.23", '1', '.', '.', '2', '3', '*', '1', '=')]
        [InlineData("2.23", '1', '.', '.', '2', '3', '*', '+', '1', '=')]
        public void ParameterizedTesting(string result, params char[] keys)
        {
            var Cal = new Calculator();
            string actualresult = "";
            for (int i = 0; i < keys.Length; i++)
            {
                actualresult = Cal.SendKeyPress(keys[i]);
            }
            Assert.Equal(result,actualresult);

        }
    }
}
