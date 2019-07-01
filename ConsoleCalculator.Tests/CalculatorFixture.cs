using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator C = new Calculator();
        string equation = "";

        private string tester(string eq)
        {
            string res = "";
            foreach (char ch in eq)
                res = C.SendKeyPress(ch);
            return res;
        }

        [Fact]
        public void SingleDigitTest()
        {
            Assert.Equal("1", tester("1"));
        }

        [Fact]
        public void MultipleZerosTest()
        {
            Assert.Equal("0", tester("0000"));
        }

        [Fact]
        public void MultipleZerosAfterDecimalPointTest()
        {
            Assert.Equal("1.000", tester("1.000"));
        }

        [Fact]
        public void MultipleDecimalPointTest()
        {
            Assert.Equal("1.000", tester("1..000"));
        }

        [Fact]
        public void SignToggleTest()
        {
            Assert.Equal("-12", tester("12s"));
        }

        [Fact]
        public void ClearTest()
        {
            Assert.Equal("0", tester("12c"));
        }

        [Fact]
        public void InvalidInputsTest()
        {
            Assert.Equal("1", tester("12-j^&11="));
        }

        [Fact]
        public void ValidMultipleDecimalPointTest()
        {
            equation = "1.1+2.3=";
            Assert.Equal("3.4", tester(equation));
        }

        [Fact]
        public void ValidDivisionTest()
        {
            equation = "19200/2=";
            Assert.Equal("9600", tester(equation));
        }

        [Fact]
        public void MultiplicationTest()
        {
            equation = "19200x0=";
            Assert.Equal("0", tester(equation));
        }

        [Fact]
        public void SubtractionTest()
        {
            equation = "19200-0=";
            Assert.Equal("19200", tester(equation));
        }


        [Fact]
        public void Equation1Test()
        {
            equation = "10+2=";
            Assert.Equal("12", tester(equation));
        }

        [Fact]
        public void Equation2Test()
        {
            equation = "10/0=";
            Assert.Equal("-E-", tester(equation));
        }

        [Fact]
        public void Equation3Test()
        {
            equation = "00.001";
            Assert.Equal("0.001", tester(equation));
        }

        [Fact]
        public void Equation4Test()
        {
            equation = "12+2SSS=";
            Assert.Equal("10", tester(equation));
        }

        [Fact]
        public void Equation5Test()
        {
            equation = "1+2+C";
            Assert.Equal("0", tester(equation));
        }

        [Fact]
        public void Equation6Test()
        {
            equation = "1+2+3+=";
            Assert.Equal("6", tester(equation));
        }

    }
}