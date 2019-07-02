using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string Display;
        private string FirstOperand;
        private string SecondOperand;
        private Nullable<char> Symbol;
        public string SendKeyPress(char key)
        {
            // Add your implementation here.
            
            switch (key)
            {
                case var localVariable when Character.IsDigitOrDot(localVariable): // update operand at the time of input only
                    Display = UpdateOperands(localVariable);
                    break;
                case var localVariable when Character.IsOperator(localVariable):// do arithimatic operations
                    Display = DoOperation(localVariable);
                    break;
                case 's':
                case 'S':
                    Display = Toggle();
                    break;
                case 'c':
                case 'C':
                    Display = Reset();
                    break;

                default:
                    break;
            }
            //Console.WriteLine(Display);

            return Display;
           
        }

        private string DoOperation(char key)
        {
            string result = Display;
            if (Symbol == null)
                Symbol = key;
            else
            {
                double operandOne = double.Parse(FirstOperand);
                double operandTwo = double.Parse(SecondOperand);
                if (Symbol == 'x')
                    Symbol = 'X';
                switch(Symbol)
                {
                    case '+':
                        result = Operations.Addition(operandOne, operandTwo);
                        break;
                    case '-':
                        result = Operations.Subtraction(operandOne, operandTwo);
                        break;
                    case 'X':
                        result = Operations.Multiplication(operandOne, operandTwo);
                        break;
                    case '/':
                        result = Operations.Division(operandOne, operandTwo);
                        break;
                }
                
                FirstOperand = result;

                SecondOperand = null;

                if (key == '=')
                    Symbol = null;
                else
                    Symbol = key;


            }
            return result;
        }
        private string UpdateOperands(char key)
        {
            String result;
            if (Symbol != null)
            {
                SecondOperand = UpdateIndividualOperand(SecondOperand, key);
                result = SecondOperand;
            }
            else
            {
                FirstOperand = UpdateIndividualOperand(FirstOperand, key);
                result = FirstOperand;

            }
            return result;
        }
        private string UpdateIndividualOperand(string operand, char key)
        {
            switch (operand)
            {
                case var temporaryVariable when temporaryVariable == null: return key.ToString();// 1st key
                case var temporaryVariable when  temporaryVariable.Contains(".") && key == '.': return operand;// handle ..
                case var temporaryVariable when  temporaryVariable.Equals("0") && key == '0': return "0"; // handle 0 0 before .
                default: return String.Concat(operand, key.ToString()); // handle 1 2 = 12
            }

        }
        private string Toggle()
        {
            string result; // temporary result to store either 1st or 2nd operand
            if (SecondOperand == null)
            {
                double temp = double.Parse(FirstOperand);
                temp = -temp;
                FirstOperand = temp.ToString();
                result = FirstOperand;
                //result = (-(double.Parse(FirstOperand))).ToString();

            }
            else
            {
                double temp = double.Parse(SecondOperand);
                temp = -temp;
                SecondOperand = temp.ToString();
                result = SecondOperand;
                //result = (-(double.Parse(SecondOperand))).ToString();
            }
            return result;

        }
        private string Reset()
        {
            FirstOperand = "";
            SecondOperand = "";
            return "0";
        }

        
    }
}
