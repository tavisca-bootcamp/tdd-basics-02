using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        
        [Fact]
        public void Addition()
        {
            char[] temp=new char[]{'1','2','3','+','1','0','='}; //To simulate input 123+10=133
            string result="";
            var c=new Calculator();
            foreach(char i in temp)
                result=c.SendKeyPress(i);
            Assert.Equal("133",result);
        }
        [Fact]
        public void Subtraction()
        {
            char[] temp=new char[]{'1','2','3','-','1','0','='};    //213-10=113
            string result="";
            var c=new Calculator();
            foreach(char i in temp)
                result=c.SendKeyPress(i);
            Assert.Equal("113",result);
        }
        [Fact]
        public void ContiniuosCalculation()
        {
            char[] temp=new char[]{'1','0','+','1','0','+','5','='};    //10+10+5=25
            string result="";
            var c=new Calculator();
            foreach(char i in temp)
                result=c.SendKeyPress(i);
            Assert.Equal("25",result);
        }
        [Fact]
        public void CalculationAfterResult()
        {
            char[] temp=new char[]{'1','0','+','1','0','+','5','=','+','1','0','='};    //10+10+5=25+10=35
            string result="";
            var c=new Calculator();
            foreach(char i in temp)
                result=c.SendKeyPress(i);
            Assert.Equal("35",result);
        }
        [Fact]
        public void CalculationWithNegatives()
        {
            char[] temp=new char[]{'1','0','+','5','0','s','='};    //10+-50=-40
            string result="";
            var c=new Calculator();
            foreach(char i in temp)
                result=c.SendKeyPress(i);
            Assert.Equal("-40",result);
        }
        [Fact]
        public void ScreenReset()
        {
            char[] temp=new char[]{'1','0','+','5','0','s','c'};    //0
            string result="";
            var c=new Calculator();
            foreach(char i in temp)
                result=c.SendKeyPress(i);
            Assert.Equal("0",result);
        }
        [Fact]
        public void CalculationWithDecimals()
        {
            char[] temp=new char[]{'0','.','0','0','5','+','1','='};    //0.005+1=1.005
            string result="";
            var c=new Calculator();
            foreach(char i in temp)
                result=c.SendKeyPress(i);
            Assert.Equal("1.005",result);
        }
        [Fact]
        public void AllZeros()
        {
            char[] temp=new char[]{'0','0','0','0','0'};    //screen must be showing '0' not '0000'
            string result="";
            var c=new Calculator();
            foreach(char i in temp)
                result=c.SendKeyPress(i);
            Assert.Equal("0\n",result);             //incomplete calculation will contain \n
        }
        [Fact]
        public void ScreenCheck()
        {
            char[] temp=new char[]{'5','0','0','5'};    //screen output must be 5005
            string result="";
            var c=new Calculator();
            foreach(char i in temp)
                result=c.SendKeyPress(i);
            Assert.Equal("5005\n",result);              //incomplete calculation will contain \n
            c.SendKeyPress('c');                        //to clear static variables
        }
        [Fact]
        public void WrongInputException()
        {
            char[] temp=new char[]{'1','0','a'};    //Argument exception
            var c=new Calculator();
            Assert.Throws<ArgumentException>(() => {foreach(var i in temp)c.SendKeyPress(i);});
            c.SendKeyPress('c');
        }
        [Fact]
        public void WrongFormatInputException()
        {
            char[] temp=new char[]{'1','0','='};    //= must be given after two oprands
            var c=new Calculator();
            Assert.Throws<FormatException>(() => {foreach(var i in temp)c.SendKeyPress(i);});
            c.SendKeyPress('c');
        }
    }
}
