using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    class Character
    {
        public static bool IsDigitOrDot(char key)
        {
            return (key >= '0' && key <= '9') || key == '.';
        }

        public static bool IsOperator(char key)
        {
            switch (key)
            {
                case '+':
                case '-':
                case 'x':
                case 'X':
                case '/':
                case '=':
                    return true;
                default: return false;
            }
        }

        public static bool IsToggle(char key)
        {
            return key == 's' || key == 'S';
        }

    }
}
