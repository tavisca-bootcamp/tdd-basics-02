using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void AdditionTest()
        {
            string expected = "12";
            Assert.Equal(Calculator("10+2="), expected);
            return;
        }

        [Fact]
        public void DivideByZero()
        {
            string expected = "-E-";
            Assert.Equal(Calculator("10/0="), expected);
            return;
        }

        [Fact]
        public void SKeyTest()
        {
            string expected = "10";
            Assert.Equal(Calculator("12+2SSS="), expected);
            return;
        }

        [Fact]
        public void DecimalTest()
        {
            string expected = "0.001";
            Assert.Equal(Calculator("00..001"), expected);
            return;
        }

        [Fact]
        public void CKeyTest()
        {
            string expected = "0";
            Assert.Equal(Calculator("1+2+C"), expected);
            return;
        }

        private string Calculator(string input)
        {
            Calculator calc = new Calculator();
            string result = calc.Calculate(input);
            return result;
        }
    }
}
