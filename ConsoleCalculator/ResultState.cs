using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    class ResultState : State
    {
        public ResultState()
        {
            input = "0";
        }
        public void Clear()
        {
            input = "0";
        }
    }
}