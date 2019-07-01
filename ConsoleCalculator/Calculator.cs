using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{

    public class Calculator
    {
        string s = "";
        char op = '+';
        decimal num = 0;
        decimal result = 0;
        int f = 0, d=0;
        char[] opr = { '+', '-', '*', '/' };

       

        public string SendKeyPress(char key)
        {
            HashSet<char> hs = new HashSet<char>(opr);

            if ( (int)key>=48 && (int)key<=57 )
            {
                f = 0;
                int n = (int)key - 48;
                if (s.Equals("0"))
                    s = "";
                s = s + n;
                return s;
            }
            else if (hs.Contains(key))
            {
                if (f != 0)
                    return "-E-";
                f = 1;
                d = 0;
                decimal n1 = 0;
                n1 = decimal.Parse(s);
                if (op == '+')
                {
                    num = num + n1;
                }
                else if (op == '-')
                {
                    num = num - n1;
                }
                else if (op == '*')
                {
                    num = num * n1;
                }
                else if (n1 == 0)
                {
                    return "-E-";
                }
                else
                {
                    num = num / n1;
                }

                if (key =='+' || key == '-')
                {
                    result = result + num;
                    num = 0;
                }
                op = key;

                s = "";

                decimal x = result + num;
                string y = "" + x;
                return y;
            }

            if (key == '.')
            {
                if (d==0)
                {
                    if (s.Length == 0)
                        s = "0";
                    s = s + ".";
                    d = 1;
                }
                return s;
            }

            if (key == 'S')
            {
                if (s.Length == 0)
                {
                    result = 0-result;
                    return ("" + result);
                }
                if (s[0] == '-')
                    s = s.Substring(1);
                else if (!s.Equals("0"))
                    s = "-" + s;
                return s;
            }



            if (key == '=')
            {
                if (f != 0)
                {
                    return "-E-";
                }
                d = 0;
                decimal n1 = 0;
                if (s.Length > 0)
                    n1 = decimal.Parse(s);
                if (op == '+')
                {
                    result = result + n1;
                }
                else if (op == '-')
                {
                    result = result - n1;
                }
                else if (op == '*')
                {
                    num = num * n1;
                    result += num;
                    num = 0;
                }
                else if (n1 == 0)
                {
                    return "-E-";
                }
                else
                {
                    num = num / n1;
                    result += num;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    num = 0;
                }
                op = '+';
                return ("" + result);
                
            }

            if (key == 'C')
            {
                s = "";
                op = '+';
                num = 0;      
                result = 0;                                                                                                                                                                                                                           
                f = 1                                                                                                                                          ;
                d = 0;
                return "0";
            }


            return "-E-";
        }
    }
}
