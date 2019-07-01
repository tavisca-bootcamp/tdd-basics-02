using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    class CheckInputType
    {

        public bool isClear(char key)
        {
            if (key == 'c' || key == 'C')
            {
                return true;
            }
            return false;
        }

        public bool isOperator(char key)
        {
            if (key == '+' || key == '-' || key == 'x' || key == 'X' || key == '/')
            {
                return true;
            }
            return false;
        }

        public bool isNumber(char key)
        {
            if (Char.IsDigit(key))
            {
                return true;
            }
            return false;
        }

        public bool isDecimalValid(char key, string number)
        {
            if (key == '.' && !number.Contains("."))
            {
                return true;
            }
            return false;
        }

        public bool isSignChange(char key)
        {
            if (key == 'S' || key == 's')
            {
                return true;
            }
            return false;
        }

    }
}
