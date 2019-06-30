using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    [TestClass]
    public class CalculatorFixture
    {
        [TestMethod]
        public void DummyTest()
        {
            Calculator calculator = new Calculator();
            string equation = "10+2=";
            string[] answer = { "1","10","10","2","12"};
            int i;
            for(i=0;i<equation.Length;i++)
            {
                Assert.Equal(answer[i], calculator.SendKeyPress(equation[i]));
            }
        }
        [TestMethod]
        public void DummyTest1()
        {
            Calculator calculator1 = new Calculator();
            string equation = "10/0=";
            string[] answer = { "1", "10", "10", "0", "-E-"};
            int i;
            for (i = 0; i < equation.Length; i++)
            {
                Assert.Equal(answer[i], calculator1.SendKeyPress(equation[i]));
            }
        }
        [TestMethod]
        public void DummyTest2()
        {
            Calculator calculator2 = new Calculator();
            string equation = "00..001";
            string[] answer = { "0", "0", "0.", "0.", "0.0","0.00","0.001"};
            int i;
            for (i = 0; i < equation.Length; i++)
            {
                Assert.Equal(answer[i], calculator2.SendKeyPress(equation[i]));
            }
        }
        [TestMethod]
        public void DummyTest3()
        {
            Calculator calculator3 = new Calculator();
            string equation = "1+2+c";
            string[] answer = { "1", "1", "2", "3", "0"};
            int i;
            for (i = 0; i < equation.Length; i++)
            {
                Assert.Equal(answer[i], calculator3.SendKeyPress(equation[i]));
            }
        }
        [TestMethod]
        public void DummyTest4()
        {
            Calculator calculator4 = new Calculator();
            string equation = "12+2SSS=";
            string[] answer = { "1", "12", "12", "2", "-2","2","-2","10"};
            int i;
            for (i = 0; i < equation.Length; i++)
            {
                Assert.Equal(answer[i], calculator4.SendKeyPress(equation[i]));
            }
        }
        [TestMethod]
        public void DummyTest5()
        {
            Calculator calculator5 = new Calculator();
            string equation = "10+20-15=";
            string[] answer = { "1", "10", "10", "2", "20", "30", "1", "15","15"};
            int i;
            for (i = 0; i < equation.Length; i++)
            {
                Assert.Equal(answer[i], calculator5.SendKeyPress(equation[i]));
            }
        }


    }
}
