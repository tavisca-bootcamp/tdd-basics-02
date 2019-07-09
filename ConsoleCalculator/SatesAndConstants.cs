namespace ConsoleCalculator
{
    public class InputConstants
    {
        public const string numbers = "0123456789.";
        public const string operators = "+-xX/";
        public const string sign = "sS";
        public const string equals = "=";
        public const string clear = "cC";
    }

    public enum KeyStrokeTypes
    {
        Numbers, Operators, Equals, Clear, Sign, Error
    }

    public class Operand
    {
        public string content;

        public Operand()
        {
            this.Set("");
        }

        public void Set(string s)
        {
            content = s;
        }

        public string AppendContent(char key)
        {
            this.content += key;
            this.CheckMultipleOccuranceOfZeroOrDecimal(this.content);
            return this.content;
        }

        public void CheckMultipleOccuranceOfZeroOrDecimal(string content)
        {
            if (content.Length == 1)
                return;
            else
            {
                if (content[0] == '0' && content[1] != '.')
                    this.Set(content.Substring(1));

                else if (content[content.Length - 1] == '.' && content[content.Length - 2] == '.')
                    this.Set(content.Substring(0, content.Length - 1));
            }
        }

        public string ToggleSign()
        {
            if (content == "")
                this.Set("-");
            if (content[0] == '-')
                this.Set(content.Substring(1));
            else
                this.Set("-" + content);
            return this.content;
        }

        public static string GetExpressionResult(float num1, float num2, char? operatorValue)
        {
            string content = "";
            switch (operatorValue)
            {
                case '+':
                    content = (num1 + num2).ToString();
                    break;
                case '-':
                    content = (num1 - num2).ToString();
                    break;
                case 'x':
                case 'X':
                    content = (num1 * num2).ToString();
                    break;
                case '/':
                    if (num2 == 0) return Calculator.ErrorState();
                    else content = (num1 / num2).ToString();
                    break;
            }
            return content;
        }
    }
}
