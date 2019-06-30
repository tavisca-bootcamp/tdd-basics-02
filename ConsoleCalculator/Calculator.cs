using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string operandOne = "0";
        public string operandTwo;
        public string DisplayString;
        
        public const char TOGGlES= 's';

        public const char SETZERO = 'c';
       

        public string SendKeyPress(char key)
        {
            switch(key)
            {
                case var c when Character.IsDigit(c) :
                           UpdateOperands(c);
                             break;

                case var c when Character.IsSymbol(c):
                            DoOperation(c);
                            break;

                case var c when Character.IsToggle(c):
                            Toggle();
                            break;

                case var c when Character.IsSetZero(c):
                            SetZero();
                            break;
                default://ignoring other characters and return previous displayed string
                            break;




            }
            return DisplayString;

        }

        private void SetZero()
        {
            throw new NotImplementedException();
        }

        private void Toggle()
        {
            throw new NotImplementedException();
        }

        private void DoOperation(char c)
        {
            throw new NotImplementedException();
        }

        private void UpdateOperands(char c)
        {
            throw new NotImplementedException();
        }
    }
}
