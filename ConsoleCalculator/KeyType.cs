using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public enum KeyType
    {
        Default = 0,
        Number,
        DecimalPoint,
        MathOperation,
        EqualTo,
        Toggle,
        Reset,
        NotAllowedCharacter
    }
}
