using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calc;
        CalculatorFixture()
        {
            calc=new Calculator();
        }

        [Fact]
        public void SampleTest()
        {
            string expr="10+12=";
            string expected="22";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(expected,actual);
        }
        [Fact]
        public void SampleTest1()
        {
            string expr=" 10/0=";
            string expected="-E-";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(expected,actual);
            
        }
    }
}
