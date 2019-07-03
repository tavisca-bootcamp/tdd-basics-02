using System;
using System.Collections;

namespace ConsoleCalculator
{
    public class Calculator
    {
        enum LastKey
        {
            Digit,
            Operator,
            Letter,
            Dot
        }

        enum OperandSwitch
        {
            OperandA,
            OperandB
        }

        private string onConsoleOutput = "0";

        private LastKey lastKey = LastKey.Digit;
        private OperandSwitch operandSwitch = OperandSwitch.OperandA ;

        private char lastKeyValue = '0';
        private char lastOperator = '#';

        private string operandA;
        private string operandB;
        
        private void Reset()
        {
            onConsoleOutput = "0";
            lastKey = LastKey.Digit;
            operandSwitch = OperandSwitch.OperandA;

            lastKeyValue = '0';
            lastOperator = '#';
        }
        
        private void Result()
        {
            string result = "-E-";
            double a = double.Parse(operandA);
            double b = double.Parse(operandB);

            switch (lastOperator)
            {
                case '+':
                    result = (a + b).ToString();
                    break;
                case '-':
                    result = (a - b).ToString();
                    break;
                case 'x':
                    result = (a * b).ToString();
                    break;
                case '/':
                    if(b != 0)
                        result = (a / b).ToString();
                    break;
            }
            onConsoleOutput = result;
            
        }

        private void Toggle()
        {
            onConsoleOutput = (- double.Parse(onConsoleOutput)).ToString();
            if(operandSwitch == OperandSwitch.OperandA)
                operandA = onConsoleOutput;
            else
                operandB = onConsoleOutput;
        }

        private void HandleDecimals()
        {
            if(onConsoleOutput.Contains("."))
                return;

            if(onConsoleOutput == "0")
                onConsoleOutput = "0.";
        }

        public string SendKeyPress(char key)
        {
            switch (key)
            {
                case var tempKey when (tempKey >= '0' && tempKey <= '9'):
                    if (operandSwitch == OperandSwitch.OperandA)
                    {
                        if (lastKey == LastKey.Digit)
                        {
                            if(onConsoleOutput == "0")
                                onConsoleOutput = key.ToString();
                            else
                                onConsoleOutput = onConsoleOutput + key.ToString();
                            operandA = onConsoleOutput;
                        }
                    }
                    else if (operandSwitch == OperandSwitch.OperandB)
                    {
                        if(lastKey == LastKey.Operator)
                            onConsoleOutput = key.ToString();

                        else if (lastKey == LastKey.Digit)
                        {
                            if(onConsoleOutput == "0")
                                onConsoleOutput = key.ToString();
                            else
                                onConsoleOutput = onConsoleOutput + key.ToString();
                        }
                        operandB = onConsoleOutput;
                    }
                    lastKeyValue = key;
                    lastKey = LastKey.Digit;
                    break;

                case var tempKey when (tempKey == '+' || tempKey == '-' || tempKey == '/' || tempKey.ToString().ToLower() == "x"):
                    if (operandSwitch == OperandSwitch.OperandA)
                    {
                        operandSwitch = OperandSwitch.OperandB;
                        lastKey = LastKey.Operator;
                        lastOperator = tempKey;
                        return onConsoleOutput;
                    }
                    Result();

                    lastOperator = tempKey;
                    lastKey = LastKey.Operator;
                    operandA = onConsoleOutput;

                    if(operandSwitch == OperandSwitch.OperandA)
                        operandSwitch = OperandSwitch.OperandB;
        
                    break;

                case var tempKey when (tempKey.ToString().ToLower() == "s"):
                    Toggle();
                    break;

                case var tempKey when (tempKey.ToString().ToLower() == "c"):
                    Reset();
                    break;

                case var tempKey when (tempKey == '='):
                    Result();
                    break;

                case var tempKey when (tempKey == '.'):
                    HandleDecimals();
                    break;
            }
            return onConsoleOutput;
        }
    }
}
