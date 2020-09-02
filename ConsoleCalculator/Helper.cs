using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    class Helper
    {
        Validation validate = new Validation();
        public  string AssignDecimalToOperand(string operand, char key)
        {
            if (operand.Contains("."))
                return operand;
            return operand += key;
        }

        public string AssignOperand(string operand, char key)
        {
            if (string.IsNullOrEmpty(operand))
                operand = key.ToString();
            else
                operand = validate.checkLeadingZeros(operand, key);

            return operand;
        }

        public string toggleSign(string operand)
        {
            return (-1 * double.Parse(operand)).ToString();
        }
    }
}
