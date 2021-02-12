using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Operations
    {
        public static double Sum(double arguement1, double arguement2)
        {
            return arguement1 + arguement2;
        }

        public static double Subtraction(double arguement1, double arguement2)
        {
            return arguement1 - arguement2;
        }

        public static double Multiplication(double arguement1, double arguement2)
        {
            return arguement1 * arguement2;
        }

        public static double Division(double arguement1, double arguement2)
        {
            return arguement1 / arguement2;
        }

        public static double Operation(double arguement1, double arguement2, char operation)
        {
            if(operation == '+')
            {
                return Sum(arguement1, arguement2);
            }
            else if(operation == '-')
            {
                return Subtraction(arguement1, arguement2);
            }
            else if (operation == 'x' || operation == '*')
            {
                return Multiplication(arguement1, arguement2);
            }
            else if (operation == '/')
            {
                return Division(arguement1, arguement2);
            }
            else if(operation == '0')
            {
                return arguement1;
            }

            return -1;
        }

        public static string FindCalculatorOutput(string InputArguement)
        {
            string result = "";
            Calculator calc = new Calculator();
            foreach(char c in InputArguement){
                result = calc.SendKeyPress(c); 
            }
            return result;
        }
    }
}
