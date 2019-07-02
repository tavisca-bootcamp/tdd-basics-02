using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {   
        public States CurrentState;
        private string number1 = "";
        private string number2 = "";
        private char? previousOperator = null;

        public Calculator() {
            // Display 0 initially
            Console.WriteLine("0");
            CurrentState = States.NumberState;
        }
        public string SendKeyPress(char key)
        {   
            if (Constants.Numbers.Contains(key.ToString())) 
                return Feeder(Events.NumberFeed, key);
            else if (Constants.Operators.Contains(key.ToString())) 
                return Feeder(Events.OperatorFeed, key);
            else if (Constants.Sign.Contains(key.ToString())) 
                return Feeder(Events.SignFeed, key);
            else if (Constants.EqualsSign.Contains(key.ToString())) 
                return Feeder(Events.DisplayResult, key);
            else if (Constants.ClearScreen.Contains(key.ToString())) 
                return Feeder(Events.ClearScreen, key);
            else return Feeder(Events.Error, key);
        }

        public string Feeder(Events type, char key) {
            switch (type) {
                case Events.NumberFeed:
                    CurrentState = States.NumberState;
                    if (previousOperator == null) {
                            number1 += key;
                            CheckForMultipleDotsOrZeroes(ref number1);
                            return number1;
                        }

                    number2 += key;
                    CheckForMultipleDotsOrZeroes(ref number2);
                    return number2;
                
                case Events.SignFeed:
                    if (previousOperator == null) {
                        ToggleSign(ref number1);
                        return number1;
                    }
                    ToggleSign(ref number2);
                    return number2;
                
                case Events.OperatorFeed:
                    CurrentState = States.OperatorState;
                    return EvaluatePreviousExpression(key);
                
                case Events.DisplayResult:
                    CurrentState = States.NumberState;
                    return EvaluatePreviousExpression(null);
                
                case Events.ClearScreen:
                    ClearMemory();
                    number1 = "0";
                    CurrentState = States.NumberState;
                    return number1;
                
                default:
                    if (previousOperator == null) return number1;
                    return number2;
            }
        }

        public void CheckForMultipleDotsOrZeroes(ref string number) {
            if (number.Length == 1) return;

            if (number == "00") number = "0";
            if (number[number.Length-1] == '.' && number[number.Length-2] == '.') 
                number = number.Substring(0, number.Length-1);
        }

        public string EvaluatePreviousExpression(char? currentOperator) {
            // Convert '.' to '0.'
            if (number1 == ".") number1 = "0.";
            if (number2 == ".") number2 = "0.";

            if (previousOperator == null) {
                previousOperator = currentOperator;
                return number1;
            }
            
            if(!float.TryParse(number1, out float num1)) return ErrorState();
            if(number2 == "") number2 = number1;
            if(!float.TryParse(number2, out float num2)) return ErrorState();

            switch (previousOperator) {
                case '+': number1 =  (num1 + num2).ToString(); break;
                case '-': number1 =  (num1 - num2).ToString(); break;
                case 'x': 
                case 'X': number1 =  (num1 * num2).ToString(); break;
                case '/': number1 =  num2 == 0? "error": (num1 / num2).ToString(); break;
            }

            if (number1 == "error") return ErrorState();

            number2 = "";
            previousOperator = currentOperator;
            return number1;
        }

        public void ToggleSign(ref string number) {
            if (number == "") {
                number = "-";
                return;
            }
            if (number == "-") {
                number = "";
                return;
            }
            if (number[0] == '-') {
                number = number.Substring(1);
                return;
            }

            number =  '-' + number;
        }

        public string ErrorState() {
            ClearMemory();
            CurrentState = States.NumberState;
            return "-E-";
        }

        public void ClearMemory() {
            number1 = "";
            number2 = "";
            previousOperator = null;
        }
    }
}
