using System;
using System.Text.RegularExpressions;

namespace ConsoleCalculator
{
    public class Calculator
    {
        string OperandOne = null;
        string OperandTwo = null;
        string Operation = null;

        private const string ErrorCode = "-E-";
        private const string DefaultState = "0";

        public Calculator()
        {
            Console.WriteLine("0");
        }
        public string SendKeyPress(char key)
        {
            string result = DefaultState;
            try
            {
                KeyType keyType = KayValidator.GetKeyType(key, OperandOne, OperandTwo, Operation);

                switch (keyType)
                {
                    case KeyType.Number:
                    case KeyType.DecimalPoint:
                        result = ParseNumberDecimalPoint(key, result);
                        break;
                    case KeyType.EqualTo:
                        result = ParseEqualTo();
                        break;
                    case KeyType.MathOperation:
                        result = ParseMathOperation(key);
                        break;
                    case KeyType.Toggle:
                        result = ParseToggle();
                        break;
                    case KeyType.Reset:
                        Reset();
                        result = "0";
                        break;
                    case KeyType.Default:
                        result = ParseDefault(result);
                        break;
                    case KeyType.NotAllowedCharacter:
                        result = ParseNotAllowedCharacter(result);
                        break;
                }
            }
            catch (Exception ex)
            {
                result = ErrorCode;
            }
            return result;
        }

        #region ParseKeyTypes

        private string ParseDefault(string result)
        {
            if (Operation == null && OperandOne.Contains("."))
            {
                result = OperandOne;
            }
            else if (Operation != null && OperandTwo.Contains("."))
            {
                result = OperandTwo;
            }

            return result;
        }

        private string ParseNotAllowedCharacter(string result)
        {
            if (Operation == null)
            {
                result = OperandOne;
            }
            else if (Operation != null)
            {
                result = OperandTwo;
            }

            return result;
        }

        private string ParseToggle()
        {
            string result;
            if (Operation == null)
            {
                OperandOne = ToggleNumberSign(OperandOne);
                result = OperandOne;
            }
            else
            {
                OperandTwo = ToggleNumberSign(OperandTwo);
                result = OperandTwo;
            }

            return result;
        }

        private string ParseMathOperation(char key)
        {
            string result;
            if (OperandOne != null && OperandTwo != null && Operation != null)
            {
                OperandOne = Calculate(OperandOne, OperandTwo, Operation);
                OperandTwo = null;
                Operation = null;
            }
            Operation = key.ToString();
            result = OperandOne;
            return result;
        }

        private string ParseEqualTo()
        {
            string result;
            if (OperandOne != null && OperandTwo != null && Operation != null)
            {
                result = Calculate(OperandOne, OperandTwo, Operation);
            }
            else
            {
                result = ErrorCode;
            }

            return result;
        }

        private string ParseNumberDecimalPoint(char key, string result)
        {
            if (OperandOne == null && Operation == null && OperandTwo == null)
            {
                OperandOne = OperandOne + key;
                result = OperandOne;
            }
            else if (OperandOne != null && OperandTwo == null && Operation == null)
            {
                if (OperandOne != "0" || key == '.')
                {
                    OperandOne = OperandOne + key;
                }
                result = OperandOne;
            }
            else if (OperandTwo == null && OperandOne != null && Operation != null)
            {
                OperandTwo = OperandTwo + key;
                result = OperandTwo;
            }
            else if (OperandTwo != null && OperandOne != null && Operation != null)
            {
                if (OperandTwo != "0" || key == '.')
                {
                    OperandTwo = OperandTwo + key;
                }
                result = OperandTwo;
            }

            return result;
        }

        private string ToggleNumberSign(string operand)
        {
            float.TryParse(operand, out float number);
            return (-1 * number).ToString();
        }

        private void Reset()
        {
            OperandOne = null;
            OperandTwo = null;
            Operation = null;
        }

        #endregion

        private string Calculate(string operandOne, string operandTwo, string operation)
        {
            float.TryParse(operandOne, out float firstNumber);
            float.TryParse(operandTwo, out float secondNumber);
            string result = null;
            switch (operation)
            {
                case "+":
                    result = MathCalculator.Add(firstNumber,secondNumber);
                    break;
                case "-":
                    result = MathCalculator.Subtract(firstNumber, secondNumber);
                    break;
                case "X":
                case "x":
                    result = MathCalculator.Multiply(firstNumber, secondNumber);
                    break;
                case "/":
                    result = MathCalculator.Divide(firstNumber, secondNumber);
                    break;
            }
            return result;

        }
    }
}
