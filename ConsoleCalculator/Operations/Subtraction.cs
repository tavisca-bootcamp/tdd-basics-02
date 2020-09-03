using ConsoleCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator.Operations
{
    class Subtraction : IOperation
    {
        public char Operation { get { return Common.Common.Subtraction; } }

        public double Operate(double operand1, double operand2)
        {
            return operand1 - operand2;
        }
    }
}
