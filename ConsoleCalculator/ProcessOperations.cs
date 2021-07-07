using System;
using System.Data;

namespace ConsoleCalculator
{
    public class ProcessOperations
    {
        private string Expression = "";
        private string Operand = "";
        private string ConsoleDisplay = "";
        private DataTable dataTable = new DataTable();
       public string ProcessResult(char key)
        {
            if(key=='c'|| key == 'C')
            {
                ConsoleDisplay = "0";
                Expression = Operand = "";
            }
            else if(isOperator(key))
            {
                Expression += ConsoleDisplay;
                Operand = "";
                Expression = ConsoleDisplay = ComputeResult(Expression);
                Expression += key;
            }
            else if(Char.IsDigit(key))
            {
                Operand = ComputeResult(Operand += key);
                ConsoleDisplay = Operand;
            }
            else if(key=='.' && !ConsoleDisplay.Contains("."))
            {
                Operand += key;
                ConsoleDisplay = Operand;
            }
            else if(key=='S'||key=='s')
            {
                Operand= -double.Parse(Operand)+"";
                ConsoleDisplay = Operand;
            }
            else if (key=='=')
            {
                if (Operand=="")
                {
                    string c = Expression.Substring(0, Expression.Length - 1);
                    Expression = Expression + c;
                }
                else
                {
                    Expression += Operand;
                }
                ConsoleDisplay = ComputeResult(Expression);
            }
            if(ConsoleDisplay== "Infinity")
            {
                ConsoleDisplay = "-E-";
            }
            return ConsoleDisplay;
        }
        public string ComputeResult(string Expression)
        {
            Expression = Expression.Replace('x', '*');
            Expression = Expression.Replace('X', '*');
            var exp = dataTable.Compute(Expression, "");
            return exp+"";
        }

        private bool isOperator(char key)
        {
            return (key == '+' || key == '-' || key == 'X'
                    || key == 'x' || key == '/');
        }
    }
}