using System;

namespace ConsoleCalculator 
{
    class State
    {
        public static string Operators = "+-xX/";
        public static string Error = "-E-";
        public string inputHolder;
        public float number;
        public bool isNegative;

        public State() 
        {
            this.inputHolder = string.Empty;
            isNegative = false;
        }

        public string Feed(char ch) 
        {
            if (State.IsAcceptableNumber(ch)) 
            {
                this.Append(ch);
                this.CleanNumber();
                return this.inputHolder;
            }

            if (State.IsNegation(ch))
            {
                this.Negate();
                
                if (this.isNegative) return "-" + this.inputHolder;
                return this.inputHolder;
            }
            
            throw new ArgumentOutOfRangeException();
        }

        public void Append(char ch)
        {
            this.inputHolder += ch;
        }

        public void Negate()
        {
            this.isNegative = !this.isNegative;
        }

        public void CleanNumber() 
        {
            RemoveZeroesFromStart();
            EnsureNotMoreThanOneAdjacentDecimalPoints();
            
            if (this.inputHolder == ".")
            {
                this.inputHolder = "0.";
            }
        }

        public void RemoveZeroesFromStart() 
        {
            if (this.inputHolder.Length <= 1) return;

            if (this.inputHolder.StartsWith("0") && !this.inputHolder.StartsWith("0."))
            {
                this.inputHolder = this.inputHolder.Substring(1);
            }
        }

        public void EnsureNotMoreThanOneAdjacentDecimalPoints() 
        {
            if (this.inputHolder.Length <= 1) return;

            if (this.inputHolder.EndsWith("..")) 
            {
                // Remove extra decimal point
                this.inputHolder = this.inputHolder.Substring(0, this.inputHolder.Length - 1);
            }
        }

        public static string EvaluateExpression(State first, State second, char @operator)
        {
            bool wereNumbersParsed = ParseNumbersSuccessful(ref first, ref second);
            if (!wereNumbersParsed) return Error;

            switch(@operator)
            {
                case '+': return (first.number + second.number).ToString();
                case '-': return (first.number - second.number).ToString();
                case 'x':
                case 'X': return (first.number * second.number).ToString();
                case '/': return second.number == 0 ? Error: (first.number / second.number).ToString();
                default: return string.Empty;
            }
        }

        public static bool ParseNumbersSuccessful(ref State first, ref State second)
        {
            if (!float.TryParse(first.inputHolder, out first.number)) return false;

            if (second.IsEmpty()) 
            {
                second.inputHolder = first.inputHolder;
                second.isNegative = first.isNegative;
            }
            
            if (!float.TryParse(second.inputHolder, out second.number)) return false;

            if (first.isNegative) first.number *= -1;
            if (second.isNegative) second.number *= -1;

            return true;
        }

        public static bool IsAcceptableNumber(char key) 
        {   
            // We can accept both floating point and digits.
            return char.IsDigit(key) || key == '.';
        }

        public bool IsEmpty()
        {
            return this.inputHolder == string.Empty;
        }

        public static bool IsOperator(char key)
        {
            return Operators.Contains(key.ToString());
        }

        public static bool IsNegation(char key)
        {
            return key.ToString().ToLower() == "s";
        }

        public static bool IsEqualsSign(char key)
        {
            return key == '=';
        }

        public static bool IsClearSign(char key)
        {
            return key.ToString().ToLower() == "c";
        }
    }
}