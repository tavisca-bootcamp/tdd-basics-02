using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public static class MathCalculator
    {
        private static string result = null;
        private const string ErrorCode = "-E-";

        public static string Add(float firstNumber, float secondNumber)
        {
            result = (firstNumber + secondNumber).ToString();
            return result;

        }
        public static string Subtract(float firstNumber, float secondNumber)
        {
            result = (firstNumber - secondNumber).ToString();
            return result;
        }
        public static string Multiply(float firstNumber, float secondNumber)
        {
            result = (firstNumber * secondNumber).ToString();
            return result;
        }
        public static string Divide(float firstNumber, float secondNumber)
        {
            if (secondNumber == 0)
            {
                result = ErrorCode;
            }
            else
            {
                result = (firstNumber / secondNumber).ToString();
            }
            return result;
        }
    }
}
