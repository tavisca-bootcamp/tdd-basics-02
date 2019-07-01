using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        Validations v = new Validations();
        string stored=String.Empty,optr, temp = "",disp="0";
        Boolean optrExists=false, canCalc=false;
        public string SendKeyPress(char key)
        {
            string[] validated = new string[2];
            validated = v.Validate(key,temp);

           if(validated[1] != "invalid input")
            {
                if (validated[1] == "operator")
                {
                    if (CanCalc())
                    {
                        stored = Calculate(stored, optr, temp).ToString();
                        temp = "";
                        optr = validated[0];
                        disp = stored;
                    }
                    else
                    {
                        stored = temp;
                        temp = "";
                        optr = validated[0];
                        optrExists = true;
                        disp = stored;
                    }
                }
                else if(validated[1] == "calculate")
                {

                    if (CanCalc())
                    {
                        try
                        {
                            stored = Calculate(stored, optr, temp).ToString();
                        }
                        catch (Exception e)
                        {
                            return "-E-";
                        }
                        optrExists = false;
                        temp = "";
                        disp = stored;
                    }
                    else
                    {
                        stored = Calculate(stored, optr, stored).ToString();
                        disp = stored;
                    }
                }
                else if (validated[1] == "sign")
                {
                    double num = Convert.ToDouble(temp);
                    num = -num;
                    temp = num.ToString();
                    disp = temp;
                }
                else if (validated[1] == "clear")
                {
                    stored = String.Empty;
                    temp = "";
                    disp = "0";
                }
                else
                {
                    temp += key.ToString();
                    disp = temp;
                }
            }

            return disp;
        }

        private Boolean CanCalc()
        {
            if(optrExists && stored.Length>0 && temp.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private double Calculate(string inp1, string inp2, string inp3)
        {
            double result;
            switch (inp2)
            {
                case "+":
                    result = Convert.ToDouble(inp1) + Convert.ToDouble(inp3);
                    break;
                case "-":
                    result = Convert.ToDouble(inp1) + Convert.ToDouble(inp3);
                    break;
                case "x":
                    result = Convert.ToDouble(inp1) + Convert.ToDouble(inp3);
                    break;
                case "/":
                    result = Convert.ToDouble(inp1) + Convert.ToDouble(inp3);
                    break;
                default:
                    return 0;
            }
            return result;
        }
    }
}
