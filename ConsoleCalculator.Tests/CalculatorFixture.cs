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
            string actualResult = calculator.SendKeyPress(key);
            string expectedResult = "1";
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestMultipleKeyPress()
        {
            char[] key = new char[] { 'h', '1', '2' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "12";
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestZeroKeySequence()
        {
            char[] key = new char[] { 'h', '0', '0','0' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "0";
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestDecimalKeySequence()
        {
            char[] key = new char[] { 'h', '0', '.', '.' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "0.";
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestBlankScreenDecimalKeySequence()
        {
            char[] key = new char[] { 'h', '.', '.' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "0.";
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestOperatorAndKeyPress()
        {
            char[] key = new char[] { 'h', '1', '2', '+','1' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "1";
            Assert.Equal(expectedResult, actualResult);
        }
		[Fact]
        public void TestOperatorKeyPress()
        {
            char[] key = new char[] { 'h', '1', '2','+' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "12";
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestAddition()
        {
            char[] key = new char[] { 'h', '1', '2', '+', '1' ,'='};
            string actualResult = sendMultipleKey(key);
			string expectedResult = "13";
            Assert.Equal(expectedResult, actualResult);
        }
		[Fact]
        public void TestDivision()
        {
            char[] key = new char[] { 'h', '1', '/', '0','='};
            string actualResult = sendMultipleKey(key);
			string expectedResult = "-E-";
            Assert.Equal(expectedResult, actualResult);
        }
		[Fact]
        public void TestSignAirthmetic()
        {
            char[] key = new char[] { 'h', '1', '+', '3','s','S' ,'=' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "4";
            Assert.Equal(expectedResult, actualResult);
        }
		[Fact]
        public void TestSignChange()
        {
            char[] key = new char[] { 'h', '1', 's','s' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "1";
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestArithmeticCalculationWithC()
        {
            char[] key = new char[] { '1', '+', '2', '+', 'C' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "0";
            Assert.Equal(expectedResult, actualResult);
        }
		[Fact]
        public void TestZeroAndDecimal()
        {
            char[] key = new char[] { '0', '0', '.', '.', '0', '0', '1' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "0.001";
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestSomeCalulation()
        {
            char[] key = new char[] { '1','2' ,'+', '2', 'S', 's', 'S', '=' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "10";
            Assert.Equal(expectedResult, actualResult);
        }
		[Fact]
        public void TestAnotherCalculation()
        {
            char[] key = new char[] { '1', '+', '2', '+', '3','+','=' };
            string actualResult = sendMultipleKey(key);
			string expectedResult = "12";
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
