using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    class OperandState: State
    {
        public OperandState()
        {
            input = "";
        }
        public void Clear()
        {
            input = "";
        }
    }
}
