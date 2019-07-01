using System;
using System.Text;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private double accumulator = 0.0d;
        private StringBuilder display = new StringBuilder();
        private char sign = '\0';

        public string SendKeyPress(char key)
        {
            char inputChar = char.Parse(key.ToString());
            switch (inputChar)
            {
                case char w when char.IsDigit(w):
                    if (w == '0' && display.Length == 1 && display.ToString()[0] == '0')
                        break;
                    if (sign != '\0')
                        display.Clear();
                    display.Append(w);
                    break;

                case '.':
                    if (display.Length == 0)
                        display.Append("0.");
                    else if (!display.ToString().Contains("."))
                        display.Append('.');
                    break;

                case char w when w == 'c' || w == 'C':
                    display.Clear();
                    accumulator = 0.0d;
                    return "0";

                case char w when w == 's' || w == 'S':
                    if (display[0] != '-')
                        display.Insert(0, '-');
                    else
                        display.Remove(0, 1);
                    break;

                case char w when w == '+' || w == '-' || w == 'x' || w == 'X' || w == '/':
                    UpdateDisplayText();
                    sign = w;
                    break;

                case '=':
                    UpdateDisplayText();
                    accumulator = 0.0d;
                    sign = '\0';
                    break;

                default:
                    break;
            }

            return display.ToString();
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
