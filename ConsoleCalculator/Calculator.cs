using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        static string displayNumber;
        static char lastOperation;
        static string resultSoFar;
        public Calculator() {
            ResetCalculator();
        }
        public static void ResetCalculator() {
            displayNumber = "0";
            lastOperation = '?';
            resultSoFar = null;
        }
        public string SetInitialValues(string firstNumber, char firstOperation) {
            lastOperation = firstOperation;
            displayNumber = "0";
            return firstNumber;
        }
        public string CalculateResult(char newOperation) {
            resultSoFar = CalculatorUtils.Calculate(resultSoFar, displayNumber, lastOperation);
            lastOperation = newOperation;
            displayNumber = "0";
            return resultSoFar;
        }
        public string SendKeyPress(char key) {
            //Calculate result and display if operator found
            if (CalculatorUtils.IsOperator(key)) {
                if (lastOperation.Equals('?'))
                    resultSoFar = SetInitialValues(displayNumber, key);
                else
                    resultSoFar = CalculateResult(key);
                return resultSoFar;
            }
            else if (CalculatorUtils.isEqual(key)) {
                resultSoFar = CalculateResult(key);
                return resultSoFar;
            }
            //Else display the previous number 
            else if (CalculatorUtils.IsReset(key))
                ResetCalculator();
            else if (CalculatorUtils.IsSign(key))
                displayNumber = CalculatorUtils.ToggleSign(displayNumber);
            else if (CalculatorUtils.IsNumber(key))
                displayNumber += key;
            else if (CalculatorUtils.IsZero(key))
                displayNumber = CalculatorUtils.HandleZero(displayNumber, key);
            else if (CalculatorUtils.IsDecimal(key))
                displayNumber = CalculatorUtils.HandleDecimal(displayNumber, key);
            displayNumber = CalculatorUtils.HandleLeadingZeroes(displayNumber);
            return displayNumber;
        }
    }
}