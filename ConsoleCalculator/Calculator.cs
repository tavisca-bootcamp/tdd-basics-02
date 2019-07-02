using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string displayValue;

        public string SendKeyPress(char key)
        {
            displayValue += key.ToString();
            return displayValue;
        }

        public string ShowDisplayValue()
        {
            return displayValue;
        }
    }
}
