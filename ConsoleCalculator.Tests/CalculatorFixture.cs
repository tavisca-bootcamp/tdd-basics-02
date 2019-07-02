using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        public Calculator calculator;
        public CalculatorFixture() {
            calculator = new Calculator();
        }

        [Fact]
        public void AddScenario() {
            string keysPressed1 = "10+2=";
            string keysPressed2 = "1+2+.=";
            string keysPressed3 = ".+.=";
            string keysPressed4 = ".+.+.=";
            string keysPressed5 = "1+2+3+=";

            string result1 = FeedKeysAndGetResult(keysPressed1);
            string result2 = FeedKeysAndGetResult(keysPressed2);
            string result3 = FeedKeysAndGetResult(keysPressed3);
            string result4 = FeedKeysAndGetResult(keysPressed4);
            string result5 = FeedKeysAndGetResult(keysPressed5);

            Assert.Equal("12", result1);
            Assert.Equal("3", result2);
            Assert.Equal("0", result3);
            Assert.Equal("0", result4);
            Assert.Equal("12", result5);
        }

        [Fact]
        public void ErrorScenario() {
            string keysPressed1 = "10/0=";
            string keysPressed2 = "0/0=";

            string result1 = FeedKeysAndGetResult(keysPressed1);
            string result2 = FeedKeysAndGetResult(keysPressed2);
            
            Assert.Equal("-E-", result1);
            Assert.Equal("-E-", result2);
        }

        [Fact]
        public void OutlierCharacters() {
            string keysPressed1 = "aaa1aaa+aaa2aaa=";

            string result1 = FeedKeysAndGetResult(keysPressed1);

            Assert.Equal("3", result1);
        }

        [Fact]
        public void MultipleZeroesAndDecimal() {
            string keysPressed1 = "00.001";
            string keysPressed2 = "000100+002s00=";

            string result1 = FeedKeysAndGetResult(keysPressed1);
            string result2 = FeedKeysAndGetResult(keysPressed2);

            Assert.Equal("0.001", result1);
            Assert.Equal("-100", result2);
        }

        [Fact]
        public void SignToggling() {
            string keysPressed = "12+2sss=";

            string result = FeedKeysAndGetResult(keysPressed);
            Assert.Equal("10", result);
        }

        [Fact] 
        public void MultipleOperations() {
            string keysPressed1 = "1+2sx9s/3-3ss=";
            string keysPressed2 = "1-1+1-1+1-1+1-1=";

            string result1 = FeedKeysAndGetResult(keysPressed1);
            string result2 = FeedKeysAndGetResult(keysPressed2);

            Assert.Equal("0", result1);
            Assert.Equal("0", result2);
        }

        [Fact]
        public void CheckForClearScreen() {
            string keysPressed = "1+2+C";

            string result = FeedKeysAndGetResult(keysPressed);
            Assert.Equal("0", result);
        }

        public string FeedKeysAndGetResult(string s) {
            calculator.SendKeyPress('C');
            string result = "";
            foreach(char key in s) {
                result = calculator.SendKeyPress(key);
            }
            return result;
        }
    }
}
