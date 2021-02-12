using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{

    public class Calculator
    {
        string expression = "";
        char op = '+';
        decimal num = 0;
        decimal result = 0;
        int f = 0, point=0;
        char[] opr = { '+', '-', '*', '/' };

       

        public string SendKeyPress(char key)
        {
            HashSet<char> operators = new HashSet<char>(opr);

            if ( (int)key>=48 && (int)key<=57 )
            {
                f = 0;
                int n = (int)key - 48;
                if (expression.Equals("0"))
                    expression = "";
                expression = expression + n;
                return expression;
            }
            else if (operators.Contains(key))
            {
                if (f != 0)
                    return "-E-";
                f = 1;
                point = 0;
                decimal n1 = 0;
                n1 = decimal.Parse(expression);
                if (op == '+')
                {
                    num = num + n1;
                }
                else if (op == '-')
                {
                    num = num - n1;
                }
                else if (op == '*')
                {
                    num = num * n1;
                }
                else if (n1 == 0)
                {
                    return "-E-";
                }
                else
                {
                    num = num / n1;
                }

                if (key =='+' || key == '-')
                {
                    result = result + num;
                    num = 0;
                }
                op = key;

                expression = "";

                decimal x = result + num;
                string y = "" + x;
                return y;
            }

            if (key == '.')
            {
                if (point == 0)
                {
                    if (expression.Length == 0)
                        expression = "0";
                    expression = expression + ".";
                    point = 1;
                }
                return expression;
            }

            if (key == 'S')
            {
                if (expression.Length == 0)
                {
                    result = 0-result;
                    return ("" + result);
                }
                if (expression[0] == '-')
                    expression = expression.Substring(1);
                else if (!expression.Equals("0"))
                    expression = "-" + expression;
                return expression;
            }



            if (key == '=')
            {
                if (f != 0)
                {
                    return "-E-";
                }
                point = 0;
                decimal n1 = 0;
                if (expression.Length > 0)
                    n1 = decimal.Parse(expression);
                if (op == '+')
                {
                    result = result + n1;
                }
                else if (op == '-')
                {
                    result = result - n1;
                }
                else if (op == '*')
                {
                    num = num * n1;
                    result += num;
                    num = 0;
                }
                else if (n1 == 0)
                {
                    return "-E-";
                }
                else
                {
                    num = num / n1;
                    result += num;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    num = 0;
                }
                op = '+';
                return ("" + result);
                
            }

            if (key == 'C')
            {
                expression = "";
                op = '+';
                num = 0;      
                result = 0;                                                                                                                                                                                                                           
                f = 1                                                                                                                                          ;
                point = 0;
                return "0";
            }


            return "-E-";
        }
    }
}
