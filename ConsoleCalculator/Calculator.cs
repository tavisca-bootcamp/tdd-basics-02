using System;

namespace ConsoleCalculator
{
    public class Decalrations
    {
        public const string operands = "0123456789.";
        public const string operators = "+-/xX";
        public const string reset = "Cc";
        public const string toggle = "sS";
        public const string equalto = "=";
        public string eval(string s1,string s2,char? op)
        {
            string result = null;
            
            
                float num1 = float.Parse(s1);
                float num2 = float.Parse(s2);
                float res;
                switch (op)
                {
                    case '+':
                        res = num1 + num2;
                        result = res.ToString();
                        break;
                    case '-':
                        res = num1 - num2;
                        result = res.ToString();
                        break;
                    case '/':
                        if(num2==0)
                        {
                            result = "-E-";
                            break;
                        }
                        res = num1 / num2;
                        result = res.ToString();
                        break;
                    case 'x':
                    case 'X':
                        res = num1 * num2;
                        result = res.ToString();
                        break;
                }
            
            
            return result;


        }

    }
    public class Calculator
    {
        string s1 = null;
        string s2 = null;
        char? ope=null;
        string result = null;
        Decalrations obj = new Decalrations();

        public string SendKeyPress(char key)
        {
            if (Decalrations.operands.Contains(key.ToString()))
            {
                if (ope == null)
                {
                    if (s1 == "0" && key == '0')
                        result = s1;
                    else if(key=='.' && s1.Contains("."))
                    {
                        result = s1;
                    }
                    else
                    {
                        s1 = s1 + key;
                        result = s1;
                    }
                }
                else
                {
                    if (s2 == "0" && key == '0')
                        result = s2;
                    else if (key == '.' && s2.Contains("."))
                        result = s2;
                    else
                    {
                        s2 = s2 + key;
                        result = s2;
                    }


                }


            }
            else if (Decalrations.operators.Contains(key.ToString()))
            {
                if (ope != null)
                {
                    s1 = obj.eval(s1, s2, ope);
                    s2 = null;
                }

                
                    ope = key;
                    result = s1;
                
            }
            else if (Decalrations.reset.Contains(key.ToString()))
            {
                s1 = null;
                s2 = null;
                result = "0";
            }
            else if (Decalrations.toggle.Contains(key.ToString()))
            {
                if (ope == null)
                {
                    if (s1[0] == '-')
                    {
                        s1 = s1.Substring(1);
                    }
                    else
                    {
                        s1 = "-" + s1;
                    }
                }
                else
                {
                    if (s2[0] == '-')
                    {
                        s2 = s2.Substring(1);
                    }
                    else
                    {
                        s2 = "-" + s2;
                    }
                }
            }
            else
            {   if(s2==null)
                {
                    result = s1;
                }
            else
                result = obj.eval(s1, s2, ope);
            }
                
            return result;

               

            }
        
    }
}

