using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        public Calculator calculator;

        [Fact]
        public void CheckSingleDigitNumberInput() {
            var result = SendKeyPresses("1");

            Assert.Equal("1", result);
        }

        [Fact]
        public void CheckMultipleDigitNumberInput() {
            var result1 = SendKeyPresses("10");
            var result2 = SendKeyPresses("101325");

            Assert.Equal("10", result1);
            Assert.Equal("101325", result2);
        }

        [Fact]
        public void OperatorPress() {
            var result1 = SendKeyPresses("12+");
            var result2 = SendKeyPresses("12-");
            var result3 = SendKeyPresses("12x");
            var result4 = SendKeyPresses("12X");
            var result5 = SendKeyPresses("12/");

            Assert.Equal("12", result1);
            Assert.Equal("12", result2);
            Assert.Equal("12", result3);
            Assert.Equal("12", result4);
            Assert.Equal("12", result5);
        }

        [Fact] 
        public void InputSecondNumberAfterOperatorPress() {
            var result1 = SendKeyPresses("34+45");
            var result2 = SendKeyPresses("34-45");
            var result3 = SendKeyPresses("34x45");
            var result4 = SendKeyPresses("34/45");

            Assert.Equal("45", result1);
            Assert.Equal("45", result2);
            Assert.Equal("45", result3);
            Assert.Equal("45", result4);
        }

        [Fact]
        public void EvaluateExpression() {
            var result1 = SendKeyPresses("1+2=");
            var result2 = SendKeyPresses("1+2=+1=+1=-1=x4=X2=/4=");

            Assert.Equal("3", result1);
            Assert.Equal("8", result2);
        }

        [Fact]
        public void EvaluateMultipleOperations() {
            string result1 = SendKeyPresses("1+2+3=");
            string result2 = SendKeyPresses("1+2sx9s/3-3ss=");
            string result3 = SendKeyPresses("1-1+1-1+1-1+1-1=");
            string result4 = SendKeyPresses("1+4/5=+2-4+6x10s+50=");

            Assert.Equal("6", result1);
            Assert.Equal("0", result2);
            Assert.Equal("0", result3);
            Assert.Equal("0", result4);
        }

        [Fact]
        public void DifferentAddScenarios() {
            string result1 = SendKeyPresses("1+2+.=");
            string result2 = SendKeyPresses(".+.=");
            string result3 = SendKeyPresses(".+.+.=");
            string result4 = SendKeyPresses("1+2+3+=");

            Assert.Equal("3", result1);
            Assert.Equal("0", result2);
            Assert.Equal("0", result3);
            Assert.Equal("12", result4);
        }

        [Fact]
        public void ErrorScenario() {
            string result1 = SendKeyPresses("10/0=");
            string result2 = SendKeyPresses("0/0=");
            string result3 = SendKeyPresses("1+2=+1=+1=-1=x4=X2=/4=/0=");
            
            Assert.Equal("-E-", result1);
            Assert.Equal("-E-", result2);
            Assert.Equal("-E-", result3);
        }

        [Fact]
        public void OutlierCharacters() {
            string result1 = SendKeyPresses("aaa1aaa+aaa2aaa=");

            Assert.Equal("3", result1);
        }

        [Fact]
        public void CheckForNegativeSign() {
            string result1 = SendKeyPresses("100sss");
            string result2 = SendKeyPresses("10+2s+3=");
            string result3 = SendKeyPresses("12+s9+2ss-4s=");

            Assert.Equal("-100", result1);
            Assert.Equal("11", result2);
            Assert.Equal("9", result3);
        }

        [Fact]
        public void MultipleZeroesAndDecimal() {
            string result1 = SendKeyPresses("00.001");
            string result2 = SendKeyPresses("000100+002s00=");

            Assert.Equal("0.001", result1);
            Assert.Equal("-100", result2);
        }

        public string SendKeyPresses(string s) {
            calculator = new Calculator();
            string res = "";
            foreach (var ch in s) {
                res = calculator.SendKeyPress(ch);
            }
            return res;
        }
    }
}
