using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace ConsoleCalculator
{
    class Equal : CheckKeys
    {
        public string SelectKeys(char key)
        {
            DataOpertion dataOpertion = new DataOpertion();
            dataOpertion.GetTotal();
            Calculator.operator1 = '%';
            if (Calculator.output != null)
            {
                Calculator.tempOutput = Calculator.output;
                Calculator.output = null;
            }
            return Calculator.tempOutput;

        }
    }
}
