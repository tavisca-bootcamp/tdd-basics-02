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
            string keysPressed = "10+2=";

            string result = FeedKeysAndGetResult(keysPressed);
            Assert.Equal("12", result);
        }

        [Fact]
        public void ErrorScenario() {
            string keysPressed = "10/0=";

            string result = FeedKeysAndGetResult(keysPressed);
            Assert.Equal("-E-", result);
        }

        [Fact]
        public void MultipleZeroesAndDecimal() {
            string keysPressed = "00.001";

            string result = FeedKeysAndGetResult(keysPressed);
            Assert.Equal("0.001", result);
        }

        [Fact]
        public void ChainingOperations() {
            string keysPressed = "1+2+3+=";

            string result = FeedKeysAndGetResult(keysPressed);
            Assert.Equal("12", result);
        }

        [Fact]
        public void SignToggling() {
            string keysPressed = "12+2sss=";

            string result = FeedKeysAndGetResult(keysPressed);
            Assert.Equal("10", result);
        }

        [Fact]
        public void CheckForClearScreen() {
            string keysPressed = "1+2+C";

            string result = FeedKeysAndGetResult(keysPressed);
            Assert.Equal("0", result);
        }

        public string FeedKeysAndGetResult(string s) {
            string result = "";
            foreach(char key in s) {
                result = calculator.SendKeyPress(key);
            }
            return result;
        }
    }
}
