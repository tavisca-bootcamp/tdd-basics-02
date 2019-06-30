using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void TestAddition1()
        {
            var calculator = new Calculator();
            var expression = new char[]{ '1', '0', '+', '2', '+','2','=' };
            var expected = new string[]{ "1", "10","10","2", "12","2","14" };
            int length = expression.Length;
            var actual = new string[length];
            for (int i = 0; i < length; i++)
                actual[i] = calculator.SendKeyPress(expression[i]);
            Assert.Equal(expected, actual);
            
        }

        [Fact]
        public void TestAddition2()
        {
            var calculator = new Calculator();
            var expression = new char[] { '0', '.' , '1' , '+'  , '2', '+' , '2', '.' , '3' , '=' };
            var expected = new string[] { "0", "0.","0.1", "0.1", "2","2.1", "2","2." ,"2.3","4.4"};
            int length = expression.Length;
            var actual = new string[length];
            for (int i = 0; i < length; i++)
                actual[i] = calculator.SendKeyPress(expression[i]);
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestSubtraction1()
        {
            var calculator = new Calculator();
            var expression = new char[] { '4','-','2','-','1','=' };
            var expected = new string[] { "4","4","2","2","1", "1"};
            int length = expression.Length;
            var actual = new string[length];
            for (int i = 0; i < length; i++)
                actual[i] = calculator.SendKeyPress(expression[i]);
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void SubtractionAddtionCombined()
        {
            var calculator = new Calculator();
           var expression = new char[] { '4', '.', '1' , '-', '0', '.', '2', '+', '0','.','1','=' };
           var expected = new string[] { "4", "4.","4.1","4.1", "0","0.", "0.2", "3.9", "0", "0.","0.1","4" };
            int length = expression.Length;
            var actual = new string[length];
            for (int i = 0; i < length; i++)
                actual[i] = calculator.SendKeyPress(expression[i]);
            Assert.Equal(expected, actual);

        }
    }
}
