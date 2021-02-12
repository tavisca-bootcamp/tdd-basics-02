using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string DisplayValue { get => _displayValue; set => _displayValue = value; }
        public decimal Result { get => _result; set => _result = value; }
        public char[] Digits { get => _digits; set => _digits = value; }
        public char[] Operators { get => _operators; set => _operators = value; }
        public decimal CurrentOperand { get => _currentOperand; set => _currentOperand = value; }
        public char CurrentOperator { get => _currentOperator; set => _currentOperator = value; }

        public void OnKeyPress(char key)
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

        public void HandleDigit(char key)
        {
            if (!string.IsNullOrEmpty(this.DisplayValue) && this.DisplayValue.Contains("."))
            {
                this.SetDisplayValue(this.DisplayValue + key);
            }
            else
            {
                this.CurrentOperand = decimal.Parse(this.CurrentOperand.ToString() + key);
                this.SetDisplayValue(this.CurrentOperand.ToString());
            }
        }

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

        public void PerformArithmeticOperation(char key)
        {
            switch (CurrentOperator)
            {
                case '+':
                    if (this.CurrentOperand > 0)
                    {
                        this.SetDisplayValue((this.Result += this.CurrentOperand).ToString());
                    }
                    else
                    {
                        // yaha equal to ka logic dalega
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

        public void ToggleSign()
        {
            this.CurrentOperand = decimal.Negate(this.CurrentOperand);
            this.SetDisplayValue(this.CurrentOperand.ToString());
        }

        public void SetDisplayValue(string dispValue)
        {
            this.DisplayValue = dispValue;
        }

        public void Reset()
        {
            this.CurrentOperand = 0;
            this.Result = 0;
            this.DisplayValue = 0.ToString();
            this.CurrentOperator = '\0';
        }

        public string ShowDisplayValue()
        {
            return this.DisplayValue;
        }

        public bool IsDigit(char inputKey)
        {
            return Array.IndexOf(this.Digits, inputKey) > -1;
        }

        public bool IsOperator(char inputKey)
        {
            return Array.IndexOf(this.Operators, inputKey) > -1;
        }

        private char _currentOperator;
        private decimal _result;
        private string _displayValue;
        private decimal _currentOperand;
        private char[] _digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] _operators = new char[] { '.', '+', '-', '/', 'x', 's', 'c', '=' };
    }
}