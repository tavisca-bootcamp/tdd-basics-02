using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        string screenDisplay = "0";
        private bool isOperator = false;
        private char lastOperator = 'O';
        float finalResult = 0;
        private bool validKey(char ch)
        {
            var Keys = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'c', 'C', 's', 'S', 'x', 'X', '/', '+', '-', '=', '.' };
            if (Keys.Contains(ch))
                return true;
            else
                return false;
        }

        private bool validOperator(char ch)
        {
            var opr = new List<char>() { 'x', 'X', '/', '+', '-' };
            if (opr.Contains(ch))
                return true;
            else
                return false;
        }

        private void decimalFound(char ch)
        {
            if (!screenDisplay.Contains("."))
                screenDisplay += ch;
        }

        private void clearScreen()
        {
            screenDisplay = "0";
            finalResult = 0;
        }

        void toggleSign()
        {
            float.TryParse(screenDisplay, out float var);
            var = 0 - var;
            screenDisplay = var.ToString();
        }

        void operatorFound(char ch)
        {
            if (!isOperator)
            {
                float.TryParse(screenDisplay, out finalResult);
                isOperator = true;
            }
            else
                calculateResult();

            lastOperator = ch;
            screenDisplay = "0";
        }

        private void calculateResult()
        {

            float.TryParse(screenDisplay, out float temp);
            switch (lastOperator)
            {
                case 'x':
                case 'X':
                    finalResult = finalResult * temp;
                    break;
                case '-':
                    finalResult = finalResult - temp;
                    break;
                case '+':
                    finalResult = finalResult + temp;
                    break;
                case '/':
                    if (temp != 0)
                    {
                        finalResult = finalResult / temp;
                    }
                    else
                    {
                        DisplayError();
                        return;
                    }
                    break;
                default: break;
            }
            screenDisplay = finalResult.ToString();
            isOperator = false;
            lastOperator = 'O';
        }

        private bool IsValidOperand(String display)
        {
            bool temp = float.TryParse(display, out float number);
            return temp;
        }

        private void DisplayError()
        {
            screenDisplay = "--E--";
        }
        public string SendKeyPress(char key)
        {
            if(!validKey(key))
            {
                return screenDisplay;
            }

            if(Char.IsDigit(key))
            {
                if (screenDisplay == "0")
                {
                    if (key != '0')
                    {
                        screenDisplay = "";
                        screenDisplay += key;
                    }
                }
                else
                {
                    screenDisplay += key;
                }
            }

            if(string.Equals(key,"."))
            {
                decimalFound(key);
            }

            if(string.Equals(key,"C") || string.Equals(key,"c"))
            {
                clearScreen();
            }

            if (string.Equals(key, "S") || string.Equals(key, "s"))
            {
                toggleSign();
            }

            if(validOperator(key))
            {
                operatorFound(key);
            }
            return screenDisplay;
        }
    }
}
