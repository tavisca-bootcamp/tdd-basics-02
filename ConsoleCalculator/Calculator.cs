using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public StringBuilder operand1 = new StringBuilder("");
        public StringBuilder operand2 = new StringBuilder("");
        public StringBuilder display = new StringBuilder("");
		public char @operator = 'z';
	    public int mode = 0;
        public List<char> listOfSymbols = new List<char>() { '-', '+', '/', '=', 'x', 'X', 'c', 'C', 's', 'S' };

        public string SendKeyPress(char key)
        {
            if(IsValidKey(key))
            {
                if (IsOperator(key))
                {
                    PerformOperation(key);
                    return display.ToString();
                }
                else if(key=='.')
                {
                    return HandleDecimal('.');
                }
                else if(key=='0')
                {
                    return HandleZero('0');
                }
                else
                {
                    PerformNumberDisplay(key);
                    return display.ToString();
                }
            }
            else
            {
                return display.ToString();
            }
        }

        private string HandleZero(char key)
        {
            if (display.Length == 1)
            {
                if (display[0] == '0')
                    return display.ToString();
            }
            PerformNumberDisplay(key);
            return display.ToString();
        }

        private string  HandleDecimal(char key)
        {
            if (display.Length == 0)
                display.Append("0.");
            else if (display[display.Length - 1] != '.')
                PerformNumberDisplay(key);
            return display.ToString();
        }

        private void PerformNumberDisplay(char key)
        {
            if(mode==1)
            {
                display.Clear();
                mode = 0;
            }
            display.Append(key);
        }

        private void PerformOperation(char key)
        {
            var arithmeticList = new List<char>() { '+', 'x', 'X', '-', '/' };
            if(arithmeticList.Contains(key))
            {
                PerformOperation('=');
                operand1.Clear();
                operand1.Append(display.ToString());
                mode = 1;
                @operator = key;
            }
            else
            {
                switch(key)
                {
                    case '=':
                        if(@operator!='z')
                        {
                            operand2.Clear();
                            operand2.Append(display.ToString());
                            PerformCalculation();
                            @operator = 'z';
                            mode = 1;
                        }
                        break;
                    case 's':
                    case 'S':
                        decimal result = decimal.Multiply(-1, decimal.Parse(display.ToString()));
                        display.Clear();
                        display.Append(result.ToString());
                        break;
                    case 'c':
                    case 'C':
                        @operator = 'z';
                        operand1.Clear();
                        operand2.Clear();
                        display.Clear();
                        display.Append('0');
                        break;
                }
            }
        }

        private void PerformCalculation()
        {
            decimal result;
            bool firstCondition = decimal.TryParse(operand1.ToString(), out decimal fNumber);
            bool secondContition =decimal.TryParse(operand2.ToString(), out decimal SNumber);
            if (firstCondition && secondContition)
            {
                result = GetResult(fNumber, SNumber);
                if(result!=decimal.MinValue)
                {
                    display.Clear();
                    if (decimal.Ceiling(result) - decimal.Floor(result) == 0)
                    {
                        display.Append(decimal.ToInt32(result).ToString());
                    }
                    else
                        display.Append(result.ToString());
                }
            }
            else
            {
                display.Clear();
                display.Append("-E-");
            }

        }

        private decimal GetResult(decimal fNumber, decimal sNumber)
        {
            decimal result=decimal.MinValue;
            switch(@operator)
            {
                case '+':
                    result = fNumber + sNumber;
                    break;
                case '-':
                    result = fNumber - sNumber;
                    break;
                case 'x':
                case 'X':
                    result = fNumber * sNumber;
                    break;
                case '/':
                    try
                    {
                        result = fNumber / sNumber;
                    }
                    catch (DivideByZeroException)
                    {
                        display.Clear();
                        display.Append("-E-");
                    }
                    break;
            }
            return result;
        }

        private bool IsValidKey(char key)
        {
            if (char.IsDigit(key))
                return true;
            else if (IsOperator(key)||key=='.')
                return true;
            else
                return false;
        }

        private bool IsOperator(char key)
        {
            
            if (listOfSymbols.Contains(key))
                return true;
            else
                return false;
        }
    }
}
