using ConsoleCalculator.Enums;
using System.Text.RegularExpressions;

namespace ConsoleCalculator.Utility {
    public static class InputValidator {
        public static bool IsNumber(char digit) {
            return new Regex(@"[0-9]").IsMatch(digit.ToString());
        }

        public static bool IsOperation(char operation) {
            return new Regex(@"[+\-Xx\/]").IsMatch(operation.ToString());
        }
        public static KeyType GetKeyType(char key, string OperandOne, string OperandTwo, string Operation) {
            bool isNumber = IsNumber(key);
            bool isoperation = IsOperation(key);
            KeyType keyType = KeyType.Default;
            if (isNumber) {
                keyType = KeyType.Number;
            } else if (isoperation) {
                keyType = KeyType.MathOperation;
            } else if (key == '=') {
                keyType = KeyType.EqualTo;
            } else if (key == 's' || key == 'S') {
                keyType = KeyType.Toggle;
            } else if (key == 'c' || key == 'C') {
                keyType = KeyType.Reset;
            } else if (key == '.') {
                if (Operation == null && !OperandOne.Contains(".")) {
                    keyType = KeyType.DecimalPoint;
                } else if (Operation != null && !OperandTwo.Contains(".")) {
                    keyType = KeyType.DecimalPoint;
                }
            } else {
                keyType = KeyType.NotAllowedCharacter;
            }
            return keyType;
        }
    }
}
