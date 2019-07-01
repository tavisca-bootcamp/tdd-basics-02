using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public int status = 0;
        double num=0;
        string ans="def";
        int isDecimal = 0;
        double fact=1;
        public static int specialOperator = 0;
        public string SendKeyPress(char key)
        {
            try
            {
                if ((string.Compare("0", key.ToString()) <= 0 && string.Compare("9", key.ToString()) >= 0))
                {
                    specialOperator = 0;
                    if (isDecimal==0)
                    {
                        num *= 10;
                        num += Int32.Parse(key.ToString());
                        //ans = num.ToString();
                        return num.ToString();
                    }
                    fact /= 10;
                    num += (Double.Parse(key.ToString())) * fact;
                    //ans = num.ToString();
                    return num.ToString();

                }

                else if (string.Equals("s", key.ToString()) || string.Equals("S", key.ToString()))
                {
                    if (num == 0)
                    {
                        ans = (Double.Parse(ans) * -1).ToString();
                        return ans;
                    }
                        
                    else
                        num *= -1;
                    return num.ToString();
                }
                else if (string.Equals("c", key.ToString()) || string.Equals("C", key.ToString()))
                {
                    num = 0;
                    ans = "def";
                    isDecimal = 0;
                    status = 0;
                    fact = 1;
                }
                else if (string.Equals("=", key.ToString()))
                {
                    if (specialOperator == 1)
                        ans = Operation(Int32.Parse(ans), ans, status);
                    else
                        ans = Operation(num, ans, status);
                    num = 0;
                    isDecimal = 0;
                    status = 0;
                    fact = 1;
                }
                else if (string.Equals(".", key.ToString()))
                {
                        isDecimal = 1;
                        return num.ToString() + ".";
                    
                    

                }
                else if (string.Equals("+", key.ToString()))
                {

                    ans = Operation(num, ans, status);
                    num = 0;
                    isDecimal = 0;
                    fact = 1;
                    status = 1;
                }
                else if (string.Equals("-", key.ToString()))
                {
                    ans = Operation(num, ans, status);
                    num = 0;
                    isDecimal = 0;
                    fact = 1;
                    status = 2;
                }
                else if (string.Equals("x", key.ToString()) || string.Equals("X", key.ToString()))
                {
                    ans = Operation(num, ans, status);
                    num = 0;
                    isDecimal = 0;
                    fact = 1;
                    status = 3;
                }
                else if (string.Equals("/", key.ToString()))
                {
                    ans = Operation(num, ans, status);
                    num = 0;
                    isDecimal = 0;
                    fact = 1;
                    status = 4;
                }
                //else
                //    status = 0;
                if (ans == "Infinity") 
                    return "--E--";
                if (ans == "def")
                    if (num !=0)
                    {
                        return num.ToString();
                    }
                else
                    return "0";
                return ans;
            }
            catch (Exception)
            {

                return "--E--";
            }
            // Add your implementation here.
            

        }
        public static string Operation(double num,string ans,int sign)
        {
            specialOperator = 1;
            if (string.Equals(ans, "def"))
                return num.ToString(); 
            if (sign == 1)
            {
                
                num += Double.Parse(ans);
                ans = num.ToString();
            }
            else if (sign == 2)
            {
                num = Double.Parse(ans) - num;
                ans = num.ToString();
            }
            else if (sign == 3)
            {
                num *= Double.Parse(ans);
                ans = num.ToString();
            }
            else if (sign == 4)
            {
                num = Double.Parse(ans) / num;
                ans = num.ToString();
            }
            else
            {

            }
                
            return ans;
        }
    }
}
