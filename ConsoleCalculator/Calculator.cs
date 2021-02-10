using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{

    public class Calculator
    {
        readonly char[] _operators = { '+', '-', '*', '/' };
        string expression = ""; char current_key = '+';
        decimal number = 0; decimal result = 0;
        int operator_flag = 0, decimal_flag = 0;
        public string SendKeyPress(char key)
        {
            HashSet<char> Operator = new HashSet<char>(_operators);

            if ((int)key >= 48 && (int)key <= 57)
            {
                operator_flag = 0;
                int current_number = (int)key - 48;
                if (expression.Equals("0")) expression = "";
                expression = $"{expression}{current_number}";
                return expression;
            }

            else if (Operator.Contains(key))
            {
                if (operator_flag != 0) return "-E-";
                operator_flag = 1;
                decimal_flag = 0;
                decimal num = decimal.Parse(expression);
                if (current_key == '+') number += num;

                else if (current_key == '-') number -= num;

                else if (current_key == '*') number *= num;

                else if (num == 0) return "-E-";

                else number /= num;

                if (key == '+' || key == '-')
                {
                    result += number;
                    number = 0;
                }
                current_key = key;

                expression = "";

                decimal temp_num1 = result + number;
                string temp_result = "" + temp_num1;
                return temp_result;
            }


            if (key == 'S' || key == 's')
            {
                if (expression.Length == 0)
                {
                    result = -1 * result;
                    return ("" + result);
                }
                if (expression[0] == '-') expression = expression.Substring(1);

                else if (!expression.Equals("0")) expression = "-" + expression;

                return expression;
            }

            if (key == 'C' || key == 'c')
            {
                expression = ""; current_key = '+'; number = 0; result = 0;
                operator_flag = 1;
                decimal_flag = 0;
                return "0";
            }

            if (key == '.')
            {
                if (decimal_flag == 0)
                {
                    if (expression.Length == 0) expression = "0";
                    expression = $"{expression}.";
                    decimal_flag = 1;
                }
                return expression;
            }

            if (key == '=')
            {
                if (operator_flag != 0) return "-E-";

                decimal_flag = 0;
                decimal num = 0;
                if (expression.Length > 0) num = decimal.Parse(expression);

                if (current_key == '+') result += num;

                else if (current_key == '-') result -= num;

                else if (current_key == '*')
                {
                    number *= num;
                    result += number;
                    number = 0;
                }
                else if (num == 0) return "-E-";

                else
                {
                    number /= num;
                    result += number;
                    number = 0;
                }
                current_key = '+';
                return ("" + result);

            }

            
            return "-E-";
        }
    }
}
