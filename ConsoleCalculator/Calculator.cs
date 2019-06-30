using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string FirstOperand;
        public string SecondOperand;
        public string DisplayString="0";
        public Nullable<char> Symbol;
        public Dictionary<char, Operation> OperationMap = new Dictionary<char, Operation>()
        {
            {'+',new Addition() },
            {'-',new Subtraction() },
            {'x',new Multiplication() },
            {'X',new Multiplication() },
            {'/',new Division() },

        };
        
        
       

        public string SendKeyPress(char key)
        {
            switch(key)
            {
                case var c when Character.IsDigit(c) :
                           UpdateOperands(c);
                             break;

                case var c when Character.IsSymbol(c):
                            DoOperation(c);
                            break;

                case var c when Character.IsToggle(c):
                            ChangeSign();
                            break;

                case var c when Character.IsSetZero(c):
                            SetZero();
                            break;
                default://ignoring other characters and return previous displayed string
                            break;




            }
            return DisplayString;

        }

        private void SetZero()
        {
            FirstOperand = null;
            SecondOperand = null;
            Symbol = null;
            DisplayString = "0";
        }

        private void ChangeSign()
        {
            if (SecondOperand == null)
            {
                FirstOperand = Toggle(FirstOperand);
                DisplayString = FirstOperand;
            }
            else
            {
                SecondOperand = Toggle(SecondOperand);
                DisplayString = SecondOperand;
            }

        }

        private string Toggle(string operand)
        {
            double temp = double.Parse(operand);
            temp = -temp;
            return temp.ToString();
            
        }

        private void DoOperation(char key)
        {
            if (Symbol == null)
                Symbol = key;
            else
            {
                double operandOne = double.Parse(FirstOperand);
                double operandTwo = double.Parse(SecondOperand);
                String result = OperationMap[Symbol.Value].DoCalculation(operandOne, operandTwo);
                FirstOperand = result;
                
                SecondOperand = null;

                if (key == '=')
                    Symbol = null;
                else
                    Symbol = key;
                DisplayString = result;



            }
        }

        private void UpdateOperands(char key)
        {   if (Symbol.HasValue)
            {   SecondOperand = UpdateSpecificOperand(SecondOperand,key);
                DisplayString = SecondOperand;
            }
            else
            {
                FirstOperand = UpdateSpecificOperand(FirstOperand, key);
                DisplayString = FirstOperand;

            }
           
        }

        private string UpdateSpecificOperand(string operand ,char key)
        {
            switch(operand)
            {
                case var c when c == null:return key.ToString();
                case var c when c.Equals("0") && key == '0':return "0";
                default:return String.Concat(operand, key.ToString());
            }
           
        }
    }
}
