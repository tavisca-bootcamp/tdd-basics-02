using System;
using System.Data;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string expression = "";
        private string number = "0";
        private string consoleDisplay = "0";
        private DataTable dt = new DataTable();
        CheckInputType CIT = new CheckInputType();

        public string SendKeyPress(char key)
        {
            return display(key);
        }

        private string display(char key)
        {
            if (CIT.isClear(key))
            {
                number = consoleDisplay = "0";
                expression = "";
            }
            else if (CIT.isOperator(key))
            {
                consoleDisplay = addConsoleValueToExp(expression, consoleDisplay);
                expression = consoleDisplay + key;
                number = "0";
            }
            else if (CIT.isNumber(key))
            {
                number = evaluateExpression(number + key);
                consoleDisplay = number;
            }
            else if (CIT.isDecimalValid(key, number))
            {
                number += '.';
                consoleDisplay = number;
            }
            else if (CIT.isSignChange(key))
            {
                number = invertingTheNumber(consoleDisplay);
                consoleDisplay = number;
            }
            else if (key == '=')
            {
                consoleDisplay = addConsoleValueToExp(expression, consoleDisplay); ;
                expression = "";
            }
            if (consoleDisplay == "∞")
            {
                consoleDisplay = "-E-";
            }
            return consoleDisplay;
        }

        private string addConsoleValueToExp(string expression, string consoleDisplay)
        {
            return evaluateExpression(expression + consoleDisplay);
        }

        private string invertingTheNumber(string consoleDisplay)
        {
            float a = -float.Parse(consoleDisplay);
            return Convert.ToString(a);
        }

        private string evaluateExpression(string expression)
        {
            expression = replaceXByMultOp(expression);
            var exp = Convert.ToString(dt.Compute(expression, ""));
            return exp;
        }

        private string replaceXByMultOp(string expression)
        {
            expression = expression.Replace('x', '*');
            expression = expression.Replace('X', '*');
            return expression;
        }
    }
}
