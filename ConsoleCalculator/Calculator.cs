using System;

namespace ConsoleCalculator
{
    public class Calculator
    {

        private char currentOperator;
        private decimal result;
        private string displayValue;
        private decimal currentOperand;
        private char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] operators = new char[] { '.', '+', '-', '/', 'x', 's', 'c', '=' };
        public string DisplayValue { get => displayValue; set => displayValue = value; }
        public decimal Result { get => result; set => result = value; }
        public char[] Digits { get => digits; set => digits = value; }
        public char[] Operators { get => operators; set => operators = value; }
        public decimal CurrentOperand { get => currentOperand; set => currentOperand = value; }
        public char CurrentOperator { get => currentOperator; set => currentOperator = value; }

        public void PressSingleKey(char key)
        {
            if (IsDigit(key))
            {
                this.HandleDigit(key);
            }

            if (IsOperator(key))
            {
                this.HandleOperator(key);
            }
        }



    }
}