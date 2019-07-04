using System;
namespace ConsoleCalculator
{
    public class Calculator
    {
        private string operand1 = "0";
        private string operand2 = "";
        private char Operator = '+';
        private bool isDecimalEncountered = false;
        public string SendKeyPress(char key)
        {
            string result = "0";

            try
            {
                if (key.ToString().ToUpper() == "C")
                {
                    reset();
                }
                else if (key.ToString().ToUpper() == "S")
                {
                    toggleSign();
                    result = operand2;
                }
                else if (key == '.' && !isDecimalEncountered)
                {
                    operand2 = operand2 + key;
                    isDecimalEncountered = true;
                    result = operand2;
                }
                else if (isDigit(key))
                {
                    if (key == '0' && !isDecimalEncountered)
                        operand2 = Int32.Parse(operand2 + key).ToString();
                    else
                        operand2 = operand2 + key;
                    result = operand2;
                }
                else if (isOperator(key))
                {
                    isDecimalEncountered = false;
                    performPreviousOperation();
                    result = operand1;
                    if (key != '=')
                        Operator = key;
                    operand2 = "";
                }

            }
            catch (DivideByZeroException)
            {
                result = "-E-";
            }

            return result;
        }

        private bool isDigit(char key)
        {
            return (key <= '9' && key >= '0') ? true : false;
        }

        private bool isOperator(char key)
        {
            return (key == '+' || key == '-' || key == 'x' || key == 'X' || key == '/' || key == '=') ? true : false;
        }

        private void reset()
        {
            operand1 = "0";
            operand2 = "";
            Operator = '+';
            isDecimalEncountered = false;
        }

        private void toggleSign()
        {
            double d = -Double.Parse(operand2);
            operand2 = d.ToString();
        }

        private void performPreviousOperation()
        {
            if (operand2 == "")
                return;
            switch (Operator)
            {
                case '+':
                    operand1 = (Double.Parse(operand1) + Double.Parse(operand2)).ToString();
                    break;
                case '-':
                    operand1 = (Double.Parse(operand1) - Double.Parse(operand2)).ToString();
                    break;
                case '/':
                    if (operand2 == "0")
                        throw new DivideByZeroException();
                    operand1 = (Double.Parse(operand1) / Double.Parse(operand2)).ToString();
                    break;
                case 'x':
                case 'X':
                    operand1 = (Double.Parse(operand1) * Double.Parse(operand2)).ToString();
                    break;
                
            }
        }

    }
}