using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    class Character
    {
        public static bool IsDigitOrDot(char key)
        {
            return (key >= '0' && key <= '9') || key == '.';
        }
           
       
        
    }
}
