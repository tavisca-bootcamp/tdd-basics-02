using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string _inputNumber = "";
        private double _operandFirst = 0;
        private double _operandSecond = 0;
        private char _operator = '+';
        private bool _isDecimalEncountered = false;

        public string SendKeyPress(char key)
        {
            string result = "0";

            try
            {
                if (key.ToString().ToUpper() == "C")
                {
                    reset();
                }
                else if (key.ToString().ToUpper() == "S")
                {
                    result = toggleSign();
                }
                else if (key == '.' && !_isDecimalEncountered)
                {
                    _inputNumber = _inputNumber + key;
                    _isDecimalEncountered = true;

                    result = _inputNumber;
                }
                else if (isDigit(key))
                {
                    if (key == '0' && !_isDecimalEncountered)
                        _inputNumber = Int32.Parse(_inputNumber + key).ToString();      // 000 => 0
                    else
                        _inputNumber = _inputNumber + key;
                    
                    _operandSecond = Double.Parse(_inputNumber);

                    result = _inputNumber;
                }
                else if (isOperator(key))
                {
                    _isDecimalEncountered = false;   
                    performPreviousOperation();
                    result = _operandFirst.ToString();

                    if (key != '=')
                        _operator = key;
                    
                    _inputNumber = "";
                    _operandSecond = 0;
                }

            }
            catch (DivideByZeroException)
            {
                result = "-E-";
            }

            return result;
        }

        private bool isDigit(char key)
        {
            return (key <= '9' && key >= '0') ? true : false;
        }

        private bool isOperator(char key)
        {
            return (key == '+' || key == '-' || key == 'x' || key == 'X' || key == '/' || key == '=') ? true : false;
        }

        private void reset()
        {
            _operator = '+';
            _inputNumber = "";
            _operandFirst = 0;
            _operandSecond = 0;
            _isDecimalEncountered = false;
        }

        private string toggleSign()
        {
            _operandSecond = - _operandSecond;

            return _operandSecond.ToString();
        }

        private void performPreviousOperation()
        {
            switch (_operator)
            {
                case '+':
                    _operandFirst = _operandFirst + _operandSecond;
                    break;

                case '-':
                    _operandFirst = _operandFirst - _operandSecond;
                    break;

                case '/':
                    if (_operandSecond == 0)
                        throw new DivideByZeroException();
                    _operandFirst = _operandFirst / _operandSecond;
                    break;

                case 'x':
                case 'X':
                    _operandFirst = _operandFirst * _operandSecond;
                    break;
            }
        }
    }
}
