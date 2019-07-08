using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class ValidationHelper
    {
        public static bool IsValid(Char c)
        {
            if (Char.IsNumber(c) || c == '.' || IsOperator(c) || IsEquals(c) || IsSignToggle(c) || IsClear(c))
                return true;
            else
                return false;
        }

        public static bool IsDigit(Char current,string input)
        {
            if (Char.IsNumber(current) || current == '.')
            {
                if (current == '.')
                {
                    if (CheckDecimal(input))
                        return true;
                    else
                        return false;
                }
                else if (current == '0' && input == "0")
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        public static bool IsOperator(Char current)
        {
            if (current == '+' || current == '-' || current == 'x' || current == '/')
                return true;
            else
                return false;
        }

        public static bool IsEquals(Char current)
        {

            return current == '=' ? true : false;
        }

        public static bool IsSignToggle(Char current)
        {
            return current == 'S' ? true : false;
        }
        public static bool IsClear(Char current)
        {
            return current == 'C' ? true : false;
        }

        private static bool CheckDecimal(string input)
        {
            int count = 0;
            foreach (char chr in input)
            {
                if (chr == '.')
                    count++;
            }
            if (count > 0)
                return false;
            else
                return true;
        }
    }
}
