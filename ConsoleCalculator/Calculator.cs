using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string FirstOperand = "0";
        private string SecondOperand = "";
        private string result = "0";
        private char Operator = '+';
        //private int operatorCount = 0;


        public string SendKeyPress(char key)
        {
           
            if (key == 'C')
                reset();

            else if (key == 'S')
            {
                Toggle(result);
                //result = SecondOperand;
            }

            else if (isValidKey(key))
            {
                if (isValidNumber(key) || key == '.')
                {
                    SecondOperand += key;
                    result = SecondOperand;

                }
                else if (isValidOperator(key))
                {
                    calculateResult(Operator, FirstOperand, SecondOperand);
                    FirstOperand = result;
                    SecondOperand = "";
                    Operator = key;
                }

                /*if (isValidOperator(key))
                {
                    //Operator = key;
                    //result = FirstOperand;
                    //FirstOperand = "";
                    //operatorCount++;
                }*/
            }

            else
                return "0";
            
            return result;
        }



        private bool isValidKey(char key)
        {
            List<char> validKeys = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-', '+', 'x', 'X', '/', 's', 'S', 'c', 'C', '=' };
            return validKeys.Contains(key) ? true : false;
        }

        private bool isValidNumber(char key)
        {
            List<char> validKeys = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return validKeys.Contains(key) ? true : false;
        }

        private bool isValidOperator(char key)
        {
            List<char> validKeys = new List<char> { '-', '+', 'x', 'X', '/', '=' };
            return validKeys.Contains(key) ? true : false;
        }

        private void calculateResult(char Operator,string FirstOperand,string SecondOperand)
        {
            switch (Operator)
            {
                case '+':
                    result = (Double.Parse(FirstOperand) + Double.Parse(SecondOperand)).ToString();
                    break;

                case '-':
                    result = (Double.Parse(FirstOperand) - Double.Parse(SecondOperand)).ToString();
                    break;

                case 'x':
                    result = (Double.Parse(FirstOperand) * Double.Parse(SecondOperand)).ToString();
                    break;

                case '/':
                    try
                    {
                        if (SecondOperand == "0")
                            throw new DivideByZeroException();
                        result = (Double.Parse(FirstOperand) / Double.Parse(SecondOperand)).ToString();
                    }
                    catch (DivideByZeroException e)
                    {
                        result = "-E-";
                    }
                    break;

            }
        }

        private void reset()
        {
            FirstOperand = "";
            SecondOperand = "";
            Operator = '+';
            result = "0";
        }

        private void Toggle(string Operand)
        {
            result = (-Double.Parse(Operand)).ToString();
        }
    }
}
