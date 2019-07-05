using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator = new Calculator();
            
            [Fact]
            public void BasicOperationTest()
            {
                Assert.Equal("12",Evaluation("10+2="));
            }

            [Fact]
            public void DivideByZeroTest()
            {
                Assert.Equal("-E-",Evaluation("10/0="));
            }

            [Fact]
            public void DecimalFormatTest()
            {
                Assert.Equal("0.001",Evaluation("00..001"));
            }

            [Fact]
            public void MultiplicationTest()
            {
                Assert.Equal("20",Evaluation("5x2X2="));
            }

            [Fact]
            public void TogglingTest()
            {
                Assert.Equal("8",Evaluation("10+2S="));
            }

            [Fact]
            public void ComplexOperationTest()
            {
                Assert.Equal("6",Evaluation("1+2+3+"));
            }

            [Fact]
            public void ClearConsoleTest()
            {
                Assert.Equal("0",Evaluation("1+2+C"));
            }

            public string Evaluation(string equation)
            {
                string display = "";
                foreach(char term in equation)
                {
                    display = calculator.SendKeyPress(term);
                }
                return display;
            }
        }
    }

