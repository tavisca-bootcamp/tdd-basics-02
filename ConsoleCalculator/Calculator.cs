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
                if (isDigit(key))              //for digits
                {
                    if (countOperators == 0)             //for first number
                    {
                        firstNumber = returnFirstNum(key, firstNumber);
                    }
                    else                           //for second number
                    {
                        secondNumber = returnSecondNum(key, secondNumber);
                        return secondNumber;
                    }
                }
                else if (isValidOperator(key))
                {
                    countOperators = countOperators + 1;
                    if (countOperators == 2)                //if stored operator is more than 1 than evaluates last operator first
                    {
                        calculateOperation();
                        secondNumber = "";
                        countOperators = countOperators - 1;
                    }
                    operation = key;
                }
                else if (key == '=')                 //if operator is '=' than it calculate the equation
                {
                    calculateOperation();
                    countOperators = countOperators - 1;
                }
                else if (key == '.')
                {
                    if (countOperators == 0 && flagForFirst == 0)                    //for first number
                    {
                        firstNumber = returnDotFirstNum(firstNumber);
                        flagForFirst = 1;
                    }
                    else if (countOperators == 1 && flagForSecond == 0)               //for second number
                    {
                        secondNumber = returnDotSecondNum(secondNumber);
                        flagForSecond = 1;
                    }
                }
                else if (key == 'c' || key == 'C')                  // for clear
                {
                    firstNumber = "0";
                    secondNumber = "0";
                    countOperators = 0;
                    operation = null;
                    flagForFirst = 0;
                    flagForSecond = 0;
                }
                else if (key == 's' || key == 'S')               //for toggle
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
        }

        public static string returnFirstNum(char key, string firstNumber)    //for return first number
        {
            if (!(firstNumber == "0" && key == '0'))
            {
                firstNumber = firstNumber + key;
            }
            return firstNumber;
        }

        public static string returnSecondNum(char key, string secondNumber)    //for return second number
        {
            if (!(secondNumber == "0" && key == '0'))
            {
                secondNumber = secondNumber + key;
            }
            return secondNumber;
        }

        public Boolean isDigit(char key)        //to check whether it is digit or not
        {
            if (key >= '0' && key <= '9')
            {
                return true;
            }
            return false;
        }

        public string returnDotFirstNum(string firstNumber)
        {
            if (firstNumber.Length == 0)
            {
                firstNumber = firstNumber + "0.";
            }
            else
            {
                firstNumber = firstNumber + ".";
            }
            return firstNumber;
        }

        public string returnDotSecondNum(string secondNumber)
        {
            if (secondNumber.Length == 0)
            {
                secondNumber = secondNumber + "0.";
            }
            else
            {
                secondNumber = secondNumber + ".";
            }
            return secondNumber;
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
