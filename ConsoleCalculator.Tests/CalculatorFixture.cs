using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator = new Calculator();
        string equation = "";

        private string Tester(string eq)
        {
            string res = "";

            foreach (char ch in eq)
                res = calculator.SendKeyPress(ch);

            return res;
        }

        [Fact]
        public void SingleDigitTest()
        {
            Assert.Equal("1", Tester("1"));
        }

        [Fact]
        public void MultipleZerosTest()
        {
            Assert.Equal("0", Tester("0000"));
        }

        [Fact]
        public void MultipleZerosAfterDecimalPointTest()
        {
            Assert.Equal("1.000", Tester("1.000"));
        }

        [Fact]
        public void MultipleDecimalPointTest()
        {
            Assert.Equal("1.000", Tester("1..000"));
        }

        [Fact]
        public void SignToggleTest()
        {
            Assert.Equal("-12", Tester("12s"));
        }

        [Fact]
        public void ClearTest()
        {
            Assert.Equal("0", Tester("12c"));
        }

        [Fact]
        public void MultipleMinusOperatortest() 
        {
            equation = "50-5=-5=";
            
            Assert.Equal("40", Tester(equation));
        }

        [Fact]
        public void MultiplePlusOperatortest()
        {
            equation = "1+1+1++++=";

            Assert.Equal("3", Tester(equation));
        }

        [Fact]
        public void InvalidInputsTest()
        {
            equation = "12-j^&11=";

            Assert.Equal("1", Tester(equation));
        }

        [Fact]
        public void ValidMultipleDecimalPointTest()
        {
            equation = "1.1+2.3=";

            Assert.Equal("3.4", Tester(equation));
        }

        [Fact]
        public void ValidDivisionTest()
        {
            equation = "19200/2=";

            Assert.Equal("9600", Tester(equation));
        }

        [Fact]
        public void MultiplicationTest()
        {
            equation = "19200x0=";

            Assert.Equal("0", Tester(equation));
        }

        [Fact]
        public void SubtractionTest()
        {
            equation = "19200-0=";

            Assert.Equal("19200", Tester(equation));
        }

        [Fact]
        public void Equation1Test()
        {
            equation = "10+2=";

            Assert.Equal("12", Tester(equation));
        }

        [Fact]
        public void Equation2Test()
        {
            equation = "10/0=";

            Assert.Equal("-E-", Tester(equation));
        }

        [Fact]
        public void Equation3Test()
        {
            equation = "00.001";

            Assert.Equal("0.001", Tester(equation));
        }

        [Fact]
        public void Equation4Test()
        {
            equation = "12+2SSS=";

            Assert.Equal("10", Tester(equation));
        }

        [Fact]
        public void Equation5Test()
        {
            equation = "1+2+C";

            Assert.Equal("0", Tester(equation));
        }

        [Fact]
        public void Equation6Test()
        {
            equation = "1+2+3+=";

            Assert.Equal("6", Tester(equation));
        }

    }
}