using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator
{
   public class Calculator
    {
        Stack<string> stackOfEquation = new Stack<string>();
        string answer = "";
        string temp = "";
        string operand1 = "";
        string operand2 = "";
        string oper_ator = "";
        public string SendKeyPress(char key)
        {
            try
            {
                temp = stackOfEquation.Pop();
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
                        if (stackOfEquation.Peek() == "+" || stackOfEquation.Peek() == "-" || stackOfEquation.Peek() == "x" || stackOfEquation.Peek() == "X" || stackOfEquation.Peek() == "/")
                        {
                            stackOfEquation.Push(temp+key);
                        }
                        else
                        {
                            stackOfEquation.Push(temp);
                            stackOfEquation.Push(key.ToString());
                        }
                    }
                    else
                    {
                        temp += key.ToString();
                        stackOfEquation.Push(temp);
                    }
                    return stackOfEquation.Peek();
                case '0':
                    if (temp != "0")
                    {
                        if (temp == "+" || temp == "-" || temp == "x" || temp == "X" || temp == "/")
                        {
                            stackOfEquation.Push(temp);
                            stackOfEquation.Push(key.ToString());
                        }
                        else
                        {
                            temp += key.ToString();
                            stackOfEquation.Push(temp);
                        }
                    }
                    else
                        stackOfEquation.Push(temp);
                    return stackOfEquation.Peek();
                case '.':
                    if (!temp.Contains('.'))
                    {
                        temp = temp + key;
                        stackOfEquation.Push(temp);
                    }
                    else
                        stackOfEquation.Push(temp);
                    return stackOfEquation.Peek();
                case '-':
                case '+':
                case 'x':
                case 'X':
                case '/':
                    if (!stackOfEquation.Contains("+") && !stackOfEquation.Contains("-") && !stackOfEquation.Contains("x") && !stackOfEquation.Contains("X") && !stackOfEquation.Contains("/"))
                    {
                        stackOfEquation.Push(temp);
                        stackOfEquation.Push(key.ToString());
                        if (temp == "+" || temp == "-" || temp == "x" || temp == "X" || temp == "/")
                        {
                            return stackOfEquation.Peek();
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
                    stackOfEquation.Push((Double.Parse(temp)*-1).ToString());
                    return stackOfEquation.Peek();
                case '=':
                    return OperatorFunction(key);
                case 'c':
                case 'C':
                    answer = "";
                    stackOfEquation.Clear();
                    return "0";
            }
            return stackOfEquation.Peek();
        }

        private string OperatorFunction(char key)
        {
            if (temp == "+" || temp == "-" || temp == "x" || temp == "X" || temp == "/")
            {
                operand1 = operand2 = stackOfEquation.Pop();
                return SwitchCase(temp, operand1, operand2);
            }

            oper_ator = stackOfEquation.Pop();
            operand2 = temp;
            operand1 = stackOfEquation.Pop();
            if (operand2 == "0" && oper_ator == "/")
            {
                return "-E-";
            }
            else
            {
                answer = SwitchCase(oper_ator,operand1,operand2);
                if (key == '=')
                {
                    stackOfEquation.Clear();
                    stackOfEquation.Push(answer);
                }
                else
                {
                    stackOfEquation.Push(answer);
                    stackOfEquation.Push(key.ToString());
                }
                return answer;
            }
        }

        public string SwitchCase(string oper_ator,string operand1,string operand2) {
            switch (oper_ator)
            {
                case "+":
                    answer = (Double.Parse(operand1) + Double.Parse(operand2)).ToString();
                    break;
                case "-":
                    answer = (Double.Parse(operand1) - Double.Parse(operand2)).ToString();
                    break;
                case "x":
                case "X":
                    answer = (Double.Parse(operand1) * Double.Parse(operand2)).ToString();
                    break;
                case "/":
                    answer = (Double.Parse(operand1) / Double.Parse(operand2)).ToString();
                    break;
            }
            return answer;
        }
    }
}
