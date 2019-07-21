using System;
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
            digits = new Stack<float>();
            operators = new Stack<char>();
            numberOfDecimals = 0;
            digit = new StringBuilder();
            doReset = true;
        }
        public string SendKeyPress(char key)
        {
            // Add your implementation here.
            //throw new NotImplementedException();
            if (key >= '0' && key <= '9')
                IsDigit(key);
            else if (key == 'c' || key == 'C' || key == 's' || key == 'S' || key == '.')
                IsNotOperator(key);
            else
                IsOperator(key);
            return digit.ToString();
        }

        private void IsDigit(char keyPressed)
        {
            if(doReset)
            {
                digit.Clear();
                doReset = false;
                numberOfDecimals = 0;
            }
            if(keyPressed=='0'&&!digit.ToString().Equals("0"))
                digit.Append(keyPressed);
            else if(keyPressed!='0')
                digit.Append(keyPressed);
        }

        private void IsOperator(char keyPressed)
        {
            float valueOne = float.Parse(digit.ToString());
            digits.Push(valueOne);
            if (digits.Count >= 2)
            {
                char sign = operators.Pop();
                float one = digits.Pop();
                float two = digits.Pop();
                if(sign == '+')
                {
                    digit.Clear();
                    digit.Append(one + two);
                }
                else if(sign =='-')
                {
                    digit.Clear();
                    digit.Append(two-one);
                }
                else if(sign=='x'||sign =='X')
                {
                    digit.Clear();
                    digit.Append(one * two);
                }
                else if(sign =='/')
                {
                    if(one==0)
                    {
                        digit.Clear();
                        operators.Clear();
                        digit.Clear();
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
            if (keyPressed != '=')
                operators.Push(keyPressed);
        }

        private void IsNotOperator(char keyPressed)
        {
            if (keyPressed == '.' && numberOfDecimals == 0)
            {
                digit.Append(keyPressed);
                numberOfDecimals++;
            }
            else if (keyPressed == 's' || keyPressed == 'S')
            {
                float x = float.Parse(digit.ToString());
                digit.Clear();
                digit.Append(-x);
            }
            else if (keyPressed == 'c' || keyPressed == 'C')
            {
                operators.Clear();
                digits.Clear();
                numberOfDecimals = 0;
                digit.Clear();
                digit.Append(0);
            }
        }

        public string Calculate(string input)
        {
            string s = "";
            foreach (char c in input)
            {
                s = SendKeyPress(c);
            }
            return s;
        }
    }
}
