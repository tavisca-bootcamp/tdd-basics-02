using ConsoleCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator.Operations
{
    class Division : IOperation
    {
        public char Operation { get { return Common.Common.Division; } }

        public double Operate(double operand1, double operand2)
        {
            if (operand2 == 0)
                throw new DivideByZeroException();

            return operand1 / operand2;
        }
    }
}
