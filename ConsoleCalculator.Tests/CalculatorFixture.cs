using System;
using System.Collections.Generic;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {

        [Fact]
        public void Test1()
        {
            string exp = "0";
            Assert.Equal("0", ActualString(exp));
        }

        [Fact]
        public void Test2()
        {
            string exp = "000";
            Assert.Equal("0", ActualString(exp));
        }

        [Fact]
        public void Test3()
        {
            string exp = "1/0=";
            Assert.Equal("-E-", ActualString(exp));
        }

        [Fact]
        public void Test5()
        {
            string exp = "3+4";
            Assert.Equal("4", ActualString(exp));
        }


        [Fact]
        public void Test7()
        {
            string exp = "3..5+4..5=";
            Assert.Equal("8", ActualString(exp));
        }

        [Fact]
        public void Test8()
        {
            string exp = "3..5+4..5+2+1..5+0.5=";
            Assert.Equal("12", ActualString(exp));
        }

        [Fact]
        public void Test9()
        {
            string exp = "3..5+4.c";
            Assert.Equal("", ActualString(exp));
        }

     




        private string ActualString(string exp)
        {
            Calculator calculator = new Calculator();
            string result = string.Empty;
            foreach (var item in exp)
            {
                result = calculator.SendKeyPress(item);
            }
            return result;
        }
    }
}
