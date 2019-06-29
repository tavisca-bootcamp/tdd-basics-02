using System;
using static System.Console;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture : IDisposable
    {

        private Calculator c;
        public CalculatorFixture(){
            c = new Calculator();
        }

        public void Dispose()
        {
            c = null;
        }

        [Fact]

        public void SimpleArithmeticTest(){
            Assert.Equal("12",ProcessOutput("10 + 2 ="));
        }

        [Fact]

        public void DivideByZeroTest(){
            Assert.Equal("-E-",ProcessOutput("10/0="));
        }
        [Fact]

        public void CorrectDecimalNumberFormatTest(){
            Assert.Equal("0.001",ProcessOutput("00..001"));
        }

        [Fact]
        public void NumberTogglingTest(){
            Assert.Equal("10",ProcessOutput("12+2SSS="));
        }

        [Fact]
        public void ComplexArithmeticTest(){
            Assert.Equal("12",ProcessOutput("1+2+3+="));
        }

        [Fact]
        public void ClearConsoleTest(){
            Assert.Equal("0",ProcessOutput("1+2+C"));
        }

        [Fact]
        public void IncorrectlyPlacedOperatorTest(){
            Assert.Equal("-E-",ProcessOutput("+"));
        }

        [Fact]
        public void ExtraneousOperatorTest(){
            Assert.Equal("-E-",ProcessOutput("2++"));
        }

        [Fact]
        public void InvalidExpressionTest(){
            Assert.Equal("-E-",ProcessOutput("1+2=+"));
        }

        public string ProcessOutput(string Input){
            string Output = "";

            foreach(char token in Input){
                Output = c.SendKeyPress(token);
            }
            return Output;
        }

    }
}
