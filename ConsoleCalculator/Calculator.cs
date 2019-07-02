using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private char currentOperator;
        private decimal result;
        private string displayValue;
        private decimal currentOperand;
        private char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] operators = new char[] { '.', '+', '-', '/', 'x', 's', 'c', '=' };
        public string DisplayValue { get => displayValue; set => displayValue = value; }
        public decimal Result { get => result; set => result = value; }
        public char[] Digits { get => digits; set => digits = value; }
        public char[] Operators { get => operators; set => operators = value; }
        public decimal CurrentOperand { get => currentOperand; set => currentOperand = value; }
        public char CurrentOperator { get => currentOperator; set => currentOperator = value; }
        public void PressSingleKey(char key)
        {
            if (IsDigit(key))
            {
                this.HandleDigit(key);
            }

            if (IsOperator(key))
            {
                this.HandleOperator(key);
            }
        }
        //Function checks for a digit entered
        public void HandleDigit(char key)
        {
            if (!string.IsNullOrEmpty(this.DisplayValue) && this.DisplayValue.Contains("."))//decimal number after decimal point
            {
                this.SetDisplayValue(this.DisplayValue + key);
            }
            else//whole number or decimal number before decimal point
            {
                this.CurrentOperand = decimal.Parse(this.CurrentOperand.ToString() + key);
                this.SetDisplayValue(this.CurrentOperand.ToString());
            }
        }
        //handling keys belonging to operator array initialised in the beginning
        public void HandleOperator(char key)
        {
            switch (key)
            {
                case 'c':
                    this.Reset();
                    break;

                case 's':
                    this.ToggleSign();
                    break;

                case '.':
                    this.SetDisplayValue(this.DisplayValue + ".");
                    break;

                case '+':
                case '-':
                case '/':
                case 'x':
                case '=':
                    this.HandleArithmeticOperator(key);
                    break;

                default:
                    break;
            }
        }
        public void HandleArithmeticOperator(char key)
        {
            if (this.CurrentOperator == '\0')
            {
                this.CurrentOperator = key;
                this.Result = this.CurrentOperand;
                this.CurrentOperand = 0;
            }
            else 
            {
                this.PerformArithmeticOperation(key);
            }

        }
        //computation of operators
        public void PerformArithmeticOperation(char key)
        {
            switch (this.CurrentOperator)
            {
                case '+':
                    if (this.CurrentOperand > 0)
                    {
                        this.SetDisplayValue((this.Result += this.CurrentOperand).ToString());
                    }
                    else
                    {
                        this.SetDisplayValue((this.Result *= 2).ToString());
                    }

                    break;

                case '-':
                    this.SetDisplayValue((this.Result -= this.CurrentOperand).ToString());
                    break;

                case '/':
                    if (CurrentOperand == 0)
                    {
                        this.SetDisplayValue("-E-");
                    }
                    else
                    {
                        this.SetDisplayValue((this.Result /= this.CurrentOperand).ToString());
                    }

                    break;

                case 'x':
                    this.SetDisplayValue((this.Result *= this.CurrentOperand).ToString());
                    break;

                default:
                    break;
            }
            this.CurrentOperator = key;
            this.CurrentOperand = 0;
        }
        //togglesign is called when 's' is pressed to negate the current sign
        public void ToggleSign()
        {
            this.CurrentOperand = decimal.Negate(this.CurrentOperand);
            this.SetDisplayValue(this.CurrentOperand.ToString());
        }
        //sets display value to current result
        public void SetDisplayValue(string dispValue)
        {
            this.DisplayValue = dispValue;
        }
        //resets the values of operators and operands and display to 0
        public void Reset()
        {
            this.CurrentOperand = 0;
            this.Result = 0;
            this.DisplayValue = 0.ToString();
            this.CurrentOperator = '\0';
        }
        //displays current result
        public string ShowDisplayValue()
        {
            return this.DisplayValue;
        }
        //returns true if the current key pressed belongs to digit array 
        //initialised in the beginning
        public bool IsDigit(char inputKey)
        {
            return Array.IndexOf(this.Digits, inputKey) > -1;
        }
        //returns true if the current key pressed belongs to operator array 
        //initialised in the beginning
        public bool IsOperator(char inputKey)
        {
            return Array.IndexOf(this.Operators, inputKey) > -1;
        }
    }
}