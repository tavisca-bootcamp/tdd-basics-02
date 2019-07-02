using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Operations
    {
        public string firstNumber = "";
        public string secondNumber = "";
        public string output = "0";
        public char previousOperator = '?';
        public string AddDigitExceptZero(char digit)
        {
            if (previousOperator == '?')
            {
                if (firstNumber == "")
                    firstNumber = digit.ToString();
                else
                    firstNumber += digit;
                output = firstNumber;
            }
            else
            {
                if (secondNumber == "")
                    secondNumber = digit.ToString();
                else
                    secondNumber += digit;
                output = secondNumber;
            }
            return output;
        }
        public string AddZero()
        {
            if (previousOperator != '?' && secondNumber == "")
            {
                output = "0";
                secondNumber = output;
            }
            else if (secondNumber == "" && firstNumber == "")
            {
                output = "0";
            }
            else if (firstNumber != "" && secondNumber == "")
            {
                firstNumber = firstNumber + "0";
                output = firstNumber;
            }
            else if (secondNumber != "")
            {
                secondNumber += "0";
                output = secondNumber;
            }

            return output;
        }
        public string Operator(char key)
        {
            switch (key)
            {
                case '+':
                    return Addition();
                case '-':
                    return Subtraction();
                case 'x':
                case 'X':
                    return Multiplication();
                case '/':
                    return Divide();
                default:
                    return output;
            }

        }
        public string Addition()
        {
            if (previousOperator == '?')
            {
                if (firstNumber == "")
                    firstNumber = "";
                else
                    previousOperator = '+';
            }
            else
            {
                if (previousOperator == '+')
                {
                    if (firstNumber != "" && secondNumber == "")
                    {
                        output = firstNumber;
                        return output;
                    }
                    else
                    {
                        firstNumber = (decimal.Parse(firstNumber) + decimal.Parse(secondNumber)).ToString();
                        secondNumber = "";
                        return firstNumber;
                    }
                }
                else
                {
                    output = Operator(previousOperator);
                    previousOperator = '+';
                }
            }
            return output;
        }
        public string Subtraction()
        {
            if (previousOperator == '?')
            {
                if (firstNumber == "")
                    firstNumber = "-";
                else
                    previousOperator = '-';
            }
            else
            {
                if (previousOperator == '-')
                {
                    if (firstNumber != "" && secondNumber == "")
                    {
                        output = firstNumber;
                        return output;
                    }
                    else
                    {
                        firstNumber = (decimal.Parse(firstNumber) - decimal.Parse(secondNumber)).ToString();
                        secondNumber = "";
                    }

                    return firstNumber;
                }
                else
                {
                    output = Operator(previousOperator);
                    previousOperator = '-';
                }
            }
            return output;
        }
        public string Multiplication()
        {
            if (previousOperator == '?')
            {
                if (secondNumber == "")
                    previousOperator = 'x';
            }
            else
            {
                if (previousOperator == 'x' || previousOperator == 'X')
                {
                    firstNumber = (decimal.Parse(firstNumber) * decimal.Parse(secondNumber)).ToString();
                    secondNumber = "";
                    return firstNumber;
                }
                else
                {
                    output = Operator(previousOperator);
                    previousOperator = 'x';
                }
            }
            return output;
        }
        public string Divide()
        {
            if (previousOperator == '?')
            {
                if (secondNumber == "")
                    previousOperator = '/';
            }
            else
            {
                if (previousOperator == '/')
                {
                    try
                    {
                        firstNumber = (decimal.Parse(firstNumber) / decimal.Parse(secondNumber)).ToString();
                        secondNumber = "";
                        return firstNumber;
                    }
                    catch
                    {
                        return "-E-";
                    }

                }
                else
                {
                    output = Operator(previousOperator);
                    previousOperator = '/';
                }
            }
            return output;
        }
        public string Equals()
        {

            if (previousOperator != '?')
            {
                String o = Operator(previousOperator);
                previousOperator = '?';
                output = o;
            }

            return output;
        }
        public string Toggle()
        {
            float temp = 0;

            float.TryParse(output, out temp);
            output = (-temp).ToString();
            if (secondNumber == "")
                firstNumber = output;
            else
                secondNumber = output;
            return output;
        }
        public string Clear()
        {
            firstNumber = "";
            secondNumber = "";
            output = "0";
            previousOperator = '?';
            return output;
        }
        public string PerformDecimalOperation()
        {
            if (secondNumber == "" && firstNumber == "")
            {
                int t;
                if (int.TryParse(output, out t) == true)
                {
                    output += ".";
                    firstNumber = output;
                }
            }
            else if (secondNumber == "" && firstNumber != "")
            {
                int t;
                if (int.TryParse(firstNumber, out t) == true)
                {
                    firstNumber += ".";
                    output = firstNumber;
                }
            }
            else
            {
                int t;
                if (int.TryParse(secondNumber, out t) == true)
                {
                    secondNumber += ".";
                    output = secondNumber;
                }
            }
            return secondNumber;
        }

    }
}