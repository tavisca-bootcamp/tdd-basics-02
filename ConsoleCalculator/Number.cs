using System;
using System.Collections.Generic;
using System.Text;
using Operation;
using ConsoleCalculator;

namespace ConsoleCalculator
{
    class Number : CheckKeys
    {
        public string SelectKeys(char key)
        {
            
            if (Operations.IsOperator((int)Calculator.operator2))
            {
                Calculator.operator2 = '%';
                Calculator.output = null;

            }
            Calculator.output = Calculator.output + key.ToString();
            return Calculator.output;
        }
    }
}
