using System;

namespace ConsoleCalculator
{
    class InvalidDigitException : Exception
    {
        public InvalidDigitException(string message) : base(message)
        {
        }
    }
    public class Calculator
    {
        string operand1 = "0";
        string operand2 = "";
        char previousOperator = '+';
        string outputOnScreen = "0";
        bool isDecimalOccured = false;
        string previousOperandResult = "";
        private void resetCalculator()
        {
            operand1 = "0";
            operand2 = "";
            previousOperator = '+';
            outputOnScreen = "0";
            isDecimalOccured = false;
            previousOperandResult = "";
        }
        public string SendKeyPress(char key)
        {
            string result = "0";
            try
            {
                result = PerformOperationOnKeyPressed(key);
            }
            catch (InvalidDigitException)
            {
                result = outputOnScreen;
            }
            catch (DivideByZeroException)
            {
                result = "-E-";
            }
            return result;
        }

        private string PerformOperationOnKeyPressed(char key)
        {
            if (InputHandler.isClearKey(key))
            {
                resetCalculator();
                outputOnScreen = "0";
            }
            else if (InputHandler.isToggleKey(key))
            {
                toggleSign();
                outputOnScreen = operand2;
            }
            else if (InputHandler.isDecimalPoint(key))
            {
                if (!isDecimalOccured)
                {
                    operand2 = operand2 + key;
                    isDecimalOccured = true;
                    outputOnScreen = operand2;
                }
            }
            else if (InputHandler.isValidOperator(key))
            {
                isDecimalOccured = false;
                if (key == '=' && operand2 == "")
                    operand2 = previousOperandResult;
                ComputeOperation();
                outputOnScreen = operand1;

                if (key != '=')
                {
                    previousOperator = key;
                    previousOperandResult = operand1;
                }
                else
                {
                    previousOperandResult = operand2;
                }
                operand2 = "";
            }
            else if (InputHandler.isValidDigit(key))
            {
                if (key == '0')
                    HandleInputZero(key);
                else
                    operand2 = operand2 + key;
                outputOnScreen = operand2;
            }
            else
            {
                throw new InvalidDigitException($"Invalid digit '{key}' pressed");
            }
            return outputOnScreen;
        }
        private void HandleInputZero(char key)
        {
            if (isDecimalOccured)
            {
                operand2 = operand2 + key;
            }
            else
            {
                operand2 = Int32.Parse(operand2 + key).ToString();
            }
        }
        private void toggleSign()
        {
            operand2 = (-1 * Double.Parse(operand2)).ToString();
        }
        private void ComputeOperation()
        {
            if (operand2 == "")
                return;
            double tempOperand1 = Double.Parse(operand1);
            double tempOperand2 = Double.Parse(operand2);

            switch (previousOperator)
            {
                case '+':
                    operand1 = Operation.Add(tempOperand1, tempOperand2).ToString();
                    break;
                case '-':
                    operand1 = Operation.Subtract(tempOperand1, tempOperand2).ToString();
                    break;
                case 'X':
                case '*':
                case 'x':
                    operand1 = Operation.Multiply(tempOperand1, tempOperand2).ToString();
                    break;
                case '/':
                    if (operand2 == "0")
                        throw new DivideByZeroException("Can't Divide By Zero");
                    operand1 = Operation.Divide(tempOperand1, tempOperand2).ToString();
                    break;
            }
        }
    }
}
