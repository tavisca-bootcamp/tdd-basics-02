using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleCalculator
{
    public class Calculator
    {
        StringBuilder firstNumber = new StringBuilder(String.Empty);
        StringBuilder secondNumber = new StringBuilder(String.Empty);
        StringBuilder answer = new StringBuilder(String.Empty);
        int flag = 0;
        char _operator = 'z';
        List<char> OperatorList = new List<char>() { 'x', 'X', 'c', 'C', 's', 'S', '-', '+', '/', '='};
        public string SendKeyPress(char key)
        {
            if (IsValidKey(key))
            {
                if (IsOperator(key))
                {
                    PerformArithmeticOperation(key);
                }
                else if (key == '.')
                {
                    HandleDecimal('.');
                }
                else if (key == '0')
                {
                    HandleZero('0');
                }
                else
                {
                    Display(key);
                }
            }
            return answer.ToString();
        }
        private bool IsValidKey(char key)
        {
            if (char.IsDigit(key))
                return true;
            else if (IsOperator(key) || key == '.')
                return true;
            else
                return false;
        }
        private bool IsOperator(char key)
        {
            if (OperatorList.Contains(key))
                return true;
            else
                return false;
        }
        private void PerformArithmeticOperation(char key)
        {
            var OperatorList = new List<char>() { '+', '-', '/', 'x', 'X' };
            if (OperatorList.Contains(key))
            {
                PerformArithmeticOperation('=');
                firstNumber.Clear();
                firstNumber.Append(answer.ToString());
                flag = 1;
                _operator = key;
            }
            else
            {
                switch (key)
                {
                    case '=':
                        if (_operator != 'z')
                        {
                            secondNumber.Clear();
                            secondNumber.Append(answer.ToString());
                            PerformCalculation();
                            _operator = 'z';
                            flag = 1;
                        }
                        break;
                    case 's':
                    case 'S':
                        decimal result = decimal.Multiply(-1, decimal.Parse(answer.ToString()));
                        answer.Clear();
                        answer.Append(result.ToString());
                        break;
                    case 'c':
                    case 'C':
                        ClearDisplay();
                        break;
                }
            }
        }
        private void PerformCalculation()
        {
            decimal result;
            bool firstCondition = decimal.TryParse(firstNumber.ToString(), out decimal fNumber);
            bool secondContition = decimal.TryParse(secondNumber.ToString(), out decimal SNumber);
            if (firstCondition && secondContition)
            {
                result = GetResult(fNumber, SNumber);
                if (result != decimal.MinValue)
                {
                    answer.Clear();
                    if (decimal.Ceiling(result) - decimal.Floor(result) == 0)
                    {
                        answer.Append(decimal.ToInt32(result).ToString());
                    }
                    else
                        answer.Append(result.ToString());
                }
            }
            else
            {
                answer.Clear();
                answer.Append("-E-");
            }
        }
        private decimal GetResult(decimal fNumber, decimal sNumber)
        {
            decimal result = decimal.MinValue;
            switch (_operator)
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
                        answer.Clear();
                        answer.Append("-E-");
                        answer.Append("-E-");
                    }
                    break;
            }
            return result;
        }
        private void ClearDisplay()
        {
            _operator = 'z';
            firstNumber.Clear();
            secondNumber.Clear();
            answer.Clear();
            answer.Append('0');
        }
        private void HandleDecimal(char key)
        {
            if (answer.Length == 0 || answer.ToString().Equals("0"))
            {
                answer.Clear();
                answer.Append("0.");
            }
            else if (answer[answer.Length - 1] != '.')
            {
                Display(key);
            }
        }
        private void HandleZero(char key)
        {
            if (answer.Length == 1)
            {
                if (answer[0] == '0')
                    return;
            }
            Display(key);
        }
        private void Display(char key)
        {
            if (flag == 1)
            {
                answer.Clear();
                flag = 0;
            }
            if (answer.ToString().Equals("0"))
                answer.Clear();
            answer.Append(key);
        }    
    }
}
