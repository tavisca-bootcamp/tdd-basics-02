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
        public bool IsResetKey(char key)
        {
            if (key == 'c' || key == 'C')
                return true;
            else
                return false;
            throw new NotImplementedException();
        }

        public string Divide(double firstNumber, double secondNumber)
        {
            return (firstNumber / secondNumber).ToString();
            throw new NotImplementedException();
        }

        public string Multiply(double firstNumber, double secondNumber)
        {
            return (firstNumber * secondNumber).ToString();
            throw new NotImplementedException();
        }

        public string Substract(double firstNumber, double secondNumber)
        {
            return (firstNumber - secondNumber).ToString();
            throw new NotImplementedException();
        }

        public string Add(double firstNumber, double secondNumber)
        {
            return (firstNumber + secondNumber).ToString();
            throw new NotImplementedException();
        }

        public bool IsDivide(char key)
        {
            if (key == '/')
                return true;
            else return false;
            throw new NotImplementedException();
        }

        public bool IsMultiply(char key)
        {
            if (key == 'x' || key == 'X')
                return true;
            else
                return false;
            throw new NotImplementedException();
        }

        public bool IsSubstract(char key)
        {
            if (key == '-')
                return true;
            else
                return false;
            throw new NotImplementedException();
        }

        public bool IsAdd(char key)
        {
            if (key == '+')
                return true;
            else
                return false;
            throw new NotImplementedException();
        }

        public bool IsDecimalPoint(char key)
        {
            if (key == '.')
                return true;
            else
                return false;
            throw new NotImplementedException();
        }

        public bool IsNegativeInteger(char key)
        {
            if (key == 's' || key == 'S')
                return true;
            else
                return false;
            throw new NotImplementedException();
        }

        public bool IsEqualOperator(char key)
        {
            if (key == '=')
                return true;
            else
                return false;
            throw new NotImplementedException();
        }

        public bool IsArithmeticOperator(char key)
        {
            if (key == '+' || key == '-' || key == 'x' || key == 'X' || key == '/' || key == '=')
                return true;
            else
                return false;
            throw new NotImplementedException();
        }

        public bool IsNumber(char key)
        {
            if (key >= '0' && key <= '9')
                return true;
            else
                return false;
            //throw new NotImplementedException();
        }
    }
}
