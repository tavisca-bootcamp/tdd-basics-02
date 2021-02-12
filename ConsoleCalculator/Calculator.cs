using System;

namespace ConsoleCalculator
{
    public class Calculator
    {

     /* static void Main() {
    Console.WriteLine("Hello World");*/
    public string SendKeyPress(char key)
        {
            // Add your implementation here.
        //throw new NotImplementedException();
        public string operands{get;set;} = "0";
       
        char? operator1=null;
        string Result;
        public string SendKeyPress(char key)
        {           if(key == '=')
                {
                if (operator1 == '+') 
                return (Int32.Parse(Result) + Int32.Parse(operands)).ToString();
                if (operator1 == '-')
                return (Int32.Parse(Result) - Int32.Parse(operands)).ToString();
                if (operator1 == '*')
                return (Int32.Parse(Result) * Int32.Parse(operands)).ToString();
                if (operator1 == '/')
                {
                    if (operands == "0")
                        return "-E-";
                    return (Int32.Parse(Result) / Int32.Parse(operands)).ToString();
                }
            }
             else if (key == '.' && operands[operands.Length - 1] == '.')
            {
                return operands;
            }
            else if (key == 'C' || key == 'c')
            {
                operands = "0";
                return operands;
            }
           else if (key != '0' && operands.Length == 1 && operands[0] == '0')
            {
                operands = string.Empty;
                operands += key;
                return operands;
            }
            else if (key == '0' && operands.Length == 1 && operands[0] == '0')
            {
                return operands;
            }
            
            else if (key == 's' || key == 'S')
            {
                int number = Int32.Parse(operands);
                number = number * -1;
                operands = number.ToString();
                return operands;
            }
            else
            {
                    if (!("+-+/*".Contains(key)))
                        operands += key;
                    else
                    {
                    if (operator1 == null)
                    {
                        operator1 = key;
                        Result = string.Copy(operands);
                    }
                    else
                    {
                        if (operator1 == '+')
                        {
                            Result = (Int32.Parse(Result) + Int32.Parse(operands)).ToString();
                            operands = string.Empty;
                            return Result;
                        }
                        if (operator1 == '-')
                        {
                            Result = (Int32.Parse(Result) - Int32.Parse(operands)).ToString();
                            operands = string.Empty;
                            return Result;
                        }
                        if (operator1 == '*')
                        { Result =  (Int32.Parse(Result) * Int32.Parse(operands)).ToString();
                            operands = string.Empty;
                            return Result;
                        }
                        if (operator1 == '/')
                        {
                            if (operands == "0")
                              { Result = string.Empty;
                                operands = string.Empty;
                                return "-E-"; }
                            Result = (Int32.Parse(Result) / Int32.Parse(operands)).ToString();
                            operands = string.Empty;
                            return  Result;
                        }
                        operator1 = key;
                    }
                        operands = string.Empty;
                    }

                    return operands;
            }
            return operands;
  }
    }
}
