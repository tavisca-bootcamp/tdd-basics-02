using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void TestBasicOperation()
        {
            Calculator calculator = new Calculator();
            string equation = "10+2=";
            string[] answer = { "1", "10", "10", "2", "12" };
            int i;
            for (i = 0; i < equation.Length; i++)
            {
                Assert.Equal(answer[i], calculator.SendKeyPress(equation[i]));
            }
        }

        [Fact]
        public void TestErrorOperation()
        {
            Calculator calculator1 = new Calculator();
            string equation = "10/0=";
            string[] answer = { "1", "10", "10", "0", "-E-" };
            int i;
            for (i = 0; i < equation.Length; i++)
            {
                Assert.Equal(answer[i], calculator1.SendKeyPress(equation[i]));
            }
        }

        [Fact]
        public void TestDecimalsAndZeros()
        {
            Calculator calculator2 = new Calculator();
            string equation = "00..001";
            string[] answer = { "0", "0", "0.", "0.", "0.0", "0.00", "0.001" };
            int i;
            for (i = 0; i < equation.Length; i++)
            {
                Assert.Equal(answer[i], calculator2.SendKeyPress(equation[i]));
            }
        }

        [Fact]
        public void TestClearOperation()
        {
            Calculator calculator3 = new Calculator();
            string equation = "1+2+c";
            string[] answer = { "1", "1", "2", "3", "0" };
            int i;
            for (i = 0; i < equation.Length; i++)
            {
                Assert.Equal(answer[i], calculator3.SendKeyPress(equation[i]));
            }
        }

        [Fact]
        public void TestSignToggleOperation()
        {
            Calculator calculator4 = new Calculator();
            string equation = "12+2SSS=";
            string[] answer = { "1", "12", "12", "2", "-2", "2", "-2", "10" };
            int i;
            for (i = 0; i < equation.Length; i++)
            {
                Assert.Equal(answer[i], calculator4.SendKeyPress(equation[i]));
            }
        }
    }
}
