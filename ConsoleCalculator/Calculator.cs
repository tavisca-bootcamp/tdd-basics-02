using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        CalculatorLogic CalculatorLogic = new CalculatorLogic();
        public string SendKeyPress(char key)
        {
            if (CalculatorLogic.IsResetKey(key))
            {
                CalculatorLogic = new CalculatorLogic();
                return "0";
            }
            else if (CalculatorLogic.isKeyZero(key))
            {
                if (!CalculatorLogic.DisplayValue.Equals("0"))
                    CalculatorLogic.DisplayValue += key;
                return CalculatorLogic.DisplayValue;
            }
            else if (CalculatorLogic.IsNumber(key))
            {
                CalculatorLogic.DisplayValue += key;
                return CalculatorLogic.DisplayValue;
            }
            else if (CalculatorLogic.IsNegativeNumber(key))
            {
                int signedValue;
                if (int.TryParse(CalculatorLogic.DisplayValue, out signedValue))
                    CalculatorLogic.DisplayValue = (-signedValue).ToString();
                else
                    CalculatorLogic.DisplayValue = (-float.Parse(CalculatorLogic.DisplayValue)).ToString();
                return CalculatorLogic.DisplayValue;
            }
            else if (CalculatorLogic.IsDecimalPoint(key))
            {
                int temp;
                if (int.TryParse(CalculatorLogic.DisplayValue, out temp))
                    CalculatorLogic.DisplayValue += key;
                return CalculatorLogic.DisplayValue;
            }
            else if (CalculatorLogic.IsArithmeticOperator(key))
            {
                if (CalculatorLogic.Flag == 0 && CalculatorLogic.Operator != '?')
                {
                    if (!SetFlagAndPreviousOperator(key))
                        return "-E-";
                }
                else
                {
                    if (CalculatorLogic.calculateResult(key) == "-E-")
                        return "-E-";
    
                }
                return CalculatorLogic.Result.ToString();
            }
            else if (CalculatorLogic.IsEqualOperator(key))
            {
                if (CalculatorLogic.DisplayValue == "")
                    CalculatorLogic.DisplayValue = CalculatorLogic.Result.ToString();
                return SendKeyPress(CalculatorLogic.Operator);
            }
            else
                return CalculatorLogic.DisplayValue;
            //throw new NotImplementedException();
        }

        private bool SetFlagAndPreviousOperator(char key)
        {
            bool temp = true;
            CalculatorLogic.Flag = 1;
            if (SendKeyPress(CalculatorLogic.Operator)=="-E-")
                return false;
            CalculatorLogic.Operator = key;
            return temp;

        }
    }
}