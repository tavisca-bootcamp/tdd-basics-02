using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {   
        public const string Numbers = "0123456789.";
        public const string Sign = "sS";
        public const string Operators = "+-xX/";
        public const string EqualsSign = "=";
        public const string ClearScreen = "cC";

        public enum Events { NumberFeed, SignFeed, OperatorFeed, DisplayResult, ClearScreen, Error, Default }
        
        private OperandState result;
        private OperandState operand;
        private OperandState currentOperandDisplayed;
        private char? previousOperator = null;

        public Calculator() {
            // Display 0 initially
            Console.WriteLine("0");

            result = new OperandState();
            operand = new OperandState();

            currentOperandDisplayed = result;
        }
        public string SendKeyPress(char key)
        {   
            Events _event = Events.Default;

            if (Numbers.Contains(key.ToString())) 
                _event = Events.NumberFeed;
            else if (Operators.Contains(key.ToString())) 
                _event = Events.OperatorFeed;
            else if (Sign.Contains(key.ToString())) 
                _event = Events.SignFeed;
            else if (EqualsSign.Contains(key.ToString())) 
                _event = Events.DisplayResult;
            else if (ClearScreen.Contains(key.ToString())) 
                _event = Events.ClearScreen;
            else _event = Events.Error;

            return FeedToFSM(_event, key);
        }

        public string FeedToFSM(Events type, char key) {
            switch (type) {
                case Events.NumberFeed:
                    return currentOperandDisplayed.AddAndReturn(key);
                
                case Events.SignFeed:
                    return currentOperandDisplayed.ToggleSignAndReturn();
                
                case Events.OperatorFeed:
                    this.SwitchNumbersBeingDisplayed();
                    return EvaluatePreviousExpression(key);
                
                case Events.DisplayResult:
                    return EvaluatePreviousExpression(null);
                
                case Events.ClearScreen:
                    this.Restore("0", "", null);
                    return result.content;
                
                case Events.Default:
                default:
                    return currentOperandDisplayed.content;
            }
        }

        public string EvaluatePreviousExpression(char? currentOperator) {
            ConvertNumbersInCorrectFormat();

            // No pending operations
            if (previousOperator == null) {
                previousOperator = currentOperator;
                return result.content;
            }

            ParseNumbers(out float num1, out float num2, out bool errorOccurredWhileParsing);

            if (errorOccurredWhileParsing) {
                Restore("", "", null);
                return OperandState.Error;
            }

            return GetResultOrError(num1, num2, currentOperator);
        }

        public string GetResultOrError(float num1, float num2, char? currentOperator) {
            var result = OperandState.GetResult(num1, num2, (char)previousOperator);

            if (result == "error") {
                Restore("", "", null);
                return OperandState.Error;
            }
            
            Restore(result, "", currentOperator);

            // If current operator is not '=', set to modify number 2
            if (currentOperator != null) SwitchNumbersBeingDisplayed();

            return this.result.content;   
        }

        public void ConvertNumbersInCorrectFormat() {
            result.Clean();
            operand.Clean();
        }

        public void ParseNumbers(out float num1, out float num2, out bool errorOccurred) {
            errorOccurred = !float.TryParse(result.content, out num1);

            // If number 2 is empty, fill it with number 1
            if(operand.content == "") operand.content = result.content;

            errorOccurred = !float.TryParse(operand.content, out num2);
        }

        public void Restore(string n1, string n2, char? op) {
            result.Set(n1);
            operand.Set(n2);
            previousOperator = op;

            currentOperandDisplayed = result;
        }

        public void SwitchNumbersBeingDisplayed() {
            if (currentOperandDisplayed == result) {
                currentOperandDisplayed = operand;
            } else {
                currentOperandDisplayed = result;
            }
        }
    }
}
