using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator.Interfaces
{
    public interface IOperation
    {
        char Operation { get; }

        double Operate(double operand1, double operand2);
    }
}
