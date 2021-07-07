using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Validations
    {
        public string[] Validate(char current,string input)
        {
            string[] validated = new string[2];
            if (current == '0' || current == '1' || current == '2' || current == '3' || current == '4' || current == '5' || current == '6' || current == '7' || current == '8' || current == '9' || current == '.')
            {
                if (current == '.')
                {
                    if (CheckDecimal(input))
                    {
                        validated[0] = current.ToString();
                        validated[1] = "digit";
                    }
                    else
                    {
                        validated[0] = current.ToString();
                        validated[1] = "invalid input";
                    }
                }
                else if (current=='0' && input=="0")
                {
                    validated[0] = current.ToString();
                    validated[1] = "invalid input";
                }
                else
                {
                    validated[0] = current.ToString();
                    validated[1] = "digit";
                }
            }
            else if (current == '+' || current == '-' || current == 'x' || current == '/')
            {
                validated[0] = current.ToString();
                validated[1] = "operator";
            }
            else if (current == 'C')
            {
                validated[0] = current.ToString();
                validated[1] = "clear";
            }
            else if (current == 'S')
            {
                validated[0] = current.ToString();
                validated[1] = "sign";
            }
            else if (current == '=')
            {
                validated[0] = current.ToString();
                validated[1] = "calculate";
            }
            else
            {
                validated[0] = current.ToString();
                validated[1] = "invalid input";
            }
            return validated;
        }

        private bool CheckDecimal(string input)
        {
            int count = 0;
            foreach (char chr in input)
            {
                if (chr == '.')
                {
                    count++;
                }
            }

            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
