using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void DummyTest()
        {
            string expectedTest1 = "6";
            string expectedTest2 = "1.32";
            string expectedTest3 = "-E-";
            string actualOutput1 = "";
            string actualOutput2 = "";
            string actualOutput3 = "";
            Calculator calculatorTest1 = new Calculator();
            Calculator calculatorTest2 = new Calculator();
            Calculator calculatorTest3 = new Calculator();


            actualOutput1 = calculatorTest1.SendKeyPress('2');
            actualOutput1 = calculatorTest1.SendKeyPress('x');
            actualOutput1 = calculatorTest1.SendKeyPress('3');
            actualOutput1 = calculatorTest1.SendKeyPress('=');

            actualOutput2 = calculatorTest2.SendKeyPress('1');
            actualOutput2 = calculatorTest2.SendKeyPress('.');
            actualOutput2 = calculatorTest2.SendKeyPress('2');
            actualOutput2 = calculatorTest2.SendKeyPress('x');
            actualOutput2 = calculatorTest2.SendKeyPress('1');
            actualOutput2 = calculatorTest2.SendKeyPress('.');
            actualOutput2 = calculatorTest2.SendKeyPress('1');
            actualOutput2 = calculatorTest2.SendKeyPress('=');

            actualOutput3 = calculatorTest3.SendKeyPress('2');
            actualOutput3 = calculatorTest3.SendKeyPress('/');
            actualOutput3 = calculatorTest3.SendKeyPress('0');
            actualOutput3 = calculatorTest3.SendKeyPress('=');

            Assert.Equal(expectedTest1, actualOutput1);
            Assert.Equal(expectedTest2, actualOutput2);
            Assert.Equal(expectedTest3, actualOutput3);

        }
    }
}
