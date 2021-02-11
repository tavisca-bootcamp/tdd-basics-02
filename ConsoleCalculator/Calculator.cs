using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
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
            string resultString = "0";
            if (IsValidKey(key))
            {
                try
                {
                    resultString = PerformOperation(key);
                }
                catch (DivideByZeroException) { 
                    resultString = "-E-";
                }
            }
            return resultString;
        }

        private string PerformOperation(char key)
        {
            if (char.ToLower(key) == 'c')
            {
                Reset();
                displayOutput = "0";
            }
            else if (char.ToLower(key) == 's')
            {
                Toggle();
                displayOutput = operand2;
            }
            else if (key == '.')
            {
                if (!isDecimalEncountered)
                {
                    operand2 = operand2 + key;
                    isDecimalEncountered = true;
                    displayOutput = operand2;
                }
            }
            else if (IsValidOperator(key))
            {
                isDecimalEncountered = false;
                if (key == '=' && operand2 == "")
                    operand2 = previousOperandResult;
                PerformPreviousOperation();
                displayOutput = operand1;

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
            else if (IsValidDigit(key))
            {
                if (key == '0')
                    HandleZeroes(key);
                else
                    operand2 = operand2 + key;
                displayOutput = operand2;
            }
            return displayOutput;
        }

        private void HandleZeroes(char key)
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

        private void Toggle()
        {
            operand2 = (-1 * Double.Parse(operand2)).ToString();
        }

        private void Reset()
        {
            operand1 = "0";
            operand2 = "";
            previousOperator = '+';
            displayOutput = "0";
            isDecimalEncountered = false;
            previousOperandResult = "";
        }

        private void PerformPreviousOperation()
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
                        throw new DivideByZeroException();
                    operand1 = (Double.Parse(operand1) / Double.Parse(operand2)).ToString();
                    break;
            }
        }
        private bool IsValidDigit(char key)
        {
            List<char> validNumbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return validNumbers.Contains(key) ? true : false;
        }

        private bool IsValidOperator(char key)
        {
            List<char> validOperators = new List<char> { '+', '-', 'x', 'X', '/','=' };
            return validOperators.Contains(key) ? true : false;
        }

        private bool IsValidKey(char key)
        {
            List<char> validKeys = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-', '+', 'x', 'X', '/', 's', 'S', 'c', 'C', '=' };
            return validKeys.Contains(key) ? true : false;
        }
    }
}