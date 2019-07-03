using System;
using System.Collections.Generic;
using System.Text;
using Operation;
using ConsoleCalculator;

namespace Data
{
    class DataOpertion
    {
        public void GetTotal()
        {
            Operations operations = new Operations();
            if (Calculator.output != null)
            {
                Calculator.operand2 = double.Parse(Calculator.output);
            }
            switch (Calculator.operator1)
            {
                case '-':
                    Calculator.output = operations.Subtract(Calculator.operand1, Calculator.operand2);
                    Calculator.operand2 = 0;
                    break;
                case '+':
                    Calculator.output = operations.Add(Calculator.operand1, Calculator.operand2);
                    Calculator.operand2 = 0;
                    break;
                case '/':
                    Calculator.output = operations.Division(Calculator.operand1, Calculator.operand2);
                    Calculator.operand2 = 0;
                    break;
                case 'x':
                case 'X':
                    Calculator.output = operations.Multiply(Calculator.operand1, Calculator.operand2);
                    Calculator.operand2 = 0;
                    break;
            }
            
        }
    }
}
