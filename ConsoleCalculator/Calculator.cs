using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator
{
   public class Calculator
    {
        Stack<string> equationStack = new Stack<string>();
        string operand1 = "";
        string operand2 = "";
        string operatr = "";
		string result = "";
        string temp = "";
        public string SendKeyPress(char key)
        {
            try
            {
                temp = equationStack.Pop();
            }
            catch (Exception)
            {
                temp = "";
            }
            switch (key)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    if (temp == "+" || temp == "-" || temp == "x" || temp == "X" ||temp == "/")
                    {
                        if (equationStack.Peek() == "+" || equationStack.Peek() == "-" || equationStack.Peek() == "x" || equationStack.Peek() == "X" || equationStack.Peek() == "/")
                        {
                            equationStack.Push(temp+key);
                        }
                        else
                        {
                            equationStack.Push(temp);
                            equationStack.Push(key.ToString());
                        }
                    }
                    else
                    {
                        temp += key.ToString();
                        equationStack.Push(temp);
                    }
                    return equationStack.Peek();
                case '0':
                    if (temp != "0")
                    {
                        if (temp == "+" || temp == "-" || temp == "x" || temp == "X" || temp == "/")
                        {
                            equationStack.Push(temp);
                            equationStack.Push(key.ToString());
                        }
                        else
                        {
                            temp += key.ToString();
                            equationStack.Push(temp);
                        }
                    }
                    else
                        equationStack.Push(temp);
                    return equationStack.Peek();
                case '.':
                    if (!temp.Contains('.'))
                    {
                        temp = temp + key;
                        equationStack.Push(temp);
                    }
                    else
                        equationStack.Push(temp);
                    return equationStack.Peek();
                case '-':
                case '+':
                case 'x':
                case 'X':
                case '/':
                    if (!equationStack.Contains("+") && !equationStack.Contains("-") && !equationStack.Contains("x") && !equationStack.Contains("X") && !equationStack.Contains("/"))
                    {
                        equationStack.Push(temp);
                        equationStack.Push(key.ToString());
                        if (temp == "+" || temp == "-" || temp == "x" || temp == "X" || temp == "/")
                        {
                            return equationStack.Peek();
                        }
                        else
                        {
                            return temp;
                        }
                    }
                    else
                    {
                        return OperatorFunction(key);
                    }
                case 's':
                case 'S':
                    equationStack.Push((Double.Parse(temp)*-1).ToString());
                    return equationStack.Peek();
                case '=':
                    return OperatorFunction(key);
                case 'c':
                case 'C':
                    result = "";
                    equationStack.Clear();
                    return "0";
            }
            return equationStack.Peek();
        }

        private string OperatorFunction(char key)
        {
            if (temp == "+" || temp == "-" || temp == "x" || temp == "X" || temp == "/")
            {
                operand1 = operand2 = equationStack.Pop();
                return SwitchCase(temp, operand1, operand2);
            }

            operatr = equationStack.Pop();
            operand2 = temp;
            operand1 = equationStack.Pop();
            if (operand2 == "0" && operatr == "/")
            {
                return "-E-";
            }
            else
            {
                result = SwitchCase(operatr,operand1,operand2);
                if (key == '=')
                {
                    equationStack.Clear();
                    equationStack.Push(result);
                }
                else
                {
                    equationStack.Push(result);
                    equationStack.Push(key.ToString());
                }
                return result;
            }
        }

        public string SwitchCase(string operatr,string operand1,string operand2) {
            switch (operatr)
            {
                case "+":
                    result = (Double.Parse(operand1) + Double.Parse(operand2)).ToString();
                    break;
                case "-":
                    result = (Double.Parse(operand1) - Double.Parse(operand2)).ToString();
                    break;
                case "x":
                case "X":
                    result = (Double.Parse(operand1) * Double.Parse(operand2)).ToString();
                    break;
                case "/":
                    result = (Double.Parse(operand1) / Double.Parse(operand2)).ToString();
                    break;
            }
            return result;
        }
    }
}
