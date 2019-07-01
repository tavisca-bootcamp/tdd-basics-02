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

        //firstNumber will also contain the result
        private string firstNumber = "";
        private string secondNumber = "";
        private char? operation = null;
        private int operatorPressed = 0;
        private bool decFirst = false;
        private bool decSecond = false;
        public string SendKeyPress(char key)
        {
            
            if (IsValid(key))
            {
                if (char.IsDigit(key))
                {
                    if (operatorPressed == 0 )
                    {
                        if (!(firstNumber.Equals("0") && key=='0'))
                        {
                            firstNumber += key;
                        }
                        
                                               
                    }
                    else
                    {
                        if (!(secondNumber.Equals("0")&&key=='0'))
                        {
                            secondNumber += key;
                        }
                        
                        return secondNumber;
                    }
                    
                }
                else if (key.Equals('.'))
                {
                    if (operatorPressed == 0 && decFirst==false)
                    {
                        if (firstNumber.Length == 0)
                        {
                            firstNumber = "0.";
                        }
                        else
                        {
                            firstNumber += ".";
                        }
                        decFirst = true;
                    }
                    else if (operatorPressed == 1 && decSecond == false)
                    {
                        if (secondNumber.Length == 0)
                        {
                            secondNumber = "0.";
                        }
                        else
                        {
                            secondNumber += ".";
                        }
                        decSecond = true;
                    }
                }
                else if (key == 's' || key == 'S')
                {
                    if (operatorPressed == 1)
                    {
                        secondNumber = (-double.Parse(secondNumber)).ToString();
                    }
                    else
                    {
                        firstNumber = (-double.Parse(firstNumber)).ToString();
                    }
                }
                else if (key == 'c' || key == 'C')
                {
                    firstNumber = "0";
                    secondNumber = "";
                    operation = null;
                    operatorPressed = 0;
                    decFirst = decSecond = false;
                }
                else if (key.Equals('='))
                {
                    ComputeResult();
                    operatorPressed -= 1;
                }
                else if (allowedOperators.Contains(key))
                {
                    operatorPressed += 1;
                    //compute previous if any 
                    if (operatorPressed == 2)
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
                    try
                    {
                        firstNumber = (double.Parse(firstNumber) / double.Parse(secondNumber)).ToString();
                        if (firstNumber.Equals((1.0/0).ToString()))
                        {
                            //firstNumber = "-E-";
                            throw new DivideByZeroException();
                        }
                    }
                    catch (DivideByZeroException)
                    {

                        firstNumber = "-E-";
                    }
                    break;
            }
            

        }

        private bool IsValid(char key)
        {
            if(char.IsDigit(key) || allowedOperators.Contains(key)|| key=='.'|| key.Equals('='))
            {
                return true;
            }
            return false;
        }
    }
}
