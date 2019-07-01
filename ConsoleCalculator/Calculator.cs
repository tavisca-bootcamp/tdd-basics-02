using System;

namespace ConsoleCalculator
{
    public class Calculator
    {   
        private string number1 = "";
        private string number2 = "";
        private char? previousOperator = null;

        public string SendKeyPress(char key)
        {
            switch(key) {
                case 'C':
                case 'c': ClearMemory(); return "0";
                
                case 'S': 
                case 's':
                    // Number 1 under process
                    if (previousOperator == null) {
                        StaticFunctions.ToggleSign(ref number1);
                        return number1;
                    }
                    // Number1 in cache and number 2 under process
                    StaticFunctions.ToggleSign(ref number2);
                    return number2;
                
                case '0': case '1': case '2': case '3': case '4':
                case '5': case '6': case '7': case '8': case '9':
                    return NumberCharacterHandling(key);
                
                case '.':
                    return FloatingPointHandling(key);
                
                case '+':
                case '-':
                case 'X':
                case 'x':
                case '/':
                    // Do the previous operation
                    number1 = DoOperation();

                    if (number1 == "error") return Error();

                    number2 = "";

                    // Assign current operation as previous Operation
                    previousOperator = key;
                    return number1;
                
                case '=':
                    return EqualSignPressed();
            }

            return RandomCharacterPress();
        }

        public string RandomCharacterPress() {
            // No number initialized
            if (string.IsNullOrWhiteSpace(number1)) return "";
            // Number 1 exists, but operator and num2 are empty
            if (previousOperator == null) return number1;
            // Number1 in cache and operator initialized, number 2 under process
            return number2;
        }

        public string EqualSignPressed() {
            // If number 1 was not provided
                    if (string.IsNullOrWhiteSpace(number1)) return Error();

                    // Pressing '=' without any operations
                    if (previousOperator == null) return number1;

                    // Number 2 was not provided before hitting '=', so the displayed number is number2
                    if (number2 == "") number2 = number1;

                    // Pass any character, as it will trigger the evaluation of previous operation
                    string result = SendKeyPress('+');
                    ClearMemory();
                    return result;
        }

        public string FloatingPointHandling(char key) {
            // Check if Number 1 under process
            if (previousOperator == null) {
                // Appending floating point to empty number: make empty number='0'
                if (string.IsNullOrEmpty(number1)) {
                    number1 = "0";
                } 

                //Avoid adding multiple floating points
                if (StaticFunctions.LastCharacterOf(number1) != '.') number1 += key;

                return number1;
            }

            #region Number1 in cache and number 2 under process
                // Converting . to 0.
                if (string.IsNullOrEmpty(number2)) number2 = "0" + key;
                // Avoid adding multiple floating points
                else if (StaticFunctions.LastCharacterOf(number2) != '.') number2 += key;
                return number2;
            #endregion 
        }

        public string NumberCharacterHandling(char key) {
            // Number1 under process
            if (previousOperator == null) {
                // To avoid adding 0 at the start of a number: 001 -> 1, 00000 -> 0
                number1 = number1 == "0" ? key.ToString(): number1 + key.ToString();
                return number1;
            }
            // Number 2 under process
            // To avoid adding 0 at the start of a number: 001 -> 1, 00000 -> 0
            number2 = number2 == "0" ? key.ToString(): number2 + key.ToString();
            return number2;
        }

        public string DoOperation() {
            // Convert number1 from string to float
            if (!float.TryParse(number1, out float num1)) return "error";
            
            // First operation: then display number1
            if (previousOperator == null) return number1;

            // Convert number2 from string to float
            if (!float.TryParse(number2, out float num2)) return "error"; 

            switch (previousOperator) {
                case '+': return (num1 + num2).ToString();
                case '-': return (num1 - num2).ToString();
                case 'x': 
                case 'X': return (num1 * num2).ToString();
                case '/': return num2 == 0? "error": (num1 / num2).ToString();
            }

            // Needed to avoid compile time error
            return "";
        }

        public string Error() {
            ClearMemory();
            return "-E-";
        }

        public void ClearMemory() {
            number1 = "";
            number2 = "";
            previousOperator = null;
        }
    }
}
