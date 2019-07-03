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
        private int _operatorPressed = 0;
        private bool _decimalFirst = false;
        private bool _decimalSecond = false;
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
                        if (!(_secondNumber.Equals("0")&&key=='0'))
                        {
                            _secondNumber += key;
                        }
                        
                        return _secondNumber;
                    }
                    
                }
                else if (key.Equals('.'))
                {
                    if (_operatorPressed == 0 && _decimalFirst==false)
                    {
                        if (_firstNumber.Length == 0)
                        {
                            _firstNumber = "0.";
                        }
                        else
                        {
                            _firstNumber += ".";
                        }
                        _decimalFirst = true;
                    }
                    else if (_operatorPressed == 1 && _decimalSecond == false)
                    {
                        if (_secondNumber.Length == 0)
                        {
                            _secondNumber = "0.";
                        }
                        else
                        {
                            _secondNumber += ".";
                        }
                        _decimalSecond = true;
                    }
                }
                else if (key == 's' || key == 'S')
                {
                    if (_operatorPressed == 1)
                    {
                        _secondNumber = (-double.Parse(_secondNumber)).ToString();
                    }
                    else
                    {
                        _firstNumber = (-double.Parse(_firstNumber)).ToString();
                    }
                }
                else if (key == 'c' || key == 'C')
                {
                    _firstNumber = "0";
                    _secondNumber = "";
                    _operation = null;
                    _operatorPressed = 0;
                    _decimalFirst = _decimalSecond = false;
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
            if(char.IsDigit(key) || _allowedOperators.Contains(key)|| key=='.'|| key.Equals('='))
            {
                return true;
            }
            return false;
        }
    }
}
