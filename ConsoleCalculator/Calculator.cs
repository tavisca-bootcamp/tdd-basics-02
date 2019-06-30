using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string firstNumber = "";
        private string secondNumber = "";
        private char? lastOperator = null;

        public string SendKeyPress(char key)
        {
            switch (char.ToLower(key))
            {
                case 'c':
                    ResetCalculator();
                    return "0";

                case 's':
                    if (lastOperator == null)
                    {
                        ChangeSign(ref firstNumber);
                        return firstNumber;
                    }
                    ChangeSign(ref secondNumber);
                    return secondNumber;

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
                    if (lastOperator == null)
                    {
                        if (firstNumber == "0")
                            firstNumber = key.ToString();
                        else
                            firstNumber += key;
                        return firstNumber;
                    } 
                    if (secondNumber == "0")
                        secondNumber = key.ToString();
                    else
                        secondNumber += key;
                    return secondNumber;

                case '.':
                    if (lastOperator == null && firstNumber[firstNumber.Length - 1] != '.')
                    {
                        firstNumber += key;
                        return firstNumber;
                    }
                    if (secondNumber[secondNumber.Length - 1] != '.')
                        secondNumber += key;
                    return secondNumber;

                case '+':
                case '-':
                case 'x':
                case '/':
                    firstNumber = Calculate();
                    if (firstNumber == "error")
                        return ThrowError();
                    secondNumber = "";
                    lastOperator = key;

                    return firstNumber;

                case '=':
                    if (lastOperator == null)
                        return firstNumber;
                    if (secondNumber == "")
                        secondNumber = firstNumber;

                    firstNumber = SendKeyPress((char)lastOperator);

                    if (firstNumber == "-E-")
                        return ThrowError();
                    secondNumber = "";
                    lastOperator = null;

                    return firstNumber;
            }
            return "";
        }

        private string Calculate()
        {
            if (lastOperator == null)
                return this.firstNumber;

            float.TryParse(this.firstNumber, out float firstNumber);
            float.TryParse(this.secondNumber, out float secondNumber);

            switch(char.ToLower((char)lastOperator))
            {
                case '+':
                    return (firstNumber + secondNumber).ToString();

                case '-':
                    return (firstNumber - secondNumber).ToString();

                case 'x':
                    return (firstNumber * secondNumber).ToString();

                case '/':
                    if (secondNumber == 0)
                        return "error";
                    return (firstNumber / secondNumber).ToString();
            }

            return "";
        }
        private string ThrowError()
        {
            ResetCalculator();
            return "-E-";
        }

        private static void ChangeSign(ref string number)
        {
            if (float.TryParse(number, out float n))
                number = (-1 * n).ToString();
        }

        private void ResetCalculator()
        {
            firstNumber = "";
            secondNumber = "";
            lastOperator = null;
        }
    }
}
