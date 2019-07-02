using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string _firstNumberBuffer = String.Empty;
        private string _secondNumberBuffer = String.Empty;
        private string _displayBuffer = String.Empty;
        private int _calculationMode = 0;
        private char _operator = 'z';
        private List<char> _symbolList = new List<char>() { '-', '+', '/', '=', 'x', 'X', 'c', 'C', 's', 'S' };

        public string SendKeyPress(char key)
        {
            if(IsValidKey(key))
            {
                if (IsOperator(key))
                {
                    PerformArithmeticOperation(key);
                }
                else
                {
                    switch(key)
                    {
                        case '.':
                            HandleDecimalDigit('.');
                            break;
                        case '0':
                            HandleZeroKey('0');
                            break;
                        default:
                            Display(key);
                            break;
                    }
                }
            }
            return _displayBuffer;
        }

        private void HandleZeroKey(char key)
        {
            if (_displayBuffer.Length == 1)
            {
                if (_displayBuffer[0] == '0')
                    return;
            }
            Display(key);
        }

        private void HandleDecimalDigit(char key)
        {
            if (_displayBuffer.Length == 0||_displayBuffer.Equals("0"))
            {
                _displayBuffer = "0.";
            }
            else if (_displayBuffer[_displayBuffer.Length - 1] != '.')
            {
                Display(key);
            }
        }

        private void Display(char key)
        {
            if(_calculationMode==1||_displayBuffer.Equals("0"))
            {
                _displayBuffer = String.Empty;
                _calculationMode = 0;
            }
            _displayBuffer += key.ToString();
        }

        private void PerformArithmeticOperation(char key)
        {
            var arithmeticList = new List<char>() { '+', 'x', 'X', '-', '/' };
            if(arithmeticList.Contains(key))
            {
                PerformArithmeticOperation('=');
                _firstNumberBuffer = _displayBuffer;
                _calculationMode = 1;
                _operator = key;
            }
            else
            {
                switch(key)
                {
                    case '=':
                        if(_operator!='z')
                        {
                            _secondNumberBuffer = _displayBuffer;
                            PerformCalculation();
                            _operator = 'z';
                            _calculationMode = 1;
                        }
                        break;
                    case 's':
                    case 'S':
                        decimal result = decimal.Multiply(-1, decimal.Parse(_displayBuffer));
                        _displayBuffer = result.ToString();
                        break;
                    case 'c':
                    case 'C':
                        ClearDisplay();
                        break;
                }
            }
        }

        private void ClearDisplay()
        {
            _operator = 'z';
            _firstNumberBuffer = String.Empty;
            _secondNumberBuffer = String.Empty;
            _displayBuffer = "0";
        }

        private void PerformCalculation()
        {
            decimal result;
            bool firstCondition = decimal.TryParse(_firstNumberBuffer, out decimal firstNumber);
            bool secondContition =decimal.TryParse(_secondNumberBuffer, out decimal secondNumber);
            if (firstCondition && secondContition)
            {
                result = GetResult(firstNumber, secondNumber);
                if(result!=decimal.MinValue)
                {
                    _displayBuffer = String.Empty;
                    if (decimal.Ceiling(result) - decimal.Floor(result) == 0)
                    {
                        _displayBuffer = decimal.ToInt32(result).ToString();
                    }
                    else
                        _displayBuffer = result.ToString();
                }
            }
            else
            {
                _displayBuffer = "-E-";
            }
        }

        private decimal GetResult(decimal firstNumber, decimal secondNumber)
        {
            decimal result=decimal.MinValue;
            switch(_operator)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
                case 'x':
                case 'X':
                    result = firstNumber * secondNumber;
                    break;
                case '/':
                    try
                    {
                        result = firstNumber / secondNumber;
                    }
                    catch (DivideByZeroException)
                    {
                        _displayBuffer = "-E-";
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
            
            if (_symbolList.Contains(key))
                return true;
            else
                return false;
        }
    }
}