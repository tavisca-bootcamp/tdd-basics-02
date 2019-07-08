using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        Display CalculatorDisplay;
        Operator CurrentOperator;
        ResultTillNow Result;
        String CurrentNumber;

        public Calculator(){
            CalculatorDisplay=new Display();
            CurrentOperator=new Operator();
            Result=new ResultTillNow();
            CurrentNumber="0";
        }
        public string SendKeyPress(char key)
        {
            //todo
            throw new NotImplementedException();
        }
    }
}
