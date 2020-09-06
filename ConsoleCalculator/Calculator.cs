using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {   
        private String display = "";
        private char lastOperator = 'N';
        private int numberFlag = 0;
        private int operatorFlag = 0;
        private float result = 0;

        public string SendKeyPress(char key)
        {
            if(!IsValidEntry(key))
            {
                if(display.Length == 0)
                {
                    display = "0";
                }
                return display;
            }

            switch ( key )
            {
                case '0':   
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':   ProcessNumber(key);
                            break;
                case '.':   ProcessDecimalPoint();
                            break;
                case 'c':
                case 'C':   ProcessClear();
                            break;
                case 's':
                case 'S':   ProcessSignChange();
                            break;
                case 'x':
                case 'X':   
                case '+':   
                case '-':   
                case '/':   ProcessOperator(key);
                            break;
                case '=':   ShowResult();
                            break;
                default:    break;
            }
            return display;    
        }

        private bool IsValidEntry(char key)
        {
            var validEntries = new List<char>() {'0','1','2','3','4','5','6','7','8','9','c','C','s','S','x','X','/','+','-','=','.'};
            if(validEntries.Contains(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ProcessNumber(char key)
        {
               if(numberFlag==0)
               {
                   if(String.Equals(display,"0"))
                    {
                        display = "";
                    }
                    display += key;  
               }
               else     // numberFlag is 1
               {
                   display = "";
                   display += key;
                   numberFlag = 0; // reset number flag
               }          
        }

        private void ProcessClear()
        {
                display = "0";
                numberFlag = 0;
                operatorFlag = 0;
                lastOperator = 'N';
                result = 0;
        }

        private void ProcessDecimalPoint()
        {
                if(display.Length == 0)
                {
                    display = "0.";
                }
                else
                {
                    //checking for multiple decimal points
                    if(display[display.Length -1] != '.')
                    {
                        display += '.';
                    }
                    // else ignore the repeated decimal point
                }

        }

        private void ProcessSignChange()
        {
            float temp;
            if(!IsValidOperand(display)){
                DisplayError();
            }
            temp = (-1) * float.Parse(display);
            display = temp.ToString();
            
        }

        private void ProcessOperator(char key)
        {
            if(operatorFlag == 0)
            {
                if(!IsValidOperand(display)){
                    DisplayError();
                }
                result = float.Parse(display);
                lastOperator = key;
                operatorFlag = 1;
                numberFlag = 1;
            }
            else    // operatorFlag is 1
            {
                ShowResult();
                lastOperator = key;
                operatorFlag = 1;
                numberFlag = 1;
                if(!IsValidOperand(display)){
                    DisplayError();
                }
                 result = float.Parse(display);
            }
            
        }

        private void ShowResult()
        {
            if(operatorFlag == 0)
            {
                // no operator was acted upon
                // no change in display
                result = 0;
                lastOperator = 'N';
            }
            else if(operatorFlag == 1)
            {
                // flag is 1 : atleast one operator was acted and we have something in result & display
                float temp;
                if(!IsValidOperand(display)){
                    DisplayError();
                }
                 temp = float.Parse(display);
                // Calculating the Result
                switch(lastOperator)
                {
                    case 'x':   
                    case 'X':   result = result * temp; 
                                break;
                    case '-':   result = result - temp; 
                                break;
                    case '+':   result = result + temp; 
                                break;
                    case '/':   if(temp != 0)
                                {
                                    result = result / temp; 
                                }
                                else
                                {
                                    DisplayError();
                                    return;
                                }
                                break;
                    default:    break;
                }
                // now we have the final result to be displayed
                display = result.ToString();
                operatorFlag = 0;
                numberFlag = 1;
                lastOperator = 'N';
                result = 0;
            }
        }

        private bool IsValidOperand(String display)
        {
            bool temp = float.TryParse(display, out float number);
            return temp;
        }

        private void DisplayError()
        {
            //Error Occurred!
            display = "-E-";
            numberFlag = 1;
            operatorFlag = 0;
            lastOperator = 'N';
            result = 0;
        }
    }
}
