using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private List<Char> allowedOperators = new List<char>
        {
             '-', '+', 'x','X', '/', 's', 'S','c','C'
        };
        public string SendKeyPress(char key)
        {
            if (IsValid(key))
            {
                return "key";
            }
            return "";
        }


        private bool IsValid(char key)
        {
            if (char.IsDigit(key) || allowedOperators.Contains(key) || key == '.' || key.Equals('='))
            {
                return true;
            }
            return false;
        }
    }
}
