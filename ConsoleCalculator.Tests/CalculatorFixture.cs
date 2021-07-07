using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calc=new Calculator();

        [Fact]
        public void SampleTest()
        {
            string expr="10+12=";
            string expected="22";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(expected,actual);
            return;
        }
        [Fact]
        public void SampleTest1()
        {
            string expr="10/0=";
            string expected="-E-";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(expected,actual);
            return;
        }
        [Fact]
        public void SampleTest2()
        {
            string expr="22/11=";
            string expected="2";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(expected,actual);
            
        }
        [Fact]
        public void EdgeCase()
        {
            string expr="/*+-";
            string expected="-E-";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(expected,actual);
        }
        [Fact]
        public void EdgeCase2()
        {
            string expr="29+12-2=";
            string expected="39";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(expected,actual);
        }
        [Fact]
        public void Edgecase3()
        {
            string expr="27+=";
            string expected="-E-";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(expected,actual);
        }
        [Fact]
        public void Edgecase4()
        {
            string expr="1+2+C";
            string expected="0";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(actual,expected);
        }
        [Fact]
        public void Decimal()
        {
            string expr="0..0001";
            string expected="0.0001";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(actual,expected);
        }
        [Fact]
        public void testSign()
        {
        string expr="12+2sss=";
            string expected="10";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(actual,expected);
        }
        [Fact]
        public void Testinvalidexpr()
        {
            string expr="+++++++------------***2222______2=";
            string expected="-E-";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(actual,expected);
        }
        [Fact]
        public void negative()
        {
            string expr="-72X33=";
            string expected="-2376";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(actual,expected);
        }
        [Fact]
        public void BothNegative()
        {
            string expr="-72X-33=";
            string expected="2376";
            string actual=calc.CalculateExpression(expr);
            Assert.Equal(actual,expected);
        }
        
    }
}