using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class CalculatorLogic
    {
        public string DisplayValue { get; set; }
        public float Result { get; set; }
        public int Flag { get; set; }
        public char Operator { get; set; }

        public CalculatorLogic()
        {
            DisplayValue = "";
            Result = float.MinValue;
            Operator = '?';
            Flag = 0;
        }
        public bool IsResetKey(char key) => key == 'c' || key == 'C';

        public bool isKeyZero(char key) => key == '0';

        public float Divide(float firstOperand, float secondOperand) => firstOperand / secondOperand;


        public String calculateResult(char key)
        {
            if (Result != float.MinValue)
            {
                if (isAdd(key))
                    Result = Add(Result, float.Parse(DisplayValue));
                else if (isSubstract(key))
                    Result = Substract(Result, float.Parse(DisplayValue));
                else if (isMultiply(key))
                    Result = Multiply(Result, float.Parse(DisplayValue));
                else
                {
                    if (float.Parse(DisplayValue) != 0)
                        Result = Divide(Result, float.Parse(DisplayValue));
                    else
                        return "-E-";
                }
            }
            else
                Result = float.Parse(DisplayValue);
            Operator = key;
            DisplayValue = "";
            Flag = 0;
            return "Success";
        }

        public float Multiply(float firstOperand, float secondOperand) => firstOperand * secondOperand;

        public float Substract(float firstOperand, float secondOperand) => firstOperand - secondOperand;


        public float Add(float firstOperand, float secondOperand) => firstOperand + secondOperand;


        public bool sDivide(char key) => key == '/';

        public bool isMultiply(char key) => key == 'x' || key == 'X';


        public bool isSubstract(char key) => key == '-';

        public bool isAdd(char key) => key == '+';

        public bool IsDecimalPoint(char key)
        {
            if (key == '.')
                return true;
            else
                return false;
           
        }

        public bool IsNegativeNumber(char key) => (key == 's' || key == 'S');


        public bool IsEqualOperator(char key) => (key == '=');


        public bool IsArithmeticOperator(char key) => (key == '+' || key == '-' || key == 'x' || key == 'X' || key == '/');


        public bool IsNumber(char key) => key > '0' && key <= '9';

    }
}