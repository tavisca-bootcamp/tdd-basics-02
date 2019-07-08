using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator MyCalculator;
        public CalculatorFixture()
        {
            MyCalculator = new Calculator();
        }
        [Fact]
        public void NumberPressedTest()
        {
            string expectedResult,actualResult;
            expectedResult = "4";
            actualResult=MyCalculator.SendKeyPress('4');
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
