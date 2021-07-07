using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calc=new Calculator();
        

        String ProcessString(String input){
         for(int i=0;i<input.Length-1;i++){
             calc.SendKeyPress(input[i]);
         }
         return calc.SendKeyPress(input[input.Length-1]);
        }
        
        [Fact]
        public void DummyTest()
        {
            return;
        }
        [Fact]
        public void DivideByZero()
        {
            String input = "25/0=";
            var actual = ProcessString(input);
            var expected="-E-";
            Assert.Equal(expected,actual );
        }

        [Fact]
        public void BasicAdd()
        {
            String input = "10+2=";
            var actual = ProcessString(input);
            var expected="12";
            Assert.Equal(expected,actual );
        }

        [Fact]
        public void DecimalCheck()
        {
            String input = "00..001";
            var actual = ProcessString(input);
            var expected="0.001";
            Assert.Equal(expected,actual );
        }

        [Fact]
        public void SignToggle()
        {
            String input = "12+2sss=";
            var actual = ProcessString(input);
            var expected="10";
            Assert.Equal(expected,actual );
        }

        [Fact]
        public void MultipleAdd()
        {
            String input = "10+2+3+8=";
            var actual = ProcessString(input);
            var expected="23";
            Assert.Equal(expected,actual );
        }

       [Fact]
        public void ClearCheck()
        {
            String input = "10+2=c";
            var actual = ProcessString(input);
            var expected="0";
            Assert.Equal(expected,actual );
        }

        [Fact]
        public void MultipleOperator()
        {
            String input = "10+2/3x2=";
            var actual = ProcessString(input);
            var expected="8";
            Assert.Equal(expected,actual );
        }
    }
}
