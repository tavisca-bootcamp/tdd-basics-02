using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private List<Char> allowedOperators = new List<char>
        {
             '-', '+', 'x','X', '/', 's', 'S','c','C'
        };

        private string firstNumber = "";
        private string secondNumber = "";
        private char? operation = null;
        private int operatorPressed = 0;

        public string SendKeyPress(char key)
        {
            if (IsValid(key))
            {
                if (char.IsDigit(key))
                {
                    if (operatorPressed == 0)
                    {
                        if (!(firstNumber.Equals("0") && key == '0'))
                        {
                            firstNumber += key;
                        }
                    }
                    else
                    {
                        if (!(secondNumber.Equals("0") && key == '0'))
                        {
                            secondNumber += key;
                        }

                        return secondNumber;
                    }
                }
                else if (key.Equals('='))
                {
                    ComputeResult();
                    operatorPressed -= 1;
                }

                else if (allowedOperators.Contains(key))
                {
                    operatorPressed += 1;
                    if (operatorPressed == 2) //checking if already an operator is present
                    {
                        ComputeResult();
                        secondNumber = "";
                        operatorPressed -= 1;
                    }
                    operation = key;
                }

                return firstNumber;
            }
            else
            {
                return firstNumber;
            }
        }

        private void ComputeResult()
        {
            switch (operation)
            {
                case '+':
                    firstNumber = (double.Parse(firstNumber) + double.Parse(secondNumber)).ToString();
                    break;
                case '-':
                    firstNumber = (double.Parse(firstNumber) - double.Parse(secondNumber)).ToString();
                    break;
                case 'x':
                case 'X':
                    firstNumber = (double.Parse(firstNumber) * double.Parse(secondNumber)).ToString();
                    break;
                case '/':
                   firstNumber = (double.Parse(firstNumber) / double.Parse(secondNumber)).ToString();
                    break;
            }
        }
        private bool IsValid(char key)
        {
            if (char.IsDigit(key) || allowedOperators.Contains(key) || key == '.' || key.Equals('='))
            {
                return true;
            }
            return false;
        }
    }
}
