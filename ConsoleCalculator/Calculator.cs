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
            //todo
        }
        public void OperatorPressed(char number){
            //todo
        }
        public void Toggle(){
            //todo
        }
        public void Reset(){
            //todo
        }
        public void DecimalAdded(){
            //todo
        }
        public void EqualPressed(){
            //todo
        }
    }
}
