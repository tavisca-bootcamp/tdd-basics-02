using System;

namespace ConsoleCalculator
{
    class InvalidInputDigitException : Exception
    {
        public InvalidInputDigitException(string message) : base(message)
        {
        }
    }
    public class Calculator
    {

        string operand1 = "0";
        string operand2 = "";
        char previousOperator = '+';
        string displayOutput = "0";
        bool isDecimalEncountered = false;
        string previousOperandResult = "";

        public string SendKeyPress(char key)
        {
            string output = "0";
            try
            {
                output = validateAndPerformOperationsForKey(key);
            }
            catch (InvalidInputDigitException)
            {
                output = displayOutput;
            }
            catch (DivideByZeroException)
            {
                output = "-E-";
            }
            return output;
        }

        private string validateAndPerformOperationsForKey(char key)
        {
            if (isClearKey(key))
            {
                resetCalculatorAtInitialStage();
                displayOutput = "0";
            }
            else if (isToggleKey(key))
            {
                toggleSignOfOperand();
                displayOutput = operand2;
            }
            else if (isDecimalOperator(key))
            {
                if (!isDecimalEncountered)
                {
                    operand2 = operand2 + key;
                    isDecimalEncountered = true;
                    displayOutput = operand2;
                }
            }
            else if (isValidOperator(key))
            {
                isDecimalEncountered = false;
                if (key == '=' && operand2 == "")
                    operand2 = previousOperandResult;
                performPreviousOperation();
                displayOutput = operand1;
                // operand1 = operand2;
                
                if (key != '=')
                {
                    previousOperator = key;
                    previousOperandResult = operand1;
                }else{
                    previousOperandResult = operand2;
                }
                operand2 = "";
            }
            else if (isValidDigit(key))
            {
                if (key == '0')
                    validateZerosConditions(key);
                else
                    operand2 = operand2 + key;
                displayOutput = operand2;
            }
            else
            {
                throw new InvalidInputDigitException($"Invalid digit '{key}' is passed in the Input Field");
            }
            return displayOutput;
        }

        private void validateZerosConditions(char key)
        {
            if (isDecimalEncountered)
            {
                operand2 = operand2 + key;
            }
            else
            {
                operand2 = Int32.Parse(operand2 + key).ToString();
            }
        }

        private bool isDecimalOperator(char key)
        {
            return key == '.';
        }

        private void toggleSignOfOperand()
        {
            operand2 = (-1 * Double.Parse(operand2)).ToString();
        }

        private bool isToggleKey(char key)
        {
            return key == 'S' || key == 's';
        }

        private bool isClearKey(char key)
        {
            return key == 'C' || key == 'c';
        }

        private void resetCalculatorAtInitialStage()
        {
            operand1 = "0";
            operand2 = "";
            previousOperator = '+';
            displayOutput = "0";
            isDecimalEncountered = false;
            previousOperandResult = "";
        }

        private void performPreviousOperation()
        {
            if (operand2 == "")
                return;
            switch (previousOperator)
            {
                case '+':
                    operand1 = (Double.Parse(operand1) + Double.Parse(operand2)).ToString();
                    break;
                case '-':
                    operand1 = (Double.Parse(operand1) - Double.Parse(operand2)).ToString();
                    break;
                case 'X':
                case 'x':
                    operand1 = (Double.Parse(operand1) * Double.Parse(operand2)).ToString();
                    break;
                case '/':
                    if (operand2 == "0")
                        throw new DivideByZeroException("Can't Divide By Zero");
                    operand1 = (Double.Parse(operand1) / Double.Parse(operand2)).ToString();
                    break;
                // case '=':
                //     operand2 = operand1;
                //     break;
                default:
                    Console.WriteLine("Invalid Operator");
                    break;
            }
        }
        private bool isValidDigit(char key)
        {
            if (key >= '0' && key <= '9')
                return true;
            return false;
        }

        private bool isValidOperator(char key)
        {
            if (key == '+' || key == '-' || key == 'x' || key == 'X' || key == '/' || key == '=')
                return true;
            return false;
        }
    }
}
