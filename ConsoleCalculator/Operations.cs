using System;
using System.Collections.Generic;
using System.Text;

namespace Operation
{
    class Operations
    {
        public static bool IsDot(char key)
        {
            return key == 46;
        }
        public static bool IsToggle(char key)
        {
            return key == 83 || key == 115;
        }
        public static bool IsClear(int keyValue)
        {
            return keyValue == 'c' || keyValue == 'C';
        }

        public string Multiply(double operand1, double operand2)
        {
            return (operand1 * operand2).ToString();
        
        }

        public string Division(double operand1, double operand2)
        {
            if (operand2 == 0)
            {
                return "-E-";
            }
            else
            {
                return (operand1 / operand2).ToString();
            }
            
        }

        public string Subtract(double operand1, double operand2)
        {
            return (operand1 - operand2).ToString();
 
        }

        public string Add(double operand1, double operand2)
        {
            return (operand1 + operand2).ToString();

        }

        public static bool IsEqual(int keyValue)
        {
            return keyValue == 61;
        }

        public static bool IsOperator(int keyValue)
        {
            return keyValue == 45 || keyValue == 43 || keyValue == 47 || keyValue == 88 || keyValue == 120;
        }

        public static bool IsNumber(int keyValue)
        {
            return keyValue >= 48 && keyValue <= 57;
        }
    }
}
