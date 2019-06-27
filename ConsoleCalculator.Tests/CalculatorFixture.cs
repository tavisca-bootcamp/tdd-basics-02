using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void Test1()
        {
            string expr="10+2=";
            string expected="12";
            string actual=GetResult(expr);

            Assert.Equal(expected,actual);
        }
        [Fact]
        public void Test2()
        {
            string expr="10/0=";
            string expected="-E-";
            string actual=GetResult(expr);

            Assert.Equal(expected,actual);
        }
        [Fact]
        public void Test3()
        {
            string expr="00..001";
            string expected="0.001";
            string actual=GetResult(expr);

            Assert.Equal(expected,actual);
        }
        [Fact]
        public void Test4()
        {
            string expr="12+2SSS=";
            string expected="10";
            string actual=GetResult(expr);

            Assert.Equal(expected,actual);
        }
        [Fact]
        public void Test5()
        {
            string expr="1+2+3+=";
            string expected="12";
            string actual=GetResult(expr);

            Assert.Equal(expected,actual);
        }
        [Fact]
        public void Test6()
        {
            string expr="1+2+C";
            string expected="0";
            string actual=GetResult(expr);

            Assert.Equal(expected,actual);
        }
        string GetResult(string expr)
        {
            Calculator calculator = new Calculator();
            string result="";
            foreach(char c in expr)
            {
                result=calculator.SendKeyPress(c);
            }
            return result;
        } 
    }
}
