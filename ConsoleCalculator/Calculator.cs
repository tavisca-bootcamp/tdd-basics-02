using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string displayValue;
        public char[] operators = { '.', '+', '-', '/', 'x', 's', 'c', '=' };
        public decimal currentOperand=0;
        public char currentOperator;
        public decimal result;

    public string SendKeyPress(char key)
        {
            if (Char.IsDigit(key))
            {
                DigitHandle(key);
            }

            if (IsOperator(key))
            {
                OperatorHandle(key);
            }

            return ShowDisplayValue();
        }

        public void DigitHandle(char key)
        {
            currentOperand = decimal.Parse(currentOperand.ToString() + key);
            if (currentOperand > 0)
            {
                SetDisplayValue(currentOperand.ToString());
            }
            else
            {
                SetDisplayValue(displayValue + key);
            }

        }

        public void OperatorHandle(char key)
        {
            switch (key)
            {
                case '+':
                    SetDisplayValue("+");
                    HandleArithmeticOperation(key);
                    break;
                case '-':
                case '/':
                case 'x':
                case '=':
                    HandleArithmeticOperation(key);
                    break;
                default:
                    break;
            }
        }

        public void HandleArithmeticOperation(char key)
        {
            if (currentOperator == '\0')
            {
                currentOperator = key;
                result = currentOperand;
                currentOperand = 0;
            }
            else
            {
                PerformsArithmeticOperation(key);
            }
        }

        public void PerformsArithmeticOperation(char key)
        {
            switch (currentOperator)
            {
                case '+':
                    result += currentOperand;
                    SetDisplayValue(result.ToString());
                    break;
                default:
                    break;

            }
        }

        public bool IsOperator(char key)
        {
            return Array.Exists(operators, element => element == key);
        }

        public void SetDisplayValue(string value)
        {
            displayValue = value;
        }

        public string ShowDisplayValue()
        {
            return displayValue;
        }
    }
}
