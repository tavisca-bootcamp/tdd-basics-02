using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string Display;
        public string FirstOperand;
        public string SecondOperand;
        public Nullable<char> Symbol;
        public string SendKeyPress(char key)
        {
            // Add your implementation here.
            //const char localVariable = key;
            switch (key)
            {
                case var localVariable when Character.IsDigitOrDot(localVariable):
                    Display = UpdateOperands(localVariable);
                    break;

                default:
                    break;
            }
            Console.WriteLine(Display);

            return Display;
           
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
        
    }
}
