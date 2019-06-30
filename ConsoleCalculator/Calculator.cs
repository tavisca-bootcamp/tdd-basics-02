using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private Stack<float> digits;

        private Stack<char> operators;

        private bool isInvalid = false;

        private int numberOfDecimals;

        private StringBuilder digit;

        private bool doReset;

        public Calculator()
        {
            numberOfDecimals = 0;
            doReset = true;
            digits = new Stack<float>();
            operators = new Stack<char>();
            digit = new StringBuilder();
        }

        public string SendKeyPress(char key)
        {
            if(key == ' ')
            {
                return digit.ToString();
            }
            if(IsDigit(key))
            {
                DoDigits(key);
            }
            else if(IsNotOperator(key))
            {
                DoOther(key);
            }
            else
            {
                DoOperation(key);
            }
            return digit.ToString();
        }

        private void DoDigits(char c)
        {
            if(doReset)
            {
                digit.Clear();
                doReset = false;
                numberOfDecimals = 0;
            }
            if(c == '0' && !digit.ToString().Equals("0"))
                digit.Append(c);
            else if(c != '0')
                digit.Append(c);
        }

        private void DoOperation(char c)
        {
            if(c == '-' && digits.Count == 0 && digit.ToString().Equals(""))
            {
                digit.Append(c);
                return;
            }
            float x = float.Parse(digit.ToString());
            digits.Push(x);
            if(digits.Count >= 2)
            {
                char sign = operators.Pop();
                float one = digits.Pop();
                float two = digits.Pop();
                if(sign == '+')
                {
                    digit.Clear();
                    digit.Append(one + two);
                }
                else if(sign == '-')
                {
                    digit.Clear();
                    digit.Append(two - one);
                }
                else if(sign == 'x' || sign == 'X')
                {
                    digit.Clear();
                    digit.Append(one * two);
                }
                else if(sign == '/')
                {
                    if(one == 0)
                    {
                        digit.Clear();
                        operators.Clear();
                        digits.Clear();
                        numberOfDecimals = 0;
                        digit.Append("-E-");

                    }
                    else
                    {
                        digit.Clear();
                        digit.Append(two / one);
                    }
                }
            }
            doReset = true;
            if(c != '=')
            {
                operators.Push(c);
            }
        }

        private void DoOther(char c)
        {
            if(c == '.' && numberOfDecimals == 0)
            {
                digit.Append(c);
                numberOfDecimals ++;
            }
            else if(c == 's' || c == 'S')
            {
                float x = float.Parse(digit.ToString());
                digit.Clear();
                digit.Append(-x);
            }
            else if(c == 'c' || c == 'C')
            {
                operators.Clear();
                digits.Clear();
                numberOfDecimals = 0;
                digit.Clear();
                digit.Append(0);
            }
        }

        private bool IsNotOperator(char c)
        {
            return c == 'C' || c == 'c' || c == 'S' || c == 's' || c == '.';
        }

        private bool IsDigit(char c)
        {
            return c>='0' && c<='9';
        }

        public string Calculate(string input)
        {
            string s = "";
            foreach(char c in input)
            {
                s = SendKeyPress(c);
            }
            return s;
        }
    }
}
