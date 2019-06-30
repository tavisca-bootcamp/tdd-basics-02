using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator = new Calculator();

        private string sendMultipleKey(char[] key)
        {
            var i = 0;
            for (i = 0; i < key.Length - 1; i++)
                calculator.SendKeyPress(key[i]);
            return calculator.SendKeyPress(key[i]);
        }


        [Fact]
        public void TestKeyPress()
        {
            char key = '1';

            string fromCall = calculator.SendKeyPress(key);

            Assert.Equal("1", fromCall);
        }

        [Fact]
        public void TestMultipleKeyPress()
        {
            char[] key = new char[] { 'h', '1', '2' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("12", fromCall);
        }

        [Fact]
        public void TestZeroKeySequence()
        {
            char[] key = new char[] { 'h', '0', '0','0' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("0", fromCall);
        }

        [Fact]
        public void TestDecimalKeySequence()
        {
            char[] key = new char[] { 'h', '0', '.', '.' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("0.", fromCall);
        }

        [Fact]
        public void TestBlankScreenDecimalKeySequence()
        {
            char[] key = new char[] { 'h', '.', '.' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("0.", fromCall);
        }


        [Fact]
        public void TestOperatorKeyPress()
        {
            char[] key = new char[] { 'h', '1', '2','+' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("12", fromCall);
        }

        [Fact]
        public void TestOperatorAndKeyPress()
        {
            char[] key = new char[] { 'h', '1', '2', '+','1' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("1", fromCall);
        }
        [Fact]
        public void TestSignChange()
        {
            char[] key = new char[] { 'h', '1', 's','s' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("1", fromCall);
        }

        [Fact]
        public void TestAddition()
        {
            char[] key = new char[] { 'h', '1', '2', '+', '1' ,'='};

            string fromCall = sendMultipleKey(key);

            Assert.Equal("13", fromCall);
        }

        [Fact]
        public void TestDivision()
        {
            char[] key = new char[] { 'h', '1', '/', '0','='};

            string fromCall = sendMultipleKey(key);

            Assert.Equal("-E-", fromCall);
        }

        [Fact]
        public void TestSignAirthmetic()
        {
            char[] key = new char[] { 'h', '1', '+', '3','s','S' ,'=' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("4", fromCall);
        }

        [Fact]
        public void TestArithmeticCalculationWithC()
        {
            char[] key = new char[] { '1', '+', '2', '+', 'C' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("0", fromCall);
        }

        [Fact]
        public void TestAnotherCalculation()
        {
            char[] key = new char[] { '1', '+', '2', '+', '3','+','=' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("12", fromCall);
        }

        [Fact]
        public void TestSomeCalulation()
        {
            char[] key = new char[] { '1','2' ,'+', '2', 'S', 's', 'S', '=' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("10", fromCall);
        }

        [Fact]
        public void TestZeroAndDecimal()
        {
            char[] key = new char[] { '0', '0', '.', '.', '0', '0', '1' };

            string fromCall = sendMultipleKey(key);

            Assert.Equal("0.001", fromCall);
        }
    }
}
