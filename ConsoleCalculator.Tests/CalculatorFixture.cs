using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
      
        public class UnitTest1
     {
        [Theory]
        [InlineData('0',true)]
        [InlineData('.', true)]
        [InlineData('s', true)]
        [InlineData('S', true)]
        [InlineData('c', true)]
        [InlineData('C', true)]
        public void checkValidTest(char ch, bool val)
        {
            Calculator c = new Calculator();
            Assert.Equal<bool>(c.validateKey(ch), val);
        }
            
            
        [Theory]
        [InlineData("234","-234")]
        [InlineData("-23","23")]
        public void ToggleTest(string s, string val)
        {
            Calculator c = new Calculator();
            Assert.Equal(c.toggle(s), val);
        }
            
            
        [Theory]
        [InlineData("1+2+3=","6")]
        [InlineData("2+2s=","0")]
        [InlineData("1+1++=","2")]
        [InlineData("10/0=","-E-")]
        [InlineData("2.0x3.1=","6.2")]
        [InlineData("0X33=","0")]
        [InlineData("0/2=","-E-")]
        public void SendKeyPressTest(string s,string p)
        {
            var calc = new Calculator();
            int i = 0;
            string ans ="";
            int leng = s.Length;
            while (i<leng)
            {
               ans= calc.SendKeyPress(s[i]);
                i++;
            }
            Console.WriteLine(ans + " " + p);
            Assert.Equal(ans, p);
        }
        
        
    }
}
