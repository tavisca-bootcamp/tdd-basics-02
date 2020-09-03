using ConsoleCalculator.Common;
using ConsoleCalculator.Factories;
using ConsoleCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Calculator
    {
        double result = 0;
        const string ErrorString = "-E-";
        bool isResultUpdated = false;
        bool isOperandConsumed = false;

        StringBuilder operand;
        IOperation operation;
        OperatorFactory operatorFactory;

        public Calculator()
        {
            operand = new StringBuilder();
            operation = null;
            operatorFactory = new OperatorFactory();
        }

        public string SendKeyPress(char key)
        {
            try
            {
                KeyType keyType = Utility.GetKeyType(key);
                switch (keyType)
                {
                    case KeyType.Number:
                        HandleNumberInput(key);
                        return operand.ToString();

                    case KeyType.Decimal:
                        HandleDecimalPointInput(key);
                        return operand.ToString();

                    case KeyType.Sign:
                        ChangeSign();
                        return operand.ToString();

                    case KeyType.Operator:
                        HandleOperatorInput(key);
                        return result.ToString();

                    case KeyType.Equals:
                        CalculateResult();
                        return result.ToString();

                    case KeyType.Clear:
                        ResetCalculator();
                        return result.ToString();

                    default:
                        return result.ToString();

                }
            }
            catch (Exception ex)
            {
                ResetCalculator();
                return ErrorString;
            }
        }

        private void ResetCalculator()
        {
            result = 0;
            operand.Clear();
            operation = null;
            isResultUpdated = false;
            isOperandConsumed = false;
        }

        private void CalculateResult()
        {
            if (operation != null)
            {
                if (operand.Length > 0)
                    result = operation.Operate(result, Convert.ToDouble(operand.ToString()));
            }
        }

        private void HandleOperatorInput(char key)
        {
            if (operation != null && isResultUpdated)
                result = operation.Operate(result, Convert.ToDouble(operand.ToString()));
            else
                result = Convert.ToDouble(operand.ToString());

            operation = operatorFactory.GetOperation(key);

            operand.Clear().Append(result.ToString());
            isOperandConsumed = true;
            isResultUpdated = true;
        }

        private void ChangeSign()
        {
            if (double.TryParse(operand.ToString(), out double temp))
            {
                operand.Clear();
                operand.Append((-1 * temp).ToString());
            }
        }

        private void HandleDecimalPointInput(char key)
        {
            if (!operand.ToString().Contains(key.ToString()))
                operand.Append(key);
        }

        private void HandleNumberInput(char key)
        {
            if (isOperandConsumed)
            {
                operand.Clear();
                isOperandConsumed = false;
            }

            operand.Append(key);
            double.TryParse(operand.ToString(), out double temp);
            operand.Clear().Append(temp.ToString());
        }
    }
}
