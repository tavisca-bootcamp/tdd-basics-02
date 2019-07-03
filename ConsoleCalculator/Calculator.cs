using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string screenDisplay = "0"; // initially before start screen should be 0;
        public bool operatorCame = false; // to check the operator
        public char lastOperator = 'Z'; 
        public double result = 0;

        public string SendKeyPress(char key)
        {

            if (!IsValidKey(key)) // condition1 Accepting Keys
            {
                return screenDisplay;
            }
            
            switch (key)
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
                case '9':
                    PassDigit(key);
                    break;
                case '.':
                    DecimalCase(); 
                    break;
                case 'c':
                case 'C':
                    ClearSet();
                    break;
                case 's':
                case 'S':
                    Toggle(); 
                    break;
                case 'x':
                case 'X':
                case '+':
                case '-':
                case '/':
                    OperationPerformed(key); 
                    break;
                case '=':
                    CalculateResult(); 
                    break;
            }
            return screenDisplay; 
        }

        public bool IsValidKey(char key)
        {
            var validKeys = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','.', 'c', 'C', 's', 'S', 'x', 'X', '/', '+', '-', '=' };
            if (validKeys.Contains(key))
                return true;
            else
                return false;
        }

        public void PassDigit(char key)
        {
            if (string.Equals(screenDisplay, "0"))//initially check screen zero or not
            {
                if (key != '0')
                {
                    screenDisplay = ""; // if key is not 0 then in order to remove 0 infront of key
                    screenDisplay += key; // add the keys
                }
            }
            else
            {
                    screenDisplay += key;//if screen not zero and key=0 then add that zero to screen digit
            }  


        }

        public void ClearSet()
        {
            screenDisplay = "0";
            operatorCame = false; 
            lastOperator = 'Z'; // anything which is not a valid operator
            result = 0; 
        }

        public void DecimalCase()
        {
            if (!screenDisplay.Contains("."))
                screenDisplay += '.';
        }

        public void Toggle()
        {
            double.TryParse(screenDisplay, out double temp);
            temp = temp * (-1);
            screenDisplay = temp.ToString();
        }

        public void OperationPerformed(char op)
        {
            if (!operatorCame) //operator came(initially it sets to be false)
            {
                double.TryParse(screenDisplay, out result);
                operatorCame = true; // operator arrived.
            }
            else //operator already exist
                CalculateResult(); // calculate the result to perform further operations

            lastOperator = op; // save the operation to be performed.
            screenDisplay = "0"; // after any operater that come screen should be back to 0 to take I/P.
        }

        public void CalculateResult()
        {

            double.TryParse(screenDisplay, out double temp);
            switch (lastOperator)
            {
                case 'x':
                case 'X':
                    result = result * temp;
                    break;
                case '-':
                    result = result - temp;
                    break;
                case '+':
                    result = result + temp;
                    break;
                case '/':
                    if (temp != 0)
                    {
                        result = result / temp;
                    }
                    else
                    {
                        DisplayError();
                        return;
                    }
                    break;
                
            }
            // now we have the final result to be displayed
            screenDisplay = result.ToString();
            operatorCame = false;
            lastOperator = 'Z';
        }

        public void DisplayError()
        {
            screenDisplay = "-E-";
        }
    }
}
