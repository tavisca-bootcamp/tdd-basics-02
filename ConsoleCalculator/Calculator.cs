using System;

namespace ConsoleCalculator
{
    public class Calculator
    {

        public string SendKeyPress(char key)
        {
                   public string expression{get;set;} = "0";
        int? number1=null;
        int? number2=null;
        char? operation=null;
        string Result;
        public string SendKeyPress(char key)
        {           if(key == '=')
                {
                if (operation == '+') return (Int32.Parse(Result) + Int32.Parse(expression)).ToString();
                if (operation == '-') return (Int32.Parse(Result) - Int32.Parse(expression)).ToString();
                if (operation == '*') return (Int32.Parse(Result) * Int32.Parse(expression)).ToString();
                if (operation == '/')
                {
                    if (expression == "0")
                        return "-E-";
                    return (Int32.Parse(Result) / Int32.Parse(expression)).ToString();
                }
            }
            else if (key == 'C' || key == 'c')
            {
                expression = "0";
                return expression;
            }
            else if (key == '.' && expression[expression.Length - 1] == '.')
            {
                return expression;
            }
            else if (key == '0' && expression.Length == 1 && expression[0] == '0')
            {
                return expression;
            }
            else if (key != '0' && expression.Length == 1 && expression[0] == '0')
            {
                expression = string.Empty;
                expression += key;
                return expression;
            }
            else if (key == 's' || key == 'S')
            {
                int number = Int32.Parse(expression);
                number = number * -1;
                expression = number.ToString();
                return expression;
            }
            else
            {
                
                
                    if (!("+-+/*".Contains(key)))
                        expression += key;
                    else
                    {
                    if (operation == null)
                    {
                        operation = key;
                        Result = string.Copy(expression);
                    }
                    else
                    {
                        if (operation == '+')
                        {
                            Result = (Int32.Parse(Result) + Int32.Parse(expression)).ToString();
                            expression = string.Empty;
                            return Result;
                        }
                        if (operation == '-')
                        {
                            Result = (Int32.Parse(Result) - Int32.Parse(expression)).ToString();
                            expression = string.Empty;
                            return Result;
                        }
                        if (operation == '*')
                        { Result =  (Int32.Parse(Result) * Int32.Parse(expression)).ToString();
                            expression = string.Empty;
                            return Result;
                        }
                        if (operation == '/')
                        {
                            if (expression == "0")
                              { Result = string.Empty;
                                expression = string.Empty;
                                return "-E-"; }
                            Result = (Int32.Parse(Result) / Int32.Parse(expression)).ToString();
                            expression = string.Empty;
                            return  Result;
                        }
                        operation = key;
                    }
                        expression = string.Empty;
                    }

                    return expression;
                
                
            }
            return expression;
                // Add your implementation here.
                
            
        
        }
    }
}
