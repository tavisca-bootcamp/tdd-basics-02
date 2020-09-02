using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleCalculator
{
    public class Validation
    {
        public bool IsNumericKey(char digit)
        {
            return false;
        }

        public bool IsAlphabetKey(char alpha)
        {
            return false;
        }

        public bool IsArithmaticOperationKey(char operation)
        {
            return false;
        }

        public string IsPrecedingZero(string operand,char key)
        {
            return string.Empty;
        }

        public string checkLeadingZeros(string operand, char key)
        {
            return string.Empty;
        }



    }
}
