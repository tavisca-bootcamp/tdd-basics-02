using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private String screenDisplay = "0"; // in start display should be 0;
        private bool operatorCame = false; // operator aaya ki nahi wo batata h.
        private char lastOperator = 'O'; // last operator save krta h
        private float result = 0; // result is saved here in case further operators come or operation to do.


        public string SendKeyPress(char key)
        {
       
            if (!IsValidKey(key)) // If not a valid key then same display.
                return screenDisplay; // display the output on screen.

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
                    PassDigit(key);//assess the digit
                    break;
                case '.':
                    PassDecimal(); // assess the decimal
                    break;
                case 'c':
                case 'C':
                    DoClear(); // clear the screen
                    break;
                case 's':
                case 'S':
                    DoSignChange(); // toggle the sign
                    break;
                case 'x':
                case 'X':
                case '+':
                case '-':
                case '/':
                    PassOperator(key); // operation passed
                    break;
                case '=':
                    CalculateResult(); // calculate the result for '=' operator.
                    break;

                default:
                    break;
            }
            return screenDisplay; // display the output on screen
        }

        private bool IsValidKey(char key)
        {
            var validKeys = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'c', 'C', 's', 'S', 'x', 'X', '/', '+', '-', '=', '.' };
            if (validKeys.Contains(key))
                return true;
            else
                return false;
        }

        private void PassDigit(char key)
        {
            if (String.Equals(screenDisplay, "0"))
            {
                if(key!='0')
                {
                    screenDisplay = ""; // if key is not 0 then remove zero and,
                    screenDisplay += key; // add the keys
                }
            }
            else { screenDisplay += key; } // already some meaningful key presents(not only zero)
           
                  
        }

        private void DoClear()
        {
            screenDisplay = "0"; // clear the screen and display 0
            operatorCame = false; // operator did not came also
            lastOperator = 'O'; // anything which is not a valid operator
            result = 0; // result back to 0
        }

        private void PassDecimal()
        {
            if (!screenDisplay.Contains("."))
                screenDisplay += '.';
        }

        private void DoSignChange()
        {
            float.TryParse(screenDisplay, out float temp);
            temp = 0 - temp; // subtract from 0 to toggle the sign
            screenDisplay = temp.ToString();
        }

        private void PassOperator(char operation)
        {
            if (!operatorCame) //operator came
            {
                float.TryParse(screenDisplay, out result); // number we had is exactly stored in result
                operatorCame = true; // operator arrived.
            }
            else //operator already came
                CalculateResult(); // calculate the result first before another operator has to be handled.

            lastOperator = operation; // save the operation to be performed.
            screenDisplay = "0"; // after any operater that come screen should be back to 0 to take I/P.
        }

        private void CalculateResult()
        {
        
                float.TryParse(screenDisplay, out float temp);
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
                    default: break;
                }
                // now we have the final result to be displayed
                screenDisplay = result.ToString();
                operatorCame = false;
                lastOperator = 'O';
        }

        private bool IsValidOperand(String display)
        {
            bool temp = float.TryParse(display, out float number);
            return temp;
        }

        private void DisplayError()
        {
            screenDisplay = "-E-";
        }
    }
}
