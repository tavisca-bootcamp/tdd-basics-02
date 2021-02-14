using System;
using System.Linq;

namespace ConsoleCalculator
{
    public class Calculator
    { 
        
        public string Operand1;
        public string Operand2;
        public string Answer;
        public char FinalOperator;
        public bool CheckOperand;
        public bool CheckOperator;


        public Calculator()
        {
            Operand1 = null;
            Operand2 = null;
            Answer = "";
            FinalOperator = 'N';
            CheckOperand = false;
            CheckOperator = false;

        }

        public bool CorrectOperatorMethod(char key)
        {
            char[] validOperator = { '+', '-', '/', '=', 'x', 'X', 'c', 'C', 's', 'S' }; return validOperator.Contains(key);

        }

        public bool CorrectOperandMethod(char key)
        {
            char[] validOperand = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; return validOperand.Contains(key);

        }

        public string SendKeyPress(char key)
        {
            

            CheckOperand = false;

           
            switch (key)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '.':
                    CheckOperand = CorrectOperandMethod(key);
                    break;

                case '+':
                case '-':
                case 'x':
                case 'X':
                case '/':
                    CheckOperator = CorrectOperatorMethod(key);
                    FinalOperator = key;
                    break;

                case '=':
                case 'c':
                case 'C':
                    CheckOperator = CorrectOperatorMethod(key);
                    break;
                case 's':
                case 'S':
                    CheckOperator = CorrectOperatorMethod(key);
                    break;
            }
            
            if (CheckOperator == false && CheckOperand == true)
            {
                Operand1 = Operand1 + key;
                Answer = Operand1;
            }

            
            if (CheckOperator == true && CheckOperand == true)
            {
                Operand2 = Operand2 + key;
                Answer = Operand2;
            }

            if (CheckOperand == false && CheckOperator == false)
                Answer = "-E-";

            
            if (key == '.')
            {
                if (CheckOperator == false)
                {
                    Operand1 = DecimalPoint(Operand1);
                    Answer = Operand1;
                }

                else
                {
                    Operand2 = DecimalPoint(Operand2);
                    Answer = Operand2;
                }

            }

            if (key == 'c' || key == 'C')
                Answer = ClearConsole();

            if (key == 's' || key == 'S')
            {

                
                if (Operand2.Equals(null))
                {
                    Operand1 = Toggle(Operand1);
                    Answer = Operand1;
                }

                
                else
                {
                    Operand2 = Toggle(Operand2);
                    Answer = Operand2;
                }

            }
            if (!string.Equals(Operand1, null) && !string.Equals(Operand2, null) && key == '=')
            {

                if (FinalOperator == '+') 
                    Answer = Add(Operand1, Operand2);
                if (FinalOperator == '-')  
                    Answer = Subtract(Operand1, Operand2);
                if (FinalOperator == 'x' || FinalOperator == 'X')  
                    Answer = Multiply(Operand1, Operand2);
                if (FinalOperator == '/')  
                    Answer = Divide(Operand1, Operand2);

            }

            return Answer;

            
        }

        

        public string DecimalPoint(string operand)
        {
            
            if (string.Equals(operand, null))
                operand = "0.";
            else
            {
               
                if (!operand.Contains('.') && Convert.ToInt32(operand) != 0)
                    operand = operand + ".";
               
                if (operand.Contains('.'))
                {
                    if (Convert.ToDouble(operand) == 0.0)
                        operand = "0.";
                }

            }
            return operand;
        }

        public string Add(string operand1, string operand2)
        {
                     
            double Addition = Convert.ToDouble(operand1) + Convert.ToDouble(operand2); return Addition.ToString();

        }

        public string Subtract(string operand1, string operand2)
        {
            
            double Substraction = Convert.ToDouble(operand1) - Convert.ToDouble(operand2); return Substraction.ToString();

        }

        public string Multiply(string operand1, string operand2)
        {
          
            double Multiplication = Convert.ToDouble(operand1) * Convert.ToDouble(operand2); return Multiplication.ToString();

        }

        public string Divide(string operand1, string operand2)
        {
            
            double quotient;
            try
            {
                if (Convert.ToDouble(operand2) == 0.0)
                    throw new DivideByZeroException();
                else
                    quotient = Convert.ToDouble(operand1) / Convert.ToDouble(operand2);
            }
            catch (DivideByZeroException)
            {
                return "-E-";
            }
            return quotient.ToString();
        }

        
        public string Toggle(string operand1)
        {
           
            return (-1 * (Convert.ToDouble(operand1))).ToString();
        }

        
        public string ClearConsole()
        {
            return "0";
        }
    }
}
