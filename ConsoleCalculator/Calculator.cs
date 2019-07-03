using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string displayValue;
        public char[] operators = { '.', '+', '-', '/', '*', 's', 'c', '=' };
        public decimal currentOperand;
        public char currentOperator;
        public decimal result;

    public string SendKeyPress(char key)
        {
            if (Char.IsDigit(key))
            {
                HandleDigit(key);
            }

            if (IsOperator(key))
            {
                HandleOperator(key);
            }

            return GetDisplayValue();
        }

        public void HandleDigit(char key)
        {
            //Check if diplayed value contains '.' then simply add new digit to it
            if (!string.IsNullOrEmpty(displayValue) && displayValue.Contains("."))
            {
                SetDisplayValue(displayValue + key);
            }
            else
            {
                currentOperand = decimal.Parse(currentOperand.ToString() + key);
                SetDisplayValue(currentOperand.ToString());
            }

        }

        public void HandleOperator(char key)
        {
            switch (key)
            {
                case '+':
                    SetDisplayValue("+");
                    HandleArithmeticOperation(key);
                    break;
                case '-':
                    SetDisplayValue("-");
                    HandleArithmeticOperation(key);
                    break;
                case '/':
                    SetDisplayValue("/");
                    HandleArithmeticOperation(key);
                    break;
                case '*':
                    SetDisplayValue("*");
                    HandleArithmeticOperation(key);
                    break;
                case '=':
                    HandleArithmeticOperation(key);
                    break;
                case 'c':
                    Reset();
                    break;
                case 's':
                    ToggleSign();
                    break;
                case '.':
                    SetDisplayValue(displayValue + ".");
                    break;
                default:
                    break;
            }
        }

        public void HandleArithmeticOperation(char key)
        {
            //Check for first operator
            if (currentOperator == '\0')
            {
                currentOperator = key;
                result = currentOperand;
                currentOperand = 0;
            }
            else
            {
                PerformArithmeticOperation(key);
            }
        }

        public void PerformArithmeticOperation(char key)
        {
            switch (currentOperator)
            {
                case '+':
                    //Equalto after operand doubles the value
                    if (currentOperand > 0)
                    {
                        result += currentOperand;
                    }
                    else
                    {
                        result *= 2;
                    }
                    
                    SetDisplayValue(result.ToString());
                    break;

                case '-':
                    result -= currentOperand;
                    SetDisplayValue(result.ToString());
                    break;

                case '/':
                    if (currentOperand == 0)
                    {
                        displayValue = "-E-";
                    }
                    else
                    {
                        result /= currentOperand;
                        SetDisplayValue(result.ToString());
                    }
                    break;

                case '*':
                    result *= currentOperand;
                    SetDisplayValue(result.ToString());
                    break;
                default:
                    break;

            }

            currentOperand = 0;
            currentOperator = key;
        }

        public void ToggleSign()
        {
            currentOperand = decimal.Negate(currentOperand);
            SetDisplayValue(currentOperand.ToString());
        }

        public void Reset()
        {
            currentOperand = 0;
            result = 0;
            displayValue = 0.ToString();
            currentOperator = '\0';
        }

        public bool IsOperator(char key)
        {
            return Array.Exists(operators, element => element == key);
        }

        public void SetDisplayValue(string value)
        {
            displayValue = value;
        }

        public string GetDisplayValue()
        {
            return displayValue;
        }
    }
}
