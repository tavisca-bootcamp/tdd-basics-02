using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        string stored,temp,disp;
        char optr;
        Boolean optrExists = false;


        public string SendKeyPress(char key)
        {

            if (ValidationHelper.IsValid(key))
            {
                if (ValidationHelper.IsOperator(key))
                {
                    if (CanCalc())
                    {
                        stored = Calculate(stored, optr, temp).ToString();
                        temp = "";
                        optr = key;
                        disp = stored;
                    }
                    else
                    {
                        stored = temp;
                        temp = "";
                        optr = key;
                        optrExists = true;
                        disp = stored;
                    }
                }
                else if (ValidationHelper.IsEquals(key))
                {

                    if (CanCalc())
                    {

                        stored = Calculate(stored, optr, temp).ToString();
                        optrExists = false;
                        temp = "";
                        if (Double.IsInfinity(Convert.ToDouble(stored)))
                        {
                            disp = "-E-";
                        }
                        else
                        {
                            disp = stored;
                        }
                    }
                    else
                    {
                        stored = Calculate(stored, optr, stored).ToString();
                        disp = stored;
                    }
                }
                else if (ValidationHelper.IsSignToggle(key))
                {
                    double num = Convert.ToDouble(temp);
                    num = -num;
                    temp = num.ToString();
                    disp = temp;
                }
                else if (ValidationHelper.IsClear(key))
                {
                    stored = String.Empty;
                    temp = "";
                    disp = "0";
                }
                else if(ValidationHelper.IsDigit(key,temp))
                {
                    temp += key.ToString();
                    disp = temp;
                }
            }

            return disp;
        }

        private Boolean CanCalc()
        {
            if (optrExists && stored.Length > 0 && temp.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private double Calculate(string inp1, char inp2, string inp3)
        {
            double result;
            switch (inp2)
            {
                case '+':
                    result = Convert.ToDouble(inp1) + Convert.ToDouble(inp3);
                    break;
                case '-':
                    result = Convert.ToDouble(inp1) - Convert.ToDouble(inp3);
                    break;
                case 'x':
                    result = Convert.ToDouble(inp1) * Convert.ToDouble(inp3);
                    break;
                case '/':
                    result = Convert.ToDouble(inp1) / Convert.ToDouble(inp3);
                    break;
                default:
                    return 0;
            }
            return result;
        }
    }
}
