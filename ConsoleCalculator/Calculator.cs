using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        Display CalculatorDisplay;
        Operator CurrentOperator;
        ResultTillNow Result;
        String CurrentNumber;
        bool IsPrevKeyAnOperator;
        public Calculator(){
            CalculatorDisplay=new Display();
            CurrentOperator=new Operator();
            Result=new ResultTillNow();
            CurrentNumber="0";
            IsPrevKeyAnOperator=false;
        }
        public string SendKeyPress(char key)
        {
            switch(key){
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    NumberPressed(key);
                break;
                case '+':
                case '-':
                case 'x':
                case 'X':
                case '/':
                    OperatorPressed(key);
                break;
                case 's':
                case 'S':
                    Toggle();
                break;
                case 'c':
                case 'C':
                    Reset();
                break;
                case '.':
                    DecimalAdded();
                break;
                case '=':
                    EqualPressed();
                break;
                default:
                    //do nothing
                break;
            }
            return CalculatorDisplay.ShowOutput();
        }
        public void NumberPressed(char number){
            if(CurrentNumber.Equals("0")){
                CurrentNumber=number+"";
            }
            else{
                CurrentNumber=CurrentNumber+number;
            }
            CalculatorDisplay.SetOutput(CurrentNumber);
            IsPrevKeyAnOperator=false;
        }
        public void OperatorPressed(char currentOperator){
            if(IsPrevKeyAnOperator)
                CurrentOperator.SetOperator(currentOperator);
            else{
                Result.Operate(CurrentOperator.GetOperator(),CalculatorDisplay.ShowOutput());
                CalculatorDisplay.SetOutput(Result.GetValue());
                CurrentNumber="0";
                CurrentOperator.SetOperator(currentOperator);
            }
            IsPrevKeyAnOperator=true;
        }
        public void Toggle(){
            String currDisplay=CalculatorDisplay.ShowOutput();
            if(!currDisplay.Contains("-"))
                currDisplay="-"+currDisplay;
            else
                currDisplay=currDisplay.Substring(1);
            CalculatorDisplay.SetOutput(currDisplay);
            CurrentNumber=currDisplay;
            IsPrevKeyAnOperator=false;
        }
        public void Reset(){
            CalculatorDisplay=new Display();
            CurrentOperator=new Operator();
            Result=new ResultTillNow();
            CurrentNumber="0";
            IsPrevKeyAnOperator=false;
        }
        public void DecimalAdded(){
            if(!CurrentNumber.Contains(".")){
                CurrentNumber=CurrentNumber+".";
                CalculatorDisplay.SetOutput(CurrentNumber);
            }
            IsPrevKeyAnOperator=false;
        }
        public void EqualPressed(){
            Result.Operate(CurrentOperator.GetOperator(),CalculatorDisplay.ShowOutput());
            CalculatorDisplay.SetOutput(Result.GetValue());
            CurrentNumber="0";
            CurrentOperator.SetOperator(' ');
            IsPrevKeyAnOperator=false;
        }
    }
}
