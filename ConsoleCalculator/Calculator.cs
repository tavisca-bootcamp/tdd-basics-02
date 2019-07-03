using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        string firstOperand = "";
        string secondOperand = "";
        char? @operator = null;
        List<char> validArithmeticOperator = new List<char> { '+','-','x','/'};

        public string SendKeyPress(char key)
        {
            key = char.ToLower(key);
            if (key == 'c')
            {
                ClearHistory();
                return "0";
            }
            else if (key == 's')
                return ToggleSign();

            else if (char.IsDigit(key))
                return NumbericDigitHandling(key);

            else if (key == '.')
                return DecimalHandling(key);

            else if (validArithmeticOperator.Contains(key))
            {
                firstOperand = PerformArithmeticOperation(); //Assigning the result to firstOperand
                if (firstOperand == "Error")
                    return DisplayError();
                secondOperand = "";
                @operator = key; // Assign current operator
                return firstOperand;
            }
            else if (key == '=')
                return EqualSignPressed();

            return RandomCharacterHandling();
        } //End  of SendKeyPress function

        public string ToggleSign()
        {
            if (@operator == null)
            {
                if (double.TryParse(firstOperand, out double number1))
                    firstOperand = (-1 * number1).ToString();
                return firstOperand;
            }
            if (double.TryParse(secondOperand, out double number2))
                secondOperand = (-1 * number2).ToString();
            return secondOperand;
        }//End of ToggleSign Function

        public string NumbericDigitHandling(char key)
        {
            if (@operator == null)
            {   // Also avoiding additional 0 like 00000 -> 0
                firstOperand = firstOperand == "0" ? key.ToString() : firstOperand + key.ToString();
                return firstOperand;
            }
            secondOperand = secondOperand == "0" ? key.ToString() : secondOperand + key.ToString();
            return secondOperand;
        }
        public string DecimalHandling(char key)
        {
            if (@operator == null) //If firstOperand
            {
                if (string.IsNullOrEmpty(firstOperand)) // Appending 0 like '.' -> 0.
                    firstOperand = "0";

                if (firstOperand.Contains(".") == false) //Avoiding multiple '.'
                    firstOperand += key;

                return firstOperand;
            }
            if (string.IsNullOrEmpty(secondOperand))
                secondOperand = "0" + key;

            else if (secondOperand.Contains(".") == false)
                secondOperand += key;

            return secondOperand;
        } //End of DecimalHandling function

        public string PerformArithmeticOperation()
        {
            if (double.TryParse(firstOperand, out double firstValue) == false)
                return "Error";

            if (@operator == null) //For first operation
                return firstOperand;

            if (double.TryParse(secondOperand, out double secondValue) == false)
                return "Error";

            switch (@operator)
            {
                case '+': return (firstValue + secondValue).ToString();
                case '-': return (firstValue - secondValue).ToString();
                case 'x': return (firstValue * secondValue).ToString();
                case '/': return secondValue == 0 ? "Error" : (firstValue / secondValue).ToString();
            }
            return "";
        } //End of PerformArithmeticOperation function

        public string EqualSignPressed()
        {
            if (string.IsNullOrWhiteSpace(firstOperand))
                return DisplayError();

            if (@operator == null)
                return firstOperand;

            if (secondOperand == "") // secondOperand was not provided before hitting '='
                secondOperand = firstOperand;

            string result = SendKeyPress('+');
            ClearHistory();
            return result;
        }

        public string RandomCharacterHandling()
        {
            if (string.IsNullOrWhiteSpace(firstOperand))
                return "";
            if (@operator == null)
                return firstOperand;
            return secondOperand;
        }
        public string DisplayError()
        {
            ClearHistory();
            return "-E-";
        }
        public void ClearHistory()
        {
            firstOperand = secondOperand = "";
            @operator = null;
        }
    }
}