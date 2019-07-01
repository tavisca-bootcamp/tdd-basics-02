using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator {
    static class CalculatorUtils {
        public static bool IsReset(char key) {
            return (key == 'c' || key == 'C');
        }
        public static bool IsNumber(char key) {
            return (key > '0' && key <= '9');
        }
        public static bool IsOperator(char key) {
            return (key == '+' || key == '-' || key == 'x' || key == 'X' || key == '/');
        }
        public static bool IsSign(char key) {
            return (key == 's' || key == 'S');
        }
        public static bool IsZero(char key) {
            return (key == '0');
        }
        public static bool IsDecimal(char key) {
            return (key == '.');
        }
        public static bool isEqual(char key) {
            return (key == '=');
        }
        public static string ToggleSign(string numberPressed) {
            double toggledNumber = double.Parse(numberPressed) * -1;
            return toggledNumber.ToString();
        }
        public static string HandleZero(string numberPressed, char key) {
            if (!numberPressed.Equals("0"))
                numberPressed += key;
            return numberPressed;
        }
        public static string HandleDecimal(string numberPressed, char key) {
            if (!numberPressed.Contains("."))
                numberPressed += key;
            return numberPressed;
        }
        public static string Calculate(string firstNumber, string secondNumber, char operationSign) {
            double result = 0.0;
            switch (operationSign) {
                case '+':
                    result = double.Parse(firstNumber) + double.Parse(secondNumber);
                    break;
                case '-':
                    result = double.Parse(firstNumber) - double.Parse(secondNumber);
                    break;
                case 'x':
                case 'X':
                    result = double.Parse(firstNumber) * double.Parse(secondNumber);
                    break;
                case '/':
                    if (double.Parse(secondNumber) == 0)
                        return "-E-";
                    result = double.Parse(firstNumber) / double.Parse(secondNumber);
                    break;
            }
            return result.ToString();
        }
        public static string HandleLeadingZeroes(string finalDisplay) {
            if ((finalDisplay.Length > 1) && finalDisplay.StartsWith("0"))
                finalDisplay = finalDisplay.Remove(0, 1);
            if (finalDisplay.StartsWith("."))
                finalDisplay = "0" + finalDisplay;
            return finalDisplay;
        }
    }
}