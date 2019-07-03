using System;
using Operation;
namespace ConsoleCalculator
{
    public class Calculator
    {
        public static string output = null,tempOutput=null;
        public static char operator1 = '%',operator2='%';
        public static double operand1 = 0, operand2 = 0;
        public string SendKeyPress(char key)
        {
            CheckKeys obj = null;
            if(Operations.IsNumber(key))
            {
                obj = new Number();
            }
            if(Operations.IsOperator(key))
            {
                obj = new Operator();
            }
            if(Operations.IsEqual(key))
            {
                obj = new Equal();
            }
            if(Operations.IsClear(key))
            {
                obj = new Clear();
            }
            if(Operations.IsToggle(key))
            {
                obj = new Toggle();
            }
            if (Operations.IsDot(key))
            {
                obj = new Dot();
            }
            if (obj != null)
            {
                return obj.SelectKeys(key);
            }
            return "0";
        }
       
    }
}
