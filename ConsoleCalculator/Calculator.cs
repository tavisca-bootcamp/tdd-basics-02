using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string updatedDisplay = "";
        private bool firstOperandAvailable = false;
        private bool clearUpdatedDisplay = false;
        private float answer = 0;
        private int currentOperation;

        public enum operation
        {
            addition,
            subtraction,
            multiplication,
            division
        }

        public string SendKeyPress(char key)
        {
            List<char> digits = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
            List<char> operators = new List<char>() { '+', '-', 'x', 'X', '/', '=' };
            List<char> defaultChars = new List<char>() { 's', 'S', 'c', 'C' };
            try
            {
                if (digits.Contains(key))
                {
                    ClearDisplayIfNewOperand();
                    if ((key == '0' && updatedDisplay != "0") || (key == '.' && updatedDisplay[updatedDisplay.Length - 1] != '.') || (key != '0' && key != '.'))
                    {
                        updatedDisplay += key.ToString();
                    }
                }
                else if (operators.Contains(key))
                {
                    if (key == '+')
                    {
                        currentOperation = (int)operation.addition;
                        UpdateDisplay();
                        clearUpdatedDisplay = true;
                    }
                    else if (key == '-')
                    {
                        ClearDisplayIfNewOperand();
                        if (updatedDisplay == "")
                        {
                            updatedDisplay += "-";
                        }
                        else
                        {
                            currentOperation = (int)operation.subtraction;
                            UpdateDisplay();
                            clearUpdatedDisplay = true;
                        }
                    }
                    else if (key == 'x' || key == 'X')
                    {
                        currentOperation = (int)operation.multiplication;
                        UpdateDisplay();
                        clearUpdatedDisplay = true;
                    }
                    else if (key == '/')
                    {
                        currentOperation = (int)operation.division;
                        UpdateDisplay();
                        clearUpdatedDisplay = true;
                    }
                    else if (key == '=')
                    {
                        firstOperandAvailable = true;
                        UpdateDisplay();
                    }
                }
                else if(defaultChars.Contains(key))
                {
                    if(key == 's' || key == 'S')
                    {
                        if(updatedDisplay.Contains("-"))
                        {
                            updatedDisplay = updatedDisplay.Substring(1);
                        }
                        else
                        {
                            updatedDisplay = "-" + updatedDisplay;
                        }
                    }
                    else if(key == 'c' || key == 'C')
                    {
                        updatedDisplay = "0";
                    }
                }
                return updatedDisplay;
            }
            catch(Exception)
            {
                return "-E-";
            }
        }

        private void UpdateDisplay()
        {
            if (firstOperandAvailable == false)
            {
                answer = float.Parse(updatedDisplay);
                firstOperandAvailable = true;
            }
            else
            {
                PerformArithmeticOperations();
                if (float.IsInfinity(answer))
                {
                    updatedDisplay = "-E-";
                }
                else
                {
                    updatedDisplay = answer.ToString();
                }
            }
        }

        private void ClearDisplayIfNewOperand()
        {
            if (clearUpdatedDisplay)
            {
                updatedDisplay = "";
                clearUpdatedDisplay = false;
            }
        }

        private void PerformArithmeticOperations()
        {
            if(currentOperation == 0)
            {
                answer += float.Parse(updatedDisplay);
            }
            else if (currentOperation == 1)
            {
                answer -= float.Parse(updatedDisplay);
            }
            else if (currentOperation == 2)
            {
                answer *= float.Parse(updatedDisplay);
            }
            else if (currentOperation == 3)
            {
                answer /= float.Parse(updatedDisplay);
            }
        }
    }
}
