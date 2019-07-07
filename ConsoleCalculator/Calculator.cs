using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string _firstNumber = "";
        private string _secondNumber = "";
        private string operation = "";

        public string SendKeyPress(char key)
        {
            switch (key)
            {
                case 'C':
                case 'c':
                    clearSceen();
                    return "0";
                case '.':
                case 'S':
                case 's':
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
                    return Getnumber(key);

                case '+':
                case '-':
                case 'x':
                case '/':
                    SetOperator(key);
                    break;

                case '=':
                    if (operation != "")
                    {
                        string previousOperation = operation;
                        operation = "";
                        return DoCalculation(previousOperation);
                    }
                    break;
                default:
                    return "";
            }
            return _firstNumber;
        }

        private void clearSceen()
        {
            _firstNumber = "";
            _secondNumber = "";
            operation = "";
        }

        private void SetOperator(char key)
        {
            if (operation == "" && _firstNumber != "")
            {
                operation = key.ToString();
            }
            else
            {
                DoCalculation(operation);
                operation = key.ToString();
            }
        }

        private string DoCalculation(string operation)
        {
            string answer = "";
            if (operation == "+")
            {
                try
                {
                    answer = (double.Parse(_firstNumber) + double.Parse(_secondNumber)).ToString();
                    _secondNumber = "";
                    _firstNumber = answer;
                }
                catch (FormatException e)
                {
                    _secondNumber = _firstNumber;
                    return DoCalculation(operation);
                }
            }
            else if (operation == "-")
            {
                try
                {
                    answer = (double.Parse(_firstNumber) - double.Parse(_secondNumber)).ToString();
                    _secondNumber = "";
                    _firstNumber = answer;
                }
                catch (FormatException e)
                {
                    _secondNumber = _firstNumber;
                    return DoCalculation(operation);
                }
            }
            else if (operation == "/")
            {
                if (_secondNumber == "0")
                {
                    return "-E-";
                }
                else
                {
                    try
                    {
                        answer = (double.Parse(_firstNumber) / double.Parse(_secondNumber)).ToString();
                        _secondNumber = "";
                        _firstNumber = answer;
                    }
                    catch (Exception e)
                    {
                        _secondNumber = _firstNumber;
                        return DoCalculation(operation);
                    }
                }
            }
            else if (operation == "x")
            {
                try
                {
                    answer = (double.Parse(_firstNumber) * double.Parse(_secondNumber)).ToString();
                    _secondNumber = "";
                    _firstNumber = answer;
                }
                catch (Exception e)
                {
                    _secondNumber = _firstNumber;
                    return DoCalculation(operation);
                }
            }
            return answer;
        }

        private string Getnumber(char key)
        {
            if (operation == "")
            {
                
                if (key == '.')
                {
                    if (!_firstNumber.Contains("."))
                    {
                        return _firstNumber += ".";
                    }
                    else
                    {
                        return _firstNumber;
                    }
                }
                else if (!(_firstNumber == "0" && key == '0'))
                {
                    if (_firstNumber == "0")
                    {
                        _firstNumber = key.ToString();
                    }
                    else
                    {
                        _firstNumber += key.ToString();
                    }
                }
                return _firstNumber;
            }
            else
            {
                if (key == 's')
                {
                    _secondNumber = (double.Parse(_secondNumber) * -1).ToString();
                    return _secondNumber;
                }
                else if (key == '.')
                {
                    if (!_secondNumber.Contains("."))
                    {
                        return _secondNumber += ".";
                    }
                    else
                    {
                        return _secondNumber;
                    }
                }
                else if (!(_secondNumber == "0" && key == '0'))
                {
                    if (_secondNumber == "0")
                    {
                        _secondNumber = key.ToString();
                    }
                    else
                    {
                        _secondNumber += key.ToString();
                    }
                }
                return _secondNumber;
            }
        }
    }
}
