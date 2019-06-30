using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string number1 = "";
        private string number2 = "";
        private char? previousOperator = null;

        public static void ToggleSign(ref string number) 
        {
            if (float.TryParse(number, out float n)) {
                number = (-1 * n).ToString();
            }
        }
        

        public string SendKeyPress(char key)
        {
            switch(key) {
                case 'C':
                case 'c':
                    ClearMemory();
                    return "0";
                
                case 'S':
                case 's':
                    // Only number 1 exists
                    if (previousOperator == null) {
                        ToggleSign(ref number1);
                        return number1;
                    }
                    // Number1 in cache and number 2 under process
                    ToggleSign(ref number2);
                    return number2;
                
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
                    // Only number 1 exists
                    if (previousOperator == null) {
                        // To avoid adding multiple 0s at the start
                        if (number1 == "0") number1 = key.ToString();
                        else number1 += key;
                        return number1;
                    }
                        // To avoid adding multiple 0s at the start
                        if (number2 == "0") number2 = key.ToString();
                        else number2 += key;
                        return number2;
                
                case '.':
                    // First condition: Only number 1 exists
                    // Second condition: Avoid adding multiple floating points
                    if (previousOperator == null && number1[number1.Length-1]!= '.') {
                        number1 += key;
                        return number1;
                    }
                    #region Number1 in cache and number 2 under process
                        // Avoid adding multiple floating points
                        if (number2[number2.Length-1] != '.') number2 += key;
                        return number2;
                    #endregion 
                
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

                    // Pressing '=' without any operations
                    if (previousOperator == null) return number1;

                    // Number 2 was not provided before hitting '=', so the displayed number is number2
                    if (number2 == "") number2 = number1;

                    number1 = SendKeyPress((char)previousOperator);
                    
                    if (number1 == "-E-") return Error();

                    number2 = "";
                    previousOperator = null;

                    return number1;
            }

            return "";
        }

        public string DoOperation() {
            
            // If no pending previous operations
            if (previousOperator == null) return this.number1;

            float number1 = float.Parse(this.number1);
            float number2 = float.Parse(this.number2);   

            switch (previousOperator) {
                case '+':
                    return (number1 + number2).ToString();

                case '-':
                    return (number1 - number2).ToString();

                case 'x':
                case 'X':
                    return (number1 * number2).ToString();
                    
                case '/':
                    if (number2 == 0) return "error";
                    return (number1 / number2).ToString();
            }
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
