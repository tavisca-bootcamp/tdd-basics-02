using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        string val1 = "", val2 = "", final_answer = "";
        char sign;
        int hold = 1, hold_dot = 0;
        double operand1 = 0, operand2 = 0;

        public string SendKeyPress(char key)
        {
            if (key == '.') hold_dot = 1;
            if (hold_dot == 1 && !isSign(key))
            {
                if (hold == 1)
                {
                    val1 += key;
                    return (val1);
                }
                else if (hold == 2)
                {
                    val2 += key;
                    return (val2);
                }
            }
            else if (key == '0' && hold_dot == 0 && val1 == "0")
            {
                if (hold == 1)
                {
                    if (val1 == "" || val1 == "0") val1 = "0";
                    return (val1);
                }
                else if (hold == 2)
                {
                    if (val1 == "" || val1 == "0") val1 = "0"; return (val1);
                }
            }
            else if (Char.IsNumber(key) && hold == 1)
            {
                val1 += key;
                return (val1);
            }
            else if (Char.IsNumber(key) && hold == 2)
            {
                val2 += key;
                return (val2);
            }
            else if (key == '+' || key == '/' || key == '*' || key == '-')
            {
                hold_dot = 0;
                if (hold == 1)
                {
                    operand1 = Convert.ToDouble(val1);
                    hold = 2;
                    sign = key;
                    return val1;
                }
                else if (hold == 2)
                {
                    if (val2 != "") operand2 = Convert.ToDouble(val2);
                    else operand2 = 0;
                    val2 = "";
                    operand1 = Convert.ToDouble(getResult(operand1, operand2, sign));
                    sign = key;
                    return (val1);
                }

            }
            else if (key == '=')
            {
                if (val2 != "") operand2 = Convert.ToDouble(val2);
                else operand2 = 0;

                final_answer = (getResult(operand1, operand2, sign));
                return final_answer;
            }
            else if (key == 'c')
            {
                val1 = ""; val2 = "";
                operand1 = 0; operand2 = 0;
                hold = 1;
                return ("0");
            }
            else if (key == 's')
            {
                operand1 = -operand1;
                return (operand1.ToString());
            }
            else
            {
                return val1;
            }
            return "";
        }

        public bool isSign(char key)
        {
            return (key == '+' || key == '/' || key == '*' || key == '-' || key == '=');
        }
        public string getResult(double val1, double val2, char sign)
        {
            string result = "";
            switch (sign)
            {
                case '+': result = (val1 + val2).ToString(); break;
                case '-': result = (val1 - val2).ToString(); break;
                case '*': result = (val1 * val2).ToString(); break;
                case '/':
                    {
                        if (val2 != 0)
                            result = (val1 / val2).ToString();
                        else result = "-E-";
                        break;
                    }
                default: result = (val1).ToString(); break;
            }
            return result;
        }

        public string getAnswer()
        {
            return final_answer;
        }


    }
    class tester
    {
        static void Main(string[] args)
        {
            Calculator p = new Calculator();
            string s = "100/10-3=c1+2+3s=";
            foreach (char x in s)
            {
                p.SendKeyPress(x);
            }
            Console.Write(p.getAnswer());
        }
    }
}
