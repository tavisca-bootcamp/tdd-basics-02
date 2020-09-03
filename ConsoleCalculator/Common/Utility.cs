using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleCalculator.Common
{
    public static class Utility
    {
        public static KeyType GetKeyType(char key)
        {
            if (IsNumber(key))
                return KeyType.Number;
            else if (IsOperation(key))
                return KeyType.Operator;
            else if (key.ToString().Equals("s", StringComparison.OrdinalIgnoreCase))
                return KeyType.Sign;
            else if (key.ToString().Equals("c", StringComparison.OrdinalIgnoreCase))
                return KeyType.Clear;
            else if (key.Equals('.'))
                return KeyType.Decimal;
            else if (key.Equals('='))
                return KeyType.Equals;

            return KeyType.Undefined;
        }

        public static bool IsNumber(char digit)
        {
            return new Regex(@"[0-9]").IsMatch(digit.ToString());
        }

        public static bool IsOperation(char operation)
        {
            return new Regex(@"[+\-Xx\/]").IsMatch(operation.ToString());
        }
    }
}
