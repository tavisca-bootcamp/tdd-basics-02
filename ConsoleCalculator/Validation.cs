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
            return new Regex(@"[0-9]").IsMatch(digit.ToString());
        }

        public bool IsAlphabetKey(char alpha)
        {
            bool result = new Regex("[^cCsSxX.=]").IsMatch(alpha.ToString());
            return result;
        }

        public bool IsArithmaticOperationKey(char operation)
        {
            return new Regex(@"[+\-Xx\/]").IsMatch(operation.ToString());
        }

        public string IsPrecedingZero(string operand,char key)
        {
            if (operand != null && operand!="0")
                return operand += key;
            if (operand.Contains("."))
                return operand;
            return null;
        }

        public string checkLeadingZeros(string operand, char key)
        {
            if (operand == "0")
                operand = null;
            return operand += key;
        }



    }
}
