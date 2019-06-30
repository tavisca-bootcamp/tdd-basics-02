using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator    {
        
        public string UpdatedDisplay;
        public Operands Operands;
        public Dictionary<char, Operation> OperationMap;
        public readonly string ERROR = "-E-";
        
        public Calculator()
        {
            UpdatedDisplay = "0";
            Operands = new Operands();
            OperationMap = new Dictionary<char, Operation>(){
                                                               { '+',  new Addition()      },
                                                               { '-', new Subtraction()    },
                                                               { 'x', new Multiplication() },
                                                               { 'X', new Multiplication() },
                                                               { '/',  new Division()      },

                                                             };


        }
        
        
       

        public string SendKeyPress(char key)
        {
            
                switch (key)
                {
                    case var c when Character.IsDigitOrDot(c):
                        UpdatedDisplay=Operands.UpdateOperands(c);
                        break;

                    case var c when Character.IsSymbol(c):
                        UpdatedDisplay=DoOperation(c);
                        break;

                    case var c when Character.IsToggle(c):
                        UpdatedDisplay=Operands.ChangeSign();
                        break;

                    case var c when Character.IsSetZero(c):
                        UpdatedDisplay=SetZero();
                        break;
                    default://ignoring other characters and return previous displayed string
                        break;

                }


            if(Character.IsInfinity(UpdatedDisplay))
            {
                Operands.Reset();
                UpdatedDisplay = "0";
                return ERROR;

            }
           
            return UpdatedDisplay;

        }

        private string SetZero()
        {
            Operands.Reset();
            return "0";
        }

        

        private string DoOperation(char key)
        { string result= UpdatedDisplay;
            if (Operands.Symbol == null)
                Operands.Symbol = key;
            else
            {
                   double operandOne = double.Parse(Operands.FirstOperand);
                    double operandTwo = double.Parse(Operands.SecondOperand);
                     result = OperationMap[Operands.Symbol.Value].DoCalculation(operandOne, operandTwo);
                    Operands.FirstOperand = result;

                    Operands.SecondOperand = null;

                    if (key == '=')
                        Operands.Symbol = null;
                    else
                        Operands.Symbol = key;
                   
                
            }
            return result;
        }

       

        
    }
}
