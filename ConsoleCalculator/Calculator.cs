using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        string firstNumber = "";
        string secondNumber = "";
        char? operation = null;
        int countOperators = 0;
        int flagForFirst = 0;
        int flagForSecond = 0;
        public string SendKeyPress(char key)
        {
            if (isValidCharacters(key))
            {
                if (key >= '0' && key <= '9')              //for digits
                {
                    if (countOperators == 0)             //for first number
                    {
                        if (!(firstNumber == "0" && key == '0'))
                        {
                            firstNumber = firstNumber + key;
                        }
                    }
                    else                           //for second number
                    {
                        if (!(secondNumber == "0" && key == '0'))
                        {
                            secondNumber = secondNumber + key;
                        }
                        return secondNumber;
                    }
                }
                else if (isValidOperator(key))
                {
                    countOperators = countOperators + 1;
                    if (countOperators == 2)
                    {
                        calculateOperation();
                        secondNumber = "";
                        countOperators = countOperators - 1;
                    }
                    operation = key;
                }
                else if (key == '=')
                {
                    calculateOperation();
                    countOperators = countOperators - 1;
                }
                else if (key == '.')
                {
                    if (countOperators == 0 && flagForFirst == 0)                    //for first number
                    {
                        if (firstNumber.Length == 0)
                        {
                            firstNumber = firstNumber + "0.";
                        }
                        else
                        {
                            firstNumber = firstNumber + ".";
                        }
                        flagForFirst = 1;
                    }
                    else if (countOperators == 1 && flagForSecond == 0)               //for second number
                    {
                        if (secondNumber.Length == 0)
                        {
                            secondNumber = secondNumber + "0.";
                        }
                        else
                        {
                            secondNumber = secondNumber + ".";
                        }
                        flagForSecond = 1;
                    }
                }
                else if (key == 'c' || key == 'C')
                {
                    firstNumber = "0";
                    secondNumber = "0";
                    countOperators = 0;
                    operation = null;
                    flagForFirst = 0;
                    flagForSecond = 0;
                }
                else if (key == 's' || key == 'S')
                {
                    if (countOperators == 1)
                    {
                        secondNumber = (-double.Parse(secondNumber)).ToString();
                    }
                    else
                    {
                        firstNumber = (-double.Parse(secondNumber)).ToString();
                    }
                }
                return firstNumber;
            }
            else
            {
                return firstNumber;
            }
            throw new NotImplementedException();
        }
        public void calculateOperation()
        {
            if(operation == '+')
            {
                firstNumber = (double.Parse(firstNumber) + double.Parse(secondNumber)).ToString();
            }
            else if(operation == '-')
            {
                firstNumber = (double.Parse(firstNumber) - double.Parse(secondNumber)).ToString();
            }
            else if(operation == '/')
            {
                if(secondNumber == "0")
                {
                    firstNumber = "-E-";
                }
                else
                {
                    firstNumber = (double.Parse(firstNumber) / double.Parse(secondNumber)).ToString();
                }
            }
            else if(operation == '*' || operation == 'X')
            {
                firstNumber = (double.Parse(firstNumber) * double.Parse(secondNumber)).ToString();
            }
        }
        public bool isValidOperator(char key)
        {
            if(key == '+' || key == '-' || key == '/' || key == '*')
            {
                return true;
            }
            return false;
        }
        public bool isValidCharacters(char key)
        {
            if(char.IsDigit(key) || isValidOperator(key) || key == '=' || key =='.' || key == 's' ||key == 'S' || key == 'c' || key == 'C')
            {
                return true;
            }
            return false;
        }
    }
}
