using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private List<Char> _allowedOperators = new List<char>
        {
             '-', '+', 'x','X', '/', 's', 'S','c','C'
        };

        //_firstNumber will also contain the result
        private string _firstNumber = "";
        private string _secondNumber = "";
        private char? _operation = null;
        // _operatorPressed = 0 means we are still making changes to first number
        // _operatorPressed = 1 means we are making changes to second number
        // _operatorPressed = 2 means we have staged operation to be performed, i.e. , we are performing something like 10+20+30+... 
        private int _operatorPressed = 0;
        //bool to note whether first digit contains a decimal point
        private bool _decimalInFirstNumber = false;
        //bool to note whether second digit contains a decimal point
        private bool _decimalInSecondNumber = false;
        public string SendKeyPress(char key)
        {            
            if (IsValid(key))
            {
                if (char.IsDigit(key))
                {
                    if (_operatorPressed == 0 )
                    {
                        if (!(_firstNumber.Equals("0") && key=='0'))
                        {
                            _firstNumber += key;
                        }                               
                    }
                    else
                    {
                        if (!(_secondNumber.Equals("0") && key == '0'))
                        {
                            _secondNumber += key;
                        }
                        
                        return _secondNumber;
                    }
                    
                }
                else if (key.Equals('.'))
                {
                    if (_operatorPressed == 0 && _decimalInFirstNumber==false)
                    {
                        if (_firstNumber.Length == 0)
                        {
                            _firstNumber = "0.";
                        }
                        else
                        {
                            _firstNumber += ".";
                        }
                        _decimalInFirstNumber = true;
                    }
                    else if (_operatorPressed == 1 && _decimalInSecondNumber == false)
                    {
                        if (_secondNumber.Length == 0)
                        {
                            _secondNumber = "0.";
                        }
                        else
                        {
                            _secondNumber += ".";
                        }
                        _decimalInSecondNumber = true;
                    }
                }
                else if (key == 's' || key == 'S')
                {
                    if (_operatorPressed >= 1)
                    {
                        //toggling sign of second number in case of 's' operator was pressed
                        _secondNumber = (-double.Parse(_secondNumber)).ToString();
                    }
                    else
                    {
                        //toggling sign of first number
                        _firstNumber = (-double.Parse(_firstNumber)).ToString();
                    }
                }
                else if (key == 'c' || key == 'C')
                {
                    _firstNumber = "0";
                    _secondNumber = "";
                    _operation = null;
                    _operatorPressed = 0;
                    _decimalInFirstNumber = _decimalInSecondNumber = false;
                }
                else if (key.Equals('='))
                {
                    ComputeResult();
                    _operatorPressed -= 1;
                }
                else if (_allowedOperators.Contains(key))
                {
                    _operatorPressed += 1;
                    //compute previous if any 
                    //i.e. in case of 10+20+
                    if (_operatorPressed == 2)
                    {
                        ComputeResult();
                        _secondNumber = "";
                        _operatorPressed -= 1;
                    }                   
                    _operation = key;    
                }
                return _firstNumber;
            }
            else
            {
                return _firstNumber;
            }
        }

        private void ComputeResult()
        {
            switch (_operation)
            {
                case '+':
                    _firstNumber = (double.Parse(_firstNumber) + double.Parse(_secondNumber)).ToString();
                    break;
                case '-':
                    _firstNumber = (double.Parse(_firstNumber) - double.Parse(_secondNumber)).ToString();
                    break;
                case 'x':
                case 'X':
                    _firstNumber = (double.Parse(_firstNumber) * double.Parse(_secondNumber)).ToString();
                    break;
                case '/':
                    try
                    {
                        _firstNumber = (double.Parse(_firstNumber) / double.Parse(_secondNumber)).ToString();
                        if (_firstNumber.Equals((1.0/0).ToString()))
                        {
                            //_firstNumber = "-E-";
                            // this was done because double division does not throw divide by zero exception
                            throw new DivideByZeroException();
                        }
                    }
                    catch (DivideByZeroException)
                    {
                        _firstNumber = "-E-";
                    }
                    break;
            }         
        }

        private bool IsValid(char key)
        {
            if(char.IsDigit(key) || _allowedOperators.Contains(key) || key == '.' || key.Equals('='))
            {
                return true;
            }
            return false;
        }
    }
}
