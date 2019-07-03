using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {

        private string firstNum="0";
        private string secondNum = "";
        private char? op = null;


        private int opPressed = 0;

        private bool decFirst = false;
        private bool decSecond = false;

        private List<char> allowedOps = new List<char> { '+', '-', 'x', 'X', '*', '/', 's', 'S', 'c', 'C' };


        public string SendKeyPress(char key)
        {
            if(ValidKey(key))
            {
                if(char.IsDigit(key))
                {
                    if(opPressed==0)
                    {
                        if (!(firstNum.Equals("0") && key == '0'))
                        {
                            firstNum += key;
                        }
                    }
                    else
                    {
                        if (!(secondNum.Equals("0") && key == '0'))
                        {
                            secondNum += key;
                        }

                        return secondNum;
                    }

                    
                }
                else if(key.Equals('.'))
                {
                    if(opPressed==0 && decFirst==false)
                    {
                        if(firstNum.Length==0)
                        {
                            firstNum = "0.";
                        }
                        else
                        {
                            firstNum += ".";

                        }
                        decFirst = true;
                    }
                    else if (opPressed==1 && decSecond==false)
                    {
                        if(secondNum.Length==0)
                        {
                            secondNum = "0.";
                        }
                        else
                        {
                            secondNum += "."; 
                        }
                        decSecond = true;
                    }
                }
                else if(key=='s' || key=='S')
                {
                    if(opPressed==1)
                    {
                        secondNum = (-double.Parse(secondNum)).ToString();
                    }
                    else
                    {
                        firstNum = (-double.Parse(firstNum)).ToString();
                    }
                }
                else if(key=='c'|| key=='C')
                {
                    firstNum = "0";
                    secondNum = "";
                    op = null;
                    opPressed = 0;
                    decFirst = false;
                    decSecond = false;
                }
                else if(key.Equals('='))
                {
                    ComputeResult();
                    opPressed = -1;
                }
                else if(allowedOps.Contains(key))
                {
                    opPressed += 1;
                    if(opPressed==2)
                    {
                        ComputeResult();
                        secondNum = "";
                        opPressed -= 1;
                    }

                    op = key;
                }
                return firstNum;
            }
            else
            {
                return firstNum;
            }

        }


        private void ComputeResult()
        {
            switch (op)
            {
                case '+':
                    firstNum = (double.Parse(firstNum) + double.Parse(secondNum)).ToString();
                    break;
                case '-':
                    firstNum = (double.Parse(firstNum) - double.Parse(secondNum)).ToString();
                    break;
                case 'x':
                case 'X':
                case '*':
                    firstNum = (double.Parse(firstNum) * double.Parse(secondNum)).ToString();
                    break;
                case '/':
                    try
                    {
                        firstNum = (double.Parse(firstNum) / double.Parse(secondNum)).ToString();
                        if (firstNum.Equals((1.0 / 0).ToString()))
                        {
                            throw new DivideByZeroException();
                        }
                    }
                    catch (DivideByZeroException)
                    {

                        firstNum = "-E-";
                    }
                    break;
            }


        }

        private bool ValidKey(char key)
        {
            if (char.IsDigit(key) || allowedOps.Contains(key) || key == '.' || key.Equals('='))
            {
                return true;
            }
            return false;
        }
    }
}
