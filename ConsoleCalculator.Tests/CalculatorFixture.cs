using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator _calculator;
        public CalculatorFixture()
        {
            _calculator = new Calculator();
        }

        private string SendMultipleKey(char[] key)
        {
            var i = 0;
            for (i = 0; i < key.Length - 1; i++)
                _calculator.SendKeyPress(key[i]);
            return _calculator.SendKeyPress(key[i]);
        }


        [Fact]
        public void Send_KeyPress_With_Value_1_Should_Return_1()
        {
            char key = '1';

            string fromCall = _calculator.SendKeyPress(key);

            Assert.Equal("1", fromCall);
        }

        [Fact]
        public void Send_MultipleKeyPress_Should_Return_12()
        {
            char[] key = new char[] { 'h', '1', '2' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("12", fromCall);
        }

        [Fact]
        public void Send_ZeroKeySequence_Should_Return_0()
        {
            char[] key = new char[] { 'h', '0', '0','0' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("0", fromCall);
        }

        [Fact]
        public void Send_DecimalKeySequence_Should_Return_SingleDecimal()
        {
            char[] key = new char[] { 'h', '0', '.', '.' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("0.", fromCall);
        }

        [Fact]
        public void Send_DecimalKey_InBlankScreen_Return_ZeroAndDecimal()
        {
            char[] key = new char[] { 'h', '.', '.' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("0.", fromCall);
        }


        [Fact]
        public void Send_MultipleKey_With_An_Operator()
        {
            char[] key = new char[] { 'h', '1', '2','+' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("12", fromCall);
        }

        [Fact]
        public void Send_An_ArithmeticEquation_Should_Return_LastValue()
        {
            char[] key = new char[] { 'h', '1', '2', '+','1' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("1", fromCall);
        }
        [Fact]
        public void Send_SignChangeKeyTwice_Return_OriginalValue()
        {
            char[] key = new char[] { 'h', '1', 's','s' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("1", fromCall);
        }

        [Fact]
        public void Send_AdditionEquation_Should_Return_Addition()
        {
            char[] key = new char[] { 'h', '1', '2', '+', '1' ,'='};

            string fromCall = SendMultipleKey(key);

            Assert.Equal("13", fromCall);
        }

        [Fact]
        public void Send_ErroniousDivision_Should_Return_Error()
        {
            char[] key = new char[] { 'h', '1', '/', '0','='};

            string fromCall = SendMultipleKey(key);

            Assert.Equal("-E-", fromCall);
        }

        [Fact]
        public void Send_ArithmeticEquationWithSign_Should_Return_4()
        {
            char[] key = new char[] { 'h', '1', '+', '3','s','S' ,'=' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("4", fromCall);
        }

        [Fact]
        public void Send_MultipleKey_And_C_Should_Return_0()
        {
            char[] key = new char[] { '1', '+', '2', '+', 'C' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("0", fromCall);
        }

        [Fact]
        public void Send_Arithmetic_Equation_WithEqualSign_Should_Return_12()
        {
            char[] key = new char[] { '1', '+', '2', '+', '3','+','=' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("12", fromCall);
        }

        [Fact]
        public void Send_Complex_Arithmetic_Equation_WithEqualSign_Return_10()
        {
            char[] key = new char[] { '1','2' ,'+', '2', 'S', 's', 'S', '=' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("10", fromCall);
        }

        [Fact]
        public void Send_Multiple_ZeroKey_And_DecimalKey_Should_Return_ValidValue()
        {
            char[] key = new char[] { '0', '0', '.', '.', '0', '0', '1' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("0.001", fromCall);
        }

        [Fact]
        public void Send_TwoDecimal_In_A_Number_Should_Return_Error()
        {
            char[] key = new char[] { '1', '.', '0', '0', '.', '1', '+','2','=' };

            string fromCall = SendMultipleKey(key);

            Assert.Equal("-E-", fromCall);
        }
    }
}
