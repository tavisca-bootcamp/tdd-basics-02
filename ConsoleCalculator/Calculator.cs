using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        CalculatorUtility calculatorUtility = new CalculatorUtility();

        
        public string SendKeyPress(char key)
        {
            if (calculatorUtility.IsResetKey(key))
            {
                calculatorUtility = new CalculatorUtility();
                return "0";
            }
            else if (calculatorUtility.isKeyZero(key))
            {
                if (!calculatorUtility.Number.Equals("0"))
                    calculatorUtility.Number += key;
                return calculatorUtility.Number;
            }
            else if (calculatorUtility.IsNumber(key))
            {
                calculatorUtility.Number += key;
                return calculatorUtility.Number;
            }
            else if (calculatorUtility.IsNegativeNumber(key))
            {
                int temp;
                if (int.TryParse(calculatorUtility.Number, out temp))
                    calculatorUtility.Number = (-temp).ToString();
                else
                    calculatorUtility.Number = (-float.Parse(calculatorUtility.Number)).ToString();
                return calculatorUtility.Number;
            }
            else if (calculatorUtility.IsDecimalPoint(key))
            {
                int temp;
                if (int.TryParse(calculatorUtility.Number, out temp))
                    calculatorUtility.Number += key;
                return calculatorUtility.Number;
            }
            else if (calculatorUtility.IsArithmeticOperator(key))
            {
                if (calculatorUtility.Flag == 0 && calculatorUtility.PreviousOperator != '?')
                {
                    if (!SetFlagAndPreviousOperator(key))
                        return "-E-";
                }
                else
                {
                    if (calculatorUtility.calculateResult(key) == "-E-")
                        return "-E-";
    
                }
                return calculatorUtility.Result.ToString();
            }
            else if (calculatorUtility.IsEqualOperator(key))
            {
                if (calculatorUtility.Number == "")
                    calculatorUtility.Number = calculatorUtility.Result.ToString();
                return SendKeyPress(calculatorUtility.PreviousOperator);
            }
            else
                return calculatorUtility.Number;
            //throw new NotImplementedException();
        }

        private bool SetFlagAndPreviousOperator(char key)
        {
            bool temp = true;
            calculatorUtility.Flag = 1;
            if (SendKeyPress(calculatorUtility.PreviousOperator)=="-E-")
                return false;
            calculatorUtility.PreviousOperator = key;
            return temp;

        }
    }
}
