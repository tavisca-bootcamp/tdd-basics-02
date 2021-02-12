using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator obj = new Calculator();
        string result = null;
       
       
        [Fact]
        public void TestCase1()
        {
            string testcase = "10+2=";
            
            foreach (char c in testcase)
            {
                result = obj.SendKeyPress(c);
            }
            Assert.Equal("12", result);
            

        }
        [Fact]
        public void Testcase2()
        {
            string testcase = "00..001";
            foreach(char c in testcase)
            {
                result = obj.SendKeyPress(c);
            }
            Assert.Equal("0.001", result);
            
            
        }
        [Fact]

        public void Testcase3()
        {
            string testcase = "10/0=";
            foreach (char c in testcase)
            {
                result = obj.SendKeyPress(c);
            }
            Assert.Equal("-E-", result);
        }


        
            [Fact]
        public void Testcase4()
        {
            string testcase = "12+2SSS=";
            foreach (char c in testcase)
            {
                result = obj.SendKeyPress(c);
            }
            Assert.Equal("10", result);


        }
        [Fact]
        public void Testcase5()
        {
            string testcase = "1+2+C";
            foreach (char c in testcase)
            {
                result = obj.SendKeyPress(c);
            }
            Assert.Equal("0", result);


        }
        [Fact]
        public void Testcase6()
        {
            string testcase = "1+2+3+=";
            foreach (char c in testcase)
            {
                result = obj.SendKeyPress(c);
            }
            Console.WriteLine(result);
            Assert.Equal("6", result);


        }


    }
}
