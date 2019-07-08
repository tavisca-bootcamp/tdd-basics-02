using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private Operand number1;
        private Operand number2;
        private Operand currentDisplay;
        private char? operatorValue = null;

        public Calculator()
        {
            Console.WriteLine("0");

            number1 = new Operand();
            number2 = new Operand();

            currentDisplay = number1;
        }
        public string SendKeyPress(char key)
        {
            KeyStrokeTypes keyStroke;
            if (InputConstants.numbers.Contains(key.ToString()))
                keyStroke = KeyStrokeTypes.Numbers;
            else if (InputConstants.operators.Contains(key.ToString()))
                keyStroke = KeyStrokeTypes.Operators;
            else if (InputConstants.equals.Contains(key.ToString()))
                keyStroke = KeyStrokeTypes.Equals;
            else if (InputConstants.sign.Contains(key.ToString()))
                keyStroke = KeyStrokeTypes.Sign;
            else if (InputConstants.clear.Contains(key.ToString()))
                keyStroke = KeyStrokeTypes.Clear;
            else
                keyStroke = KeyStrokeTypes.Error;

            return EvaluateKeyStroke(keyStroke, key);
        }

        public string EvaluateKeyStroke(KeyStrokeTypes keyStroke, char key)
        {
            switch (keyStroke)
            {
                case KeyStrokeTypes.Numbers:
                    return currentDisplay.AppendContent(key);
                case KeyStrokeTypes.Operators:
                    this.SwitchCurrentDisplay();
                    return EvaluateExpression(key);
                case KeyStrokeTypes.Equals:
                    this.SwitchCurrentDisplay();
                    return EvaluateExpression(key);
                case KeyStrokeTypes.Sign:
                    return currentDisplay.ToggleSign();
                case KeyStrokeTypes.Clear:
                    this.ClearFeed("0","",null);
                    return number1.content;
                default:
                    return currentDisplay.content;
            }
        }

        public string EvaluateExpression(char? key)
        {
            CheckCorrectFormatForInputs();

            if (operatorValue == null)
            {
                operatorValue = key;
                return number1.content;
            }

            if (!float.TryParse(number1.content, out float num1))
            {
                ClearFeed("", "", null);
                return ErrorState();
            }
            if (number2.content == "")
            {
                number2.Set(number1.content);
            }

            if (!float.TryParse(number2.content, out float num2))
            {
                ClearFeed("", "", null);
                return ErrorState();
            }

            var result = Operand.GetExpressionResult(num1, num2, operatorValue);

            ClearFeed(result, "", key);

            if (operatorValue != null)
                this.SwitchCurrentDisplay();

            return number1.content;
        }

        public void ClearFeed(string num1, string num2, char? op)
        {
            number1.Set(num1);
            number2.Set(num2);
            operatorValue = op;

            currentDisplay = number1;
        }

        public void SwitchCurrentDisplay()
        {
            if (currentDisplay == number1)
                currentDisplay = number2;
            else
                currentDisplay = number1;
        }

        public static string ErrorState()
        {
            return "-E-";
        }

        public void CheckCorrectFormatForInputs()
        {
            if (number1.content == "'")
                number1.Set("0.");

            if (number2.content == ".")
                number2.Set("0.");
        }
    }
}
