using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calc = new Calculator();

         internal string ManykeysPressed(char[] key)
        {
            int i;
            for (i = 0; i < key.Length - 1; i++)
            {
                calc.SendKeyPress(key[i]);
            }
                return calc.SendKeyPress(key[i]);
                 
        }
        
        [Fact]
        public void Add()
        {
            
            char[] key = { '1', '3', '+', '8','='};
            var ans = ManykeysPressed(key);
            Assert.Equal("21", ans);
        }

        
        [Fact]
        public void Divideby0()
        {
            
            char[] key = { '1', '3', '/', '0','=' };
            var ans = ManykeysPressed(key);
            Assert.Equal("E", ans);
        }

        
        [Fact]
        public void DotOperator()
        {
            
            char[] key = { '0', '.', '.', '0','0','1' };
            var ans = ManykeysPressed(key);
            Assert.Equal("0.001", ans);
        }

        
        [Fact]
        public void SOperator()
        {
            
            char[] key = { '1', '3', '+', '2','s','S','='};
            var ans = ManykeysPressed(key);
            Assert.Equal("15", ans);
        }

        
        [Fact]
        public void MultipleAddition()
        {
            
            char[] key = { '1','3','+','8','+','9','='};
            var ans = ManykeysPressed(key);
            Assert.Equal("30", ans);
        }

        
        [Fact]
        public void COperator()
        {
            
            char[] key = { '1','3','4','+','C'};
            var ans = ManykeysPressed(key);
            Assert.Equal("0", ans);
        }
    }
}

        
    
