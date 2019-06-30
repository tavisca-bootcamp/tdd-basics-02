using System;
using System.Data;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string expression = "";
        private string number = "";
        private string consoleDisplay = "";
        private DataTable dt = new DataTable();

        public string SendKeyPress(char key)
        {
            return display(key);
        }

        private string display(char key)
        {
            if(key=='c')
            {
                consoleDisplay = "0";
                expression = number = "";
            }
            else if(isOperator(key))
            {
                expression += consoleDisplay;
                number = "";
                expression = consoleDisplay = evaluateExpression(expression);
                expression += key;
            }
            else if(isNumber(key))
            {
                number = evaluateExpression(number += key);
                consoleDisplay = number;
            }
            else if(key=='.' && !consoleDisplay.Contains("."))
            {
                number += key;
                consoleDisplay = number;
            }
            else if(key=='S'||key=='s')
            {
                number= -float.Parse(number)+"";
                consoleDisplay = number;
            }
            else if (key=='=')
            {
                if (number=="")
                {
                    string c = expression.Substring(0, expression.Length - 1);
                    expression = expression + c;
                }
                else
                {
                    expression += number;
                }
                consoleDisplay = evaluateExpression(expression);
            }
            if(consoleDisplay== "∞")
            {
                consoleDisplay = "-E-";
            }
            return consoleDisplay;
        }

        private string evaluateExpression(string expression)
        {
            expression = expression.Replace('x', '*');
            expression = expression.Replace('X', '*');
            var exp = dt.Compute(expression, "");
            return exp+"";
        }

        private bool isNumber(char key)
        {
            if(Char.IsDigit(key))
            {
                return true;
            }
            return false;
        }

        private bool isOperator(char key)
        {
            if(key=='+'|| key == '-' || key == 'x' || key == 'X' || key == '/')
            {
                return true;
            }
            return false;
        }
    }
}
