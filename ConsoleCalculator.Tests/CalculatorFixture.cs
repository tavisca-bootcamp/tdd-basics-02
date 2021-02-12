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
            Assert.Equal(Calculator("12+2S="), expected);
            return;
        }

        [Fact]
        public void sKeyTest()
        {
            string expected = "10";
            Assert.Equal(Calculator("12+2s="), expected);
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

        [Fact]
        public void cKeyTest()
        {
            string expected = "0";
            Assert.Equal(Calculator("1+2+c"), expected);
            return;
        }

        [Fact]
        public void MultiplicationTestWithx()
        {
            string expected = "195";
            Assert.Equal(Calculator("13x15="), expected);
            return;
        }

        [Fact]
        public void MultiplicationTestWithX()
        {
            string expected = "195";
            Assert.Equal(Calculator("13X15="), expected);
            return;
        }

        [Fact]
        public void DivisionTest1()
        {
            string expected = "2.5";
            Assert.Equal(Calculator("5/2="), expected);
            return;
        }

        [Fact]
        public void DivisionTest2()
        {
            string expected = "1.666667";
            Assert.Equal(Calculator("5/3="), expected);
            return;
        }

        [Fact]
        public void RepeatingEquals()
        {
            string expected = "5";
            Assert.Equal(Calculator("5/2=x2="), expected);
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
