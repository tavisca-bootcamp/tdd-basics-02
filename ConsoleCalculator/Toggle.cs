using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    class Toggle : CheckKeys
    {
        public string SelectKeys(char key)
        {
            if (Calculator.output.Equals("0"))
            {
                return "0";
            }

            Calculator.operand2 = -1 * Convert.ToDouble(Calculator.output);
            Calculator.output = Calculator.operand2.ToString();
            return Calculator.output;
        }
    }
}
