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
        public void SimpleCalculationTest()
        {
            Assert.Equal("12", findResult("10+2="));
        }

        [Fact]
        public void ErrorTest()
        {
            Assert.Equal("-E-", findResult("10/0="));
        }

        [Fact]
        public void ToggleTest()
        {
            Assert.Equal("-2", findResult("2sSs"));
        }

        [Fact]
        public void ResetTest()
        {
            Assert.Equal("0", findResult("1+2+C"));
        }

        [Fact]
        public void ZerosTest()
        {
            Assert.Equal("0.005", findResult("000..005"));
        }

        [Fact]
        public void SimpleMultiplicationTest()
        {
            Assert.Equal("12", findResult("4X3="));
        }

        public string findResult(string equation)
        {
            Calculator calculator = new Calculator();
            string result = "";
            foreach (char ch in equation)
            {
                result = calculator.SendKeyPress(ch);
            }
            return result;
        }
    }
}