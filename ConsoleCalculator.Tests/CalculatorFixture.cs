using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
                [TestMethod] 

public void Test1()
        {
            string temp = "1234C";
            var cc = new Calculator();
            string result=string.Empty;
            for(int i=0;i<temp.Length;i++)
            {
                result = cc.SendKeyPress(temp[i]);
            }
            Assert.AreEqual("0", result);


        }
            [TestMethod] 

        public void MultpleZeroTest()
        {
            string temp = "00000000";
            var cc = new Calculator();
            string result = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                result = cc.SendKeyPress(temp[i]);
            }
            Assert.AreEqual("0", result);
        }
               [TestMethod] 

        public void NegativeToggleTest()
        {
            string temp = "2s";
            var cc = new Calculator();
            string result = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                result = cc.SendKeyPress(temp[i]);
            }
            Assert.AreEqual("-2", result);
        }
        [TestMethod] 
        public void DivedbyZeroTest()
        {
            string temp = "20/0=";
            var cc = new Calculator();
            string result = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                result = cc.SendKeyPress(temp[i]);
            }
            Assert.AreEqual("-E-", result);
        }
}
