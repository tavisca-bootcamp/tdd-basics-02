using ConsoleCalculator.Interfaces;
using ConsoleCalculator.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator.Factories
{
    public class OperatorFactory
    {
        Dictionary<char, IOperation> Operations = new Dictionary<char, IOperation>()
        {
            { Common.Common.Addition, new Addition()},
            { Common.Common.Subtraction, new Subtraction()},
            { Common.Common.Multiplication, new Multiplication()},
            { Common.Common.Division, new Division()}
        };

        public IOperation GetOperation(char operation)
        {
            return Operations[Char.ToUpper(operation)];
        }
    }
}
