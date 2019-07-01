using System;
using System.Text;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private double accumulator;
        private StringBuilder display;
        private char sign;

        public Calculator()
        {
            accumulator = 0.0d;
            display = new StringBuilder();
            sign = '\0';    //Sign is not set.
        }

        public string SendKeyPress(char key)
        {
            char inputChar = char.Parse(key.ToString());
            switch (inputChar)
            {
                case char w when char.IsDigit(w):
                    if (w == '0' && IsDisplayZero())
                        break;
                    if (IsSignSet())
                        display.Clear();
                    display.Append(w);
                    break;

                case '.':
                    AddDecimalPoint();
                    break;

                case char w when w == 'c' || w == 'C':
                    display.Clear();
                    ResetState();
                    return "0";

                case char w when w == 's' || w == 'S':
                    ToggleSign();
                    break;

                case char w when IsOperator(w):
                    UpdateDisplayText();
                    sign = w;
                    break;

                case '=':
                    UpdateDisplayText();
                    ResetState();
                    break;

                default:
                    break;
            }

            return display.ToString();
        }

        private void AddDecimalPoint()
        {
            if (display.Length == 0)
                display.Append("0.");
            else if (!display.ToString().Contains("."))
                display.Append('.');
        }

        private void ResetState()
        {
            accumulator = 0.0d;
            sign = '\0';
        }

        private void ToggleSign()
        {
            if (display[0] != '-')
                display.Insert(0, '-');
            else
                display.Remove(0, 1);
        }

        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == 'x' || c == 'X' || c == '/';
        }

        private bool IsSignSet()
        {
            return sign != '\0';
        }

        private bool IsDisplayZero()
        {
            return display.Length == 1 && display.ToString()[0] == '0';
        }

        private void UpdateDisplayText()
        {

            if (Accumulate())
            {
                display.Clear();
                display.Append(accumulator.ToString());
            }

            else
            {
                display.Clear();
                display.Append("-E-");
            }

        }

        private bool Accumulate()
        {
            if (sign == '\0')
            {
                accumulator = double.Parse(display.ToString());
            }
            else
            {
                double tempNumber = double.Parse(display.ToString());
                switch (sign)
                {
                    case '+':
                        accumulator += tempNumber;
                        break;
                    case '-':
                        accumulator -= tempNumber;
                        break;
                    case 'X':
                    case 'x':
                        accumulator *= tempNumber;
                        break;
                    case '/':
                        if (tempNumber != 0)
                            accumulator /= tempNumber;
                        else
                            return false;
                        break;
                }
            }
            return true;
        }
    }
}
