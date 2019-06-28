using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        static string operand = string.Empty;
        static string temp = string.Empty;
        static string op = string.Empty;

        public string SendKeyPress(char key)
        {
            // Add your implementation here.
            if(char.IsLetter(key))
                key = char.Parse(key.ToString().ToLower());
            switch(key)
            {
                case var v when (char.IsDigit(key)||key=='.'||key=='s'):
                    return GetDigit(key);
                case var v when (key == '+' || key == '-' || key == 'x' || key == '/'):
                    RecievedOperator(key);
                    break;
                case 'c':
                    Reset();
                    break;
                case '=':
                    if (!string.IsNullOrEmpty(op))
                    {
                        string s = op;
                        op = string.Empty;
                        return Result(s);
                    }
                    break;
                default:
                    return "";
                
            }

            return operand;
        }

        private string Result(string op)
        {
            double answer=0;
            switch(op)
            {
                case "+": answer = double.Parse(operand) + double.Parse(temp); break;
                case "-": answer = double.Parse(operand) - double.Parse(temp); break;
                case "/":
                    if (temp == "0")
                        return "-E-";
                    else
                    answer = double.Parse(operand) / double.Parse(temp); break;
                case "x": answer = double.Parse(operand) * double.Parse(temp); break;       
            }
            temp = string.Empty;

            return operand = answer.ToString();
        }

        private void Reset()
        {
            operand = string.Empty;
            temp = string.Empty;
            op = string.Empty;
        }

        private void RecievedOperator(char key)
        {

            if (string.IsNullOrEmpty(op) && !string.IsNullOrEmpty(operand))
            {
                op = key.ToString();
            }
            else
            {
                Result(op);
                op = key.ToString();
            }
        }

        private string GetDigit(char key)
        {
            if (string.IsNullOrEmpty(op))
            {
                if(key=='s')
                    return operand = (double.Parse(operand) * (-1)).ToString();
                if (key == '.')
                {
                    if (!operand.Contains("."))
                        return operand += ".";
                    else
                        return operand;
                }

                if (!(operand == "0" && key == '0'))
                {
                    if (operand == "0")
                        operand = key.ToString();
                    else
                        operand += key.ToString();
                }
                return operand;
            }
            else
            {
                if (key == 's')
                    return temp = (double.Parse(temp) * (-1)).ToString();
                if (key == '.')
                {
                    if (!temp.Contains("."))
                        return temp += ".";
                    else
                        return temp;
                }

                if (!(temp == "0" && key == '0'))
                {
                    if (temp == "0")
                        temp = key.ToString();
                    else
                        temp += key.ToString();
                }
                return temp;
            }
        }
    }
}
