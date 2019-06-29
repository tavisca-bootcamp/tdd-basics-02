using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        CalculatorUtility calculatorUtility = new CalculatorUtility();

        public double _firstNumber = 0;
        public double _secondNumber = 0;
        public string _integer = "";
        public char _operator;
        public string _result = "";
        public int _operatorCount = 0;
        public bool _isDecimalPointUsed = false;
        public string SendKeyPress(char key)
        {
            if (calculatorUtility.IsResetKey(key))
            {
                _integer = "";
                _firstNumber = 0;
                _secondNumber = 0;
                _operatorCount = 0;
                _isDecimalPointUsed = false;
                _result = "";
            }
            else if (calculatorUtility.IsNumber(key) || calculatorUtility.IsDecimalPoint(key))
            {
                
                if (_isDecimalPointUsed)
                {
                    if (!calculatorUtility.IsDecimalPoint(key))
                        _integer += key;
                }
                else
                    _integer += key;
                if (calculatorUtility.IsDecimalPoint(key))
                    _isDecimalPointUsed = true;
                _result = _integer;
            }
            else if (calculatorUtility.IsNegativeInteger(key))
            {
                _integer = (-double.Parse(_integer)).ToString();
                _result = _integer;
            }
            else if (calculatorUtility.IsArithmeticOperator(key))
            {
                if (_operatorCount >= 1)
                {
                    _operatorCount++;
                    _secondNumber = double.Parse(_integer);
                    if (calculatorUtility.IsAdd(_operator))
                        _result = calculatorUtility.Add(_firstNumber, _secondNumber);
                    else if (calculatorUtility.IsSubstract(_operator))
                        _result = calculatorUtility.Substract(_firstNumber, _secondNumber);
                    else if (calculatorUtility.IsMultiply(_operator))
                        _result = calculatorUtility.Multiply(_firstNumber, _secondNumber);
                    else if (calculatorUtility.IsDivide(_operator))
                    { 
                        if (_secondNumber == 0)
                            return "-E-";
                        _result = calculatorUtility.Divide(_firstNumber, _secondNumber);
                    }
                    _isDecimalPointUsed = false;
                    _integer = "";
                    _firstNumber = double.Parse(_result);
                }
                else if (!calculatorUtility.IsEqualOperator(key))
                {
                    //_integer = "";
                    _operator = key;
                }
                if (!calculatorUtility.IsEqualOperator(key) && _operatorCount < 1)
                {
                    _operatorCount++;
                    _firstNumber = double.Parse(_integer);
                    _result = _integer;
                    _isDecimalPointUsed = false;
                    _integer = "";

                    return _result;
                }
                
            }
            return _result;
            //throw new NotImplementedException();
        }


    }
}
