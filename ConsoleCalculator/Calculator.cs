using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Calculator
    {

        public StringBuilder FirstNumber = new StringBuilder("");
        public StringBuilder SecondNumber = new StringBuilder("");
        public StringBuilder Display = new StringBuilder("");

        public int mode = 0;
        public char Operator = 'z';
        public List<char> SymbolList = 
            new List<char>() {'-','+','x','X','/','s','S','c','C','='};
        
        public string SendKeyPress(char Key)
        {
            if (IsValidKey(Key))
            {
                if (IsOperator(Key))
                {
                    PerformOperation(Key);
                    return Display.ToString();
                }
                else if(Key=='0')
                {
                    return HandleZero(Key);
                }
                else if (Key == '.')
                {
                    return HandleDecimal(Key);
                }    
                else
                {
                    PerformNumberDisplay(Key);
                    return Display.ToString();
                }
            }
            else
            {
                return Display.ToString();
            }
        }

        string HandleZero(char Key)
        {
            if(Display.Length == 1)
            {
                if (Display[0] == '0') return Display.ToString();
            }
            PerformNumberDisplay(Key);
            return Display.ToString();
        }

        string HandleDecimal(char Key)
        {
            if (Display.Length == 0)
            {
                Display.Append("0.");
            }
            else if (Display[Display.Length - 1] != '.') PerformNumberDisplay(Key);
            return Display.ToString();
        }

        bool IsValidKey(char Key)
        {
            if (char.IsDigit(Key)) return true;
            else if (IsOperator(Key) || Key == '.') return true;
            else return false;
        }

        bool IsOperator(char Key)
        {
            return SymbolList.Contains(Key);
        }

        void PerformNumberDisplay(char Key)
        {
            if (mode == 1)
            {
                Display.Clear();
                mode = 0;
            }
            Display.Append(Key);
        }

        void PerformOperation(char Key)
        {
            List<char> ArithmeticList = new List<char>() { '-','+','x','X','/'};
            if (ArithmeticList.Contains(Key))
            {
                PerformOperation('=');  // this line of code is useful for AggregateCalculationTest
                FirstNumber.Clear();
                FirstNumber.Append(Display.ToString());
                mode = 1;
                Operator = Key;
            }
            else
            {
                switch (Key)
                {
                    case '=':
                        if (Operator != 'z')
                        {
                            SecondNumber.Clear();
                            SecondNumber.Append(Display.ToString());
                            PerformCalculation();
                            Operator = 'z';
                            mode = 1;
                        }
                        break;
                    case 's':
                    case 'S':
                        decimal Result = decimal.Multiply(-1, decimal.Parse(Display.ToString()));
                        Display.Clear();
                        Display.Append(Result.ToString());
                        break;
                    case 'c':
                    case 'C':
                        Operator = 'z';
                        FirstNumber.Clear();
                        SecondNumber.Clear();
                        Display.Clear();
                        Display.Append('0');
                        break;

                }
            }
        }

        void PerformCalculation()
        {
            decimal Result;
            bool FirstCondition = decimal.TryParse(FirstNumber.ToString(), out decimal FNumber);
            bool SecondCondition = decimal.TryParse(SecondNumber.ToString(), out decimal SNumber);

            if (FirstCondition && SecondCondition)
            {
                Result = GetResult(FNumber, SNumber);
                if(Result != decimal.MinValue)
                {
                    Display.Clear();
                    Display.Append(Result.ToString());
                }
            }
            else
            {
                Display.Clear();
                Display.Append("-E-");
            }
        }

        decimal GetResult(decimal FirstNumber, decimal SecondNumber)
        {
            decimal result = decimal.MinValue;
            switch (Operator)
            {
                case '+': result = FirstNumber + SecondNumber; break;
                case '-': result = FirstNumber - SecondNumber; break;
                case 'x':
                case 'X': result = FirstNumber * SecondNumber; break;
                case '/':
                    try
                    {
                        result = FirstNumber / SecondNumber;
                    }
                    catch (DivideByZeroException)
                    {
                        Display.Clear();
                        Display.Append("-E-");
                    }
                    break;
            }
            return result;
        }
    }
}
