using System;
using System.Collections.Generic;
using System.Text;
using Operation;
using Data;

namespace ConsoleCalculator
{
    class Operator : CheckKeys
    {
        public string SelectKeys(char key)
        {
            DataOpertion dataOpertion = new DataOpertion();
            
            if (Operations.IsOperator((int)Calculator.operator1))
            {
                dataOpertion.GetTotal();
                Calculator.operator2 = key;
                Calculator.operator1 = key;
                Calculator.operand1 = double.Parse(Calculator.output);
                return Calculator.output;
            }
            if (Calculator.output == null)
            {
                Calculator.operator1 = '%';
                Calculator.operand1 = 0;
                Calculator.operand2 = 0;
                Calculator.output = null;
                return "0";
            }
                
             Calculator.operand1 = double.Parse(Calculator.output);
             Calculator.operator1 = key;
             Calculator.operator2 = key;
             return Calculator.output;
        }
    }
}
