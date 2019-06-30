using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator obj;
        public CalculatorFixture(){
            this.obj = new Calculator();
        }

        [Fact]
        public void IgnorotherCharacters(){
            string expected = "";
            string actual = obj.SendKeyPress('g'); //tested with other invalid keys also

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void UpdatingScreenOnNumberPress(){

            string expected = "57";
            obj.SendKeyPress('5');
            string actual = obj.SendKeyPress('7');

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void UpdatingScreenWhenOperatorIsPressed()
        {
            string expected = "75";
            obj.SendKeyPress('7');
            obj.SendKeyPress('5');

            string actual = obj.SendKeyPress('+');
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void UpdatingScreenWhenNumberIsPressedAfterOperator()
        {
            
            string expected = "2";
            obj.SendKeyPress('4');
            obj.SendKeyPress('3');
            obj.SendKeyPress('+');
            
            string actual = obj.SendKeyPress('2');
            
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void PerformingAddition()
        {
            string expected = "50";

            obj.SendKeyPress('1');
            obj.SendKeyPress('5');
            obj.SendKeyPress('+');
            obj.SendKeyPress('3');
            obj.SendKeyPress('5');

            string actual = obj.SendKeyPress('=');
            
            Assert.Equal(expected,actual);
            
        }

        [Fact]
        public void PerformingSubstraction()
        {
            string expected = "20";
            obj.SendKeyPress('3');
            obj.SendKeyPress('5');
            obj.SendKeyPress('-');
            obj.SendKeyPress('1');
            obj.SendKeyPress('5');

            string actual = obj.SendKeyPress('=');
            
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void PerformingMultiplication()
        {
            string expected = "525";

            obj.SendKeyPress('1');
            obj.SendKeyPress('5');
            obj.SendKeyPress('*');
            obj.SendKeyPress('3');
            obj.SendKeyPress('5');

            string actual = obj.SendKeyPress('=');
            
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void PerformingDivision()
        {
            string expected = "0.4286";

            obj.SendKeyPress('1');
            obj.SendKeyPress('5');
            obj.SendKeyPress('/');
            obj.SendKeyPress('3');
            obj.SendKeyPress('5');

            string actual = obj.SendKeyPress('=');
            
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void PressingResetKeyCheck()
        {
            string expected = "0";

            obj.SendKeyPress('5');
            obj.SendKeyPress('0');
            obj.SendKeyPress('+');
            obj.SendKeyPress('c');
            obj.SendKeyPress('1');
            obj.SendKeyPress('-');
            obj.SendKeyPress('1');

            string actual = obj.SendKeyPress('=');

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void PerformingFloatOperation()
        {
            string expected = "20.01";

            obj.SendKeyPress('1');
            obj.SendKeyPress('5');
            obj.SendKeyPress('.');
            obj.SendKeyPress('1');
            obj.SendKeyPress('0');
            obj.SendKeyPress('+');
            obj.SendKeyPress('4');
            obj.SendKeyPress('.');
            obj.SendKeyPress('9');
            obj.SendKeyPress('1');

            string actual = obj.SendKeyPress('=');

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void PerformingNegation()
        {
            string expected = "20";

            obj.SendKeyPress('3');
            obj.SendKeyPress('5');
            obj.SendKeyPress('+');
            obj.SendKeyPress('1');
            obj.SendKeyPress('5');
            obj.SendKeyPress('s');

            string actual = obj.SendKeyPress('=');

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void ShowingError()
        {
            string expected = "-E-";

            obj.SendKeyPress('1');
            obj.SendKeyPress('0');
            obj.SendKeyPress('/');
            obj.SendKeyPress('0');

            string actual = obj.SendKeyPress('=');
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void CanTakeBigNumberAlso()
        {
            string expected = "200000000000000000000";

            obj.SendKeyPress('1');
            for(int i = 0; i < 20; i++){
                obj.SendKeyPress('0');
            }
            obj.SendKeyPress('+');
            obj.SendKeyPress('1');
            for(int i = 0; i < 20; i++){
                obj.SendKeyPress('0');
            }

            string actual = obj.SendKeyPress('=');
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void TestCase1()
        {
            string expected = "12";

            obj.SendKeyPress('1');
            obj.SendKeyPress('0');
            obj.SendKeyPress('+');
            obj.SendKeyPress('2');

            string actual = obj.SendKeyPress('=');

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void TestCase2()
        {
            string expected = "-E-";

            obj.SendKeyPress('1');
            obj.SendKeyPress('0');
            obj.SendKeyPress('/');
            obj.SendKeyPress('0');

            string actual = obj.SendKeyPress('=');

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void TestCase3()
        {
            string expected = "0.001";

            obj.SendKeyPress('0');
            obj.SendKeyPress('0');
            obj.SendKeyPress('.');
            obj.SendKeyPress('.');
            obj.SendKeyPress('0');
            obj.SendKeyPress('0');

            string actual = obj.SendKeyPress('1');

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void TestCase4()
        {
            string expected = "10";

            obj.SendKeyPress('1');
            obj.SendKeyPress('2');
            obj.SendKeyPress('+');
            obj.SendKeyPress('2');
            obj.SendKeyPress('s');
            obj.SendKeyPress('s');
            obj.SendKeyPress('s');

            string actual = obj.SendKeyPress('=');
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void TestCase5()
        {
            string expected = "0";

            obj.SendKeyPress('1');
            obj.SendKeyPress('+');
            obj.SendKeyPress('2');
            obj.SendKeyPress('+');

            string actual = obj.SendKeyPress('c');

            Assert.Equal(expected,actual);
        }
    }
}
