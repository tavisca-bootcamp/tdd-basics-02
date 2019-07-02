using System;

namespace ConsoleCalculator
{
    public class Calculator
    {

        Operations helper = new Operations();
        public string SendKeyPress(char key)
        {
            switch (key)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return helper.AddDigitExceptZero(key);
                case '0':
                    return helper.AddZero();
                case '+':
                case '-':
                case 'x':
                case 'X':
                case '/':
                    return helper.Operator(key);
                case '=':
                    return helper.Equals();
                case 's':
                case 'S':
                    return helper.Toggle();
                case 'c':
                case 'C':
                    return helper.Clear();
                case '.':
                    return helper.PerformDecimalOperation();
                default:
                    return helper.output.ToString();

            }

        }



    }
}

