using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private string GetResults(string expression)
        {
            Calculator calculator = new Calculator();
            string results = "";
            foreach(char keys in expression)
            {
                results = calculator.SendKeyPress(keys);
            }
            calculator.SendKeyPress('c');
            return results;
        }
        
        [Fact]
        public void BasicTest()
        {
            string expr = "10+12=";
            string expected = "22";
            string actual = GetResults(expr);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SampleTest1()
        {
            string expr = "10+2=";
            string expected = "12";
            string actual = GetResults(expr);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SampleTest2DivideByZero()
        {
            string expr = "10/0=";
            string expected = "-E-";
            string actual = GetResults(expr);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SampleTest3CheckingMultipleDots()
        {
            string expr = "00..00..0001";
            string expected = "0.000001";
            string actual = GetResults(expr);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void SampleTest4SignToggled()
        {
            string expr = "12+2SsS=";
            string expected = "10";
            string actual = GetResults(expr);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SampleTest5CheckingMultipleOprends()
        {
            string expr = "1+2+3+=";
            string expected = "12";
            string actual = GetResults(expr);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SampleTest5CheckingMultipleOprends1()
        {
            string expr = "1+2+C";
            string expected = "0";
            string actual = GetResults(expr);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void checkingMultipication()
        {
            string expr = "2*3*6=";
            string expected = "36";
            string actual = GetResults(expr);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void checkingNegative()
        {
            string expr = "36sx54=";
            string expected = "-1944";
            string actual = GetResults(expr);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Checkingdivision()
        {
            string expr = "15.5/3=";
            string expected = "5.17";
            string actual = GetResults(expr);
            Assert.Equal(expected, actual);
        }


    }
}
