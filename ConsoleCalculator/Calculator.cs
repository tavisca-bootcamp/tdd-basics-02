﻿using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        static string number = "";
        static string operation = "";
        static string secondNumber = "";

        public string SendKeyPress(char key)
        {
            switch(key)
            {
                case 'c':
                case 'C':
                    ResetAll();
                    return "0";
                case '.':
                case 'S':
                case 's':
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return ShowNumber(key);
                
                case '+':
                    SetCalculationSymbol(key);
                    break;
                case '-':
                    SetCalculationSymbol(key);
                    break;
                case 'x':
                    SetCalculationSymbol(key);
                    break;
                case '/':
                    SetCalculationSymbol(key);
                    break;
                case '=':
                    if (operation != "")
                    {
                        string previousOperation = operation;
                        operation = "";
                        return DoCalculation(previousOperation);
                    }
                    break;
                default:
                    return "";
                
            }

            return number;
        }

        private string DoCalculation(string operation)
        {
            string answer="";
            if(operation == "+")
            {
                try
                {
                    answer =  (double.Parse(number) + double.Parse(secondNumber)).ToString();
                    secondNumber = "";
                    number = answer;
                }
                catch(FormatException e)
                {
                    secondNumber = number;
                    return DoCalculation(operation);
                }
                
            }
            else if(operation == "-")
            {
                try
                {
                    answer = (double.Parse(number) - double.Parse(secondNumber)).ToString();
                    secondNumber = "";
                    number = answer;
                }
                catch(FormatException e)
                {
                    secondNumber = number;
                    return DoCalculation(operation);
                }
            }
            else if(operation == "/")
            {
                if (secondNumber == "0")
                {
                    return "-E-";
                }
                else
                {
                    try
                    {
                        answer = (double.Parse(number) / double.Parse(secondNumber)).ToString();
                        secondNumber = "";
                        number = answer;
                    }
                    catch(Exception e)
                    {
                        secondNumber = number;
                        return DoCalculation(operation);
                    }
                }
            }
            else if(operation == "x")
            {
                try
                {
                    answer = (double.Parse(number) * double.Parse(secondNumber)).ToString();
                    secondNumber = "";
                    number = answer;
                }
                catch(Exception e)
                {
                    secondNumber = number;
                    return DoCalculation(operation);
                }
            }
            return answer;
        }

        public void ResetAll()
        {
            number = "";
            secondNumber = "";
            operation = "";
        }

        private void SetCalculationSymbol(char key)
        {

            if ( operation == "" && number != "")
            {
                operation = key.ToString();
            }
            else
            {
                DoCalculation(operation);
                operation = key.ToString();
            }
        }

        private string ShowNumber(char key)
        {
            if ( operation == "")
            {
                if(key=='s' || key == 'S')
                {
                    number = ( double.Parse(number) * -1 ).ToString();
                    return number;
                }
                if (key == '.')
                {
                    if (!number.Contains("."))
                    {
                        return number += ".";
                    }
                    else
                    {
                        return number;
                    }
                }
                if (!(number == "0" && key == '0'))
                {
                    if (number == "0")
                    {
                        number = key.ToString();
                    }
                    else
                    {
                        number += key.ToString();
                    }
                }
                return number;
            }
            else
            {
                if (key == 's')
                {
                    secondNumber = (double.Parse(secondNumber) * -1 ).ToString();
                    return secondNumber;
                }
                if (key == '.')
                {
                    if (!secondNumber.Contains("."))
                    {
                        return secondNumber += ".";
                    }
                    else
                    {
                        return secondNumber;
                    }
                }
                if (!(secondNumber == "0" && key == '0'))
                {
                    if (secondNumber == "0")
                    {
                        secondNumber = key.ToString();
                    }
                    else
                    {
                        secondNumber += key.ToString();
                    }
                }
                return secondNumber;
            }
        }
    }
}
