 using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator = new Calculator();
        [Fact]
        public void TestNumberDisplay() {
            string pressedKeys = "3";
            Assert.Equal("3", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestNumberOperatorDisplay() {
            string pressedKeys = "3+";
            Assert.Equal("3", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestNumberOperatorNumberDisplay() {
            string pressedKeys = "83+67";
            Assert.Equal("67", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestMultipleZeroes() {
            string pressedKeys = "000";
            Assert.Equal("0", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestMultipleZeroesBeforeDecimal() {
            string pressedKeys = "00.001";
            Assert.Equal("0.001", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestDecimals() {
            string pressedKeys = "3..5+4.5=";
            Assert.Equal("8", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestMultiplication() {
            string pressedKeys = "10x5=";
            Assert.Equal("50", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestDivision() {
            string pressedKeys = "10/5=";
            Assert.Equal("2", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestError() {
            string pressedKeys = "10/0=";
            Assert.Equal("-E-", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestConsecutiveAdditions() {
            string pressedKeys = "3..5+4..5+12+1..5+0.5=";
            Assert.Equal("22", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestAdditionAndSubtraction() {
            string pressedKeys = "10/2+5-3x2=";
            Assert.Equal("14", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestSignToggle() {
            string pressedKeys = "12+2sss=";
            Assert.Equal("10", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestResetKey() {
            string pressedKeys = "4+73c";
            Assert.Equal("0", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestAfterReset() {
            string pressedKeys = "c73-5=";
            Assert.Equal("68", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestAfterEqual() {
            string pressedKeys = "c73-5=8";
            Assert.Equal("8", OriginalResult(pressedKeys));
        }
        [Fact]
        public void TestIgnoreInvalid() {
            string pressedKeys = "7g3-5=";
            Assert.Equal("68", OriginalResult(pressedKeys));
        }
        private string OriginalResult(string pressedKeys) {
            string result = null;
            foreach (char key in pressedKeys) {
                result = calculator.SendKeyPress(key);
            }
            return result;
        }
    }
}