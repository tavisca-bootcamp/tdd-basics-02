using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class CalculatorUtility
    {

        //public double FirstNumber { get; set; }
        //public double SecondNumber { get; set; }
        //public string Number { get; set; }
        //public char OperatorKey { get; set; }
        //public int OperatorOccurance { get; set; }
        //public bool Is { get; set; }
        public string Number { get; set; }
        public float Result { get; set; }
        public int Flag { get; set; }
        public char PreviousOperator { get; set; }

       public CalculatorUtility()
        {
            Number = "";
            Result = float.MinValue;
            PreviousOperator = '?';
            Flag = 0;
        }
        public bool IsResetKey(char key) => key == 'c' || key == 'C';
      
        public bool isKeyZero(char key) => key == '0';
   
        public float Divide(float firstNumber, float secondNumber) => firstNumber / secondNumber;
        

        public String calculateResult(char key)
        {
            if (Result != float.MinValue)
            {
                if (IsAdd(key))
                    Result = Add(Result, float.Parse(Number));
                else if (IsSubstract(key))
                    Result = Substract(Result, float.Parse(Number));
                else if (IsMultiply(key))
                    Result = Multiply(Result, float.Parse(Number));
                else
                {
                    if (float.Parse(Number) != 0)
                        Result = Divide(Result, float.Parse(Number));
                    else
                        return "-E-";
                }
            }
            else
                Result = float.Parse(Number);
            PreviousOperator = key;
            Number = "";
            Flag = 0;
            return "Success";
        }

        public float Multiply(float firstNumber, float secondNumber) => firstNumber * secondNumber;
         
        public float Substract(float firstNumber, float secondNumber) => firstNumber - secondNumber;
         

        public float Add(float firstNumber, float secondNumber) => firstNumber + secondNumber;
         

        public bool IsDivide(char key) => key == '/';
       
        public bool IsMultiply(char key) => key == 'x' || key == 'X';


        public bool IsSubstract(char key) => key == '-';
        
        public bool IsAdd(char key) => key == '+';
        
        public bool IsDecimalPoint(char key)
        {
            if (key == '.')
                return true;
            else
                return false;
            //throw new NotImplementedException();
        }

        public bool IsNegativeNumber(char key) => (key == 's' || key == 'S');


        public bool IsEqualOperator(char key) => (key == '=');


        public bool IsArithmeticOperator(char key) => (key == '+' || key == '-' || key == 'x' || key == 'X' || key == '/');

             
        public bool IsNumber(char key) => key > '0' && key <= '9';
       
    }
}
