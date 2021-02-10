using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {


        /* private List<char> validInputs;

public void ListOfAllowedInput(List<char> validInputs)
{
    this.validInputs = validInputs;
}  */
        List<char> validInputs = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-', '+', 'x', '/', 's', 'C', '=' };
        string Inputs = string.Empty;
        string operand=string.Empty;
        int FirstInput, SecondInput;
        int flag = 0;

        public string SendKeyPress(char key)
        {
            if (validInputs.Contains(key) is false)
                return "-E-";
            else
            {
                if (key == 'C')
                {
                    return 0.ToString();
                }
                else if (key is '+'||key is '-'||key is '*'||key is '/')
                {
                    if (Inputs.Length > 0 && flag==0)
                    {
                        FirstInput = Convert.ToInt32(Inputs);
                    }
                    if(Inputs.Length>0 && flag==1)
                    {
                        SecondInput = Convert.ToInt32(Inputs);
                    }
                    Inputs = key.ToString();
                    return Inputs;
                }
                else if(Inputs.Contains("+")|| Inputs.Contains("-")|| Inputs.Contains("*")|| Inputs.Contains("/"))
                    {
                    operand += Inputs;
                    Inputs = key.ToString();
                    SecondInput = Convert.ToInt32(key);
                    flag += 1;
                    return Inputs;
                    }
                else if(key is '=' &&flag==1)
                {
                    if (operand == "+")
                        return (FirstInput + SecondInput).ToString();
                    else if (operand == "-")
                        return (FirstInput - SecondInput).ToString();
                    else if (operand == "*")
                        return (FirstInput * SecondInput).ToString();
                    else if (operand == "/")
                        return (FirstInput / SecondInput).ToString();
                    else
                        return "0";

                }
                else
                {
                    Inputs+=key.ToString();
                    return Inputs;
                    
                }
            }
        }
        
    }
}
