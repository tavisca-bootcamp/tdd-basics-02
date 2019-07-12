using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    class State
    {
        public static string Operator = "+-Xx/";
        public static string Error = "-E-";
        public string input;

        public State()
        {
            this.input = string.Empty;
        }

        public string InputFeed(char key)
        {
            if(IsValidInput(key))
            {
                this.Append(key);
                return this.input;
            }

            if(IsNegation(key))
            {
                this.Negate();
                return this.input;
            }

            throw new Exception();
        }

        public void Negate()
        {
            if (input.Contains("-"))
                input = input.Substring(1);
            else
                input = "-" + input;
        }

        public void Append(char ch)
        {
            this.input += ch;
            this.CorrectInputFornat();
        }

        public static bool IsValidInput(char ch)
        {
            return (char.IsDigit(ch) || ch == '.');
        }

        public static bool IsNegation(char ch)
        {
            return (ch == 's' || ch == 'S');
        }

        public static bool IsOperator(char ch)
        {
            return Operator.Contains(ch.ToString());
        }

        public static bool IsEqualsSign(char ch)
        {
            return (ch == '=');
        }

        public static bool IsClearSign(char ch)
        {
            return (ch == 'c' || ch == 'C');
        }

        public void CorrectInputFornat()
        {
            if (input == ".") input = "0.";

            if (input.Length == 1)
                return;

            if (input[0] == '0' && input[1] != '.')
                input = input.Substring(1);

            if (input.EndsWith(".."))
                input = input.Substring(0, input.Length - 1);
        }

        public static string EvaluateResult(State firstInput, State secondInput, char? operatorValue)
        {
            if (!float.TryParse(firstInput.input, out float input1)) return Error;

            if (secondInput.input == "")
                secondInput.input = firstInput.input;

            if (!float.TryParse(secondInput.input, out float input2)) return Error;

            switch(operatorValue)
            {
                case '+':
                    return (input1 + input2).ToString();
                case '-':
                    return (input1 - input2).ToString();
                case 'x':
                case 'X':
                    return (input1 * input2).ToString();
                case '/':
                    return (input2 == 0 ? Error : (input1 / input2).ToString());
            }
            return string.Empty;
        }
    }
}
