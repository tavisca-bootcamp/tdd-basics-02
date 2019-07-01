using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private char[] validChar = new char[21] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', 'x', 'X', '/', 's', 'S', 'c', 'C', '=', '.' };
        private string operand1 = "0", operand2 = null;
        private char operation = '\0';
        private string IntOrDouble(string operand )
        {
            if (operand.IndexOf('.')==-1)
                operand = (int.Parse(operand)).ToString();
            else
                operand = (double.Parse(operand)).ToString();
            return operand;
        }
        private string DecimalHandle(string operand, char key)
        {
            if (operand.IndexOf('.')!=-1)
                return operand;
            else
            {
                operand = operand + key;
                return operand;
            }
        }
        private string ZeroHandle(string operand,char key)
        {
            if(operand == "0")
                return operand;
            else
            {
                operand = operand + key;
                return operand;
            }
        }
        private string Calculation(char dummyOperation,string operand1,string operand2)
        {
            int convertedOperand1 = Convert.ToInt32(operand1);
            int convertedOperand2 = int.Parse(operand2);
            int ans = 0;
            double doubleAns = 0;
            int flag = 0;
            switch (dummyOperation)
            {
                case '+':
                    ans = convertedOperand1 + convertedOperand2;
                    break;
                case '-':
                    ans = convertedOperand1 - convertedOperand2;
                    break;
                case 'x':
                case 'X':
                    ans = convertedOperand1 * convertedOperand2;
                    break;
                case '/':
                    if (convertedOperand1 % convertedOperand2 == 0)
                        ans = convertedOperand1 / convertedOperand2;
                    else
                    {
                        double doubleOperand1 = Double.Parse(operand1);
                        double doubleOperand2 = Double.Parse(operand2);
                        doubleAns = doubleOperand1 / doubleOperand2;
                        flag = 1;
                    }
                    break;
            }
           
            if (flag == 0)
                operand1 = ans.ToString();
            else
                operand1 = doubleAns.ToString();
            //operand2 = null;
            return operand1;
        }
        public string SendKeyPress(char key)
        {
            // Add your implementation here.
            
            if(Array.IndexOf(validChar,key)!=-1)
            {
                if (Char.IsDigit(key)&& key =='0')
                {
                    if (operation == '\0')
                    {
                        operand1 = ZeroHandle(operand1, key);
                        return operand1;
                    }
                    else
                    {
                        operand2 = ZeroHandle(operand2, key);
                        return operand2;
                    }

                }
                else if (Char.IsDigit(key))
                {
                    if (operation == '\0')
                    {
                        operand1 = operand1 + key;
                        operand1 = IntOrDouble(operand1);
                        return operand1;
                    }
                    else
                    {
                        operand2 = operand2 + key;
                        operand1 = IntOrDouble(operand1);
                        return operand2;
                    }
                }
                else if (key == '.')
                {
                    if (operation == '\0')
                    {
                        operand1 = DecimalHandle(operand1, key);
                        return operand1;
                    }
                    else
                    {
                        operand2 = DecimalHandle(operand2, key);
                        return operand2;
                    }

                }
                else if(key != '=')
                {
                    if (operation == '\0')
                    {
                        operation = key;
                        return operand1;
                    }
                    else
                    {
                        char dummyOperation = operation;
                        operation = key;
                        operand1 = Calculation(dummyOperation, operand1, operand2);
                        operand2 = null;
                        return operand1;
                        
                    }
                }
                else
                {
                    if (operation != '\0')
                    {
                        operand1 = Calculation(operation, operand1, operand2);
                        operand2 = null;
                        return operand1;
                    }
                    return operand1;
                }
            }
            else
            {
                if (operand2 == null)
                {
                    operand1 = (int.Parse(operand1)).ToString();
                    return operand1;
                }
                else
                {
                    operand2 = (int.Parse(operand2)).ToString();
                    return operand2;
                }
            }
            throw new NotImplementedException();
        }
    }
}
