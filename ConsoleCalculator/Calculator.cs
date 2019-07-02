using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string firstOperand = "";
        private string secondOperand = "";
        private char? opcode = null;
        public string SendKeyPress(char key)
        {
            // Add your implementation here.
            if(key == 'c' || key == 'C')
            {
                ResetDisplay();
                return "0";
            }

            if(key == 's' || key == 'S')
            {
                if(opcode == null)
                {
                    firstOperand = (-1 * float.Parse(firstOperand)).ToString();
                    return firstOperand;
                }
                else
                {
                    secondOperand = (-1 * float.Parse(secondOperand)).ToString();
                    return secondOperand;
                }
            }

            switch(key)
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
                    if(opcode == null)
                    {
                        if(firstOperand == "0")
                        {
                            firstOperand = key.ToString();
                        }
                        else
                        {
                            firstOperand += key.ToString();
                        }
                        return firstOperand;
                    }
                    else
                    {
                        if(secondOperand == "0")
                        {
                            secondOperand = key.ToString();
                        }
                        else
                        {
                            secondOperand += key.ToString();
                        }
                        return secondOperand;
                    }                   
            }

            if(key == '.')
            {
                if(opcode == null)
                {
                    if(LowestSignificantBitOfVariable(firstOperand) != '.')
                    {
                        firstOperand += key.ToString();
                        return firstOperand;
                    }
                }
                else
                {
                    if(LowestSignificantBitOfVariable(secondOperand) != '.')
                    {
                        secondOperand += key.ToString();
                        return secondOperand;
                    }
                }
            }

            switch(key)
            {
                case '+':
                case '-':
                case 'x':
                case 'X':
                case '/':
                    if(opcode == null)
                    {
                        opcode = key;
                        return firstOperand;
                    }
                    firstOperand = CalculateResultUsingLastTwoOperands();
                    if(firstOperand == "error")
                    {
                        return ErrorMessage();
                    }
                    secondOperand = "";
                    opcode = key;
                    return firstOperand;
            }

            if(key == '=')
            {
                if(opcode == null)
                {
                    return firstOperand;
                }
                firstOperand = SendKeyPress((char)opcode);
                if(firstOperand == "-E-")
                {
                    return ErrorMessage();
                }
                secondOperand = "";
                opcode = null;

                return firstOperand;
            }

            if(opcode == null)
            {
                return firstOperand;
            }
            else
            {
                return secondOperand;
            }
            throw new NotImplementedException();
        }
        private string ErrorMessage()
        {
            ResetDisplay();
            return "-E-";
        }

        private string CalculateResultUsingLastTwoOperands()
        {
            if(secondOperand == "")
            {
                secondOperand = firstOperand;
            }
            float operand1 = float.Parse(this.firstOperand);
            float operand2 = float.Parse(this.secondOperand);

            switch(opcode)
            {
                case '+':
                    return (operand1 + operand2).ToString();
                case '-':
                    return (operand1 - operand2).ToString();
                case 'x':
                case 'X':
                    return (operand1 * operand2).ToString();
                case '/':
                    if(operand2 == 0)
                    {
                        return "error";
                    }
                    return (operand1 / operand2).ToString();
            }
            return "";
        }

        private char LowestSignificantBitOfVariable(string operand)
        {
            return operand[operand.Length - 1];
        }

        private void ResetDisplay()
        {
            firstOperand = "0";
            secondOperand = "0";
            opcode = null;
        }
    }
}
