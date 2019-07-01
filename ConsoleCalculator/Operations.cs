using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    class Operations
    {
        public static string Addition(double operandOne, double operandTwo)
        {
            double temp = operandOne + operandTwo;

            if (temp % 1 != 0.0)
                return temp.ToString();
            int result = (int)temp;
            return result.ToString();

        }
        public static string Subtraction(double operandOne, double operandTwo)
        {
            double temp = operandOne - operandTwo;

            if (temp % 1 != 0.0)
                return temp.ToString();
            int result = (int)temp;
            return result.ToString();

        }
        public static string Multiplication(double operandOne, double operandTwo)
        {
            double temp = operandOne * operandTwo;

            if (temp % 1 != 0.0)
                return temp.ToString();
            int result = (int)temp;
            return result.ToString();

        }
        public static string Division(double operandOne, double operandTwo)
        {
            double temp = operandOne / operandTwo;

            if (temp % 1 != 0.0)
                return temp.ToString();
            int result = (int)temp;
            return result.ToString();

        }

    }
}
