using System;
using System.Collections.Generic;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        
        Calculator _Calculator = new Calculator();
        [Fact]
        public void When_User_Press_Invalid_Key()
        {
            //given
            var actual = _Calculator.SendKeyPress('e');

            //when
            var expected = "-E-";

            //then
            Assert.Equal(expected, actual);  
        }

        [Fact]
        public void When_UserTypedNumeric_FirstTime()
        {
            //when
            var actual = _Calculator.SendKeyPress('2');
            //given
            var expected = "2";
            //then
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void When_UserTypedNumeric_Repeatedly()
        {
            var actual = _Calculator.SendKeyPress('2');
            actual = _Calculator.SendKeyPress('3');

            var expected = "23";

            Assert.Equal(expected, actual);

        }
        [Fact]
        public void When_UserPress_ArithematicOperators()
        {
            var actual = _Calculator.SendKeyPress('+');

            var expected = "+";

            Assert.Equal(expected, actual);

        }
        [Fact]
        public void When_UserpressNumeric_AfterOperator()
        {
            var actual = _Calculator.SendKeyPress('3');

            var expected = "3";

            Assert.Equal(expected, actual);

        }
    
        [Fact]

        public void When_User_PressC()
        {
            //given
            var actual = _Calculator.SendKeyPress('C');
            //when
            var expected = "0";
            //then
            Assert.Equal("0", actual);

        }
       [Fact]
       public void when_UserPress_Equal()
        {
            var actual = _Calculator.SendKeyPress('=');
            var expected = "=";
            //user not pressed first and secind number
            Assert.Equal(expected, actual);
        }
    }
}
