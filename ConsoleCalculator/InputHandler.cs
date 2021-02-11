using System.Linq;
namespace ConsoleCalculator
{
    public class InputHandler
    {
        private static readonly char[] validDigit={'0','1','2','3','4','5','6','7','8','9','0'};
        private static readonly char[] validOperator={'+','-','x','X','*','/','='};
        public  static bool isValidDigit(char digit){
            return validDigit.Contains(digit); 
        }
         public static bool isValidOperator(char op){
            return validOperator.Contains(op); 
        }
        public static bool isDecimalPoint(char key)
        {
            return key == '.';
        }
        public static bool isToggleKey(char key)
        {
            return key == 's'  || key == 'S' ;
        }
        public static bool isClearKey(char key)
        {
            return key == 'c' || key == 'C';
        }
    }
}