using System;
using System.Collections.Generic;
namespace ConsoleCalculator
{
    public class Calculator
    {
        public  double operand1 = 0, operand2 = 0;
        public int round = 0;
        public  string operand = "";
        public   string display="wrongkey";
        public List<char> operators = new List<char>();
        public string SendKeyPress(char key)
        {
            //Console.WriteLine("hi");
            List<char> input = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-', '+', 'x', '/', 's', 'c', '=','X','C','S'};
            if(input.Contains(key))
            {
                int index= input.IndexOf(key);
                if (index >= 0 && index <= 10)
                {
                    if (operand == "0" && key != '.')
                        operand = key.ToString();

                    else if (operand.Contains(".") && key=='.' )
                    {
                    }
                    else
                        operand += input[index].ToString();

                    display = operand;
                }
                else if (key=='c' || key == 'C')
                {
                    //validate(operand);
                    round = 0;
                    operand1 = 0; operand2 = 0;
                    display = "0";
                    operand = "0";
                } 
                else if(key == 's' || key == 'S')
                {
                    try
                    {
                        if(operand[0]=='-')
                        {
                            operand = operand.Substring(1, operand.Length - 1);
                        }
                        else
                        {
                            operand = "-" + operand;
                        }
                        display = operand;
                    }
                    catch(Exception)
                    {
                        display = "-E-";
                    }
                }
                else
                {
                    operators.Add(key);
                    if (operators.Count == 2)
                    {
                        if (operators[0] == '+')
                            Addition(operand);
                        else if (operators[0] == '-')
                            Subtract(operand);
                        else if (operators[0] == 'x' || operators[0] == 'X')
                            Multiply(operand);
                        else if (operators[0] == '/')
                            Divide(operand);
                        else
                            return display;

                        operators.RemoveAt(0);
                        //Console.WriteLine($"hi{operators[0]}");
                    }
                    else
                        Validate(operand);                    
                }
            }

            return display;  
        }
        
        public void Validate(string digit)
        {
            try
            {
                if(digit=="" && (operators[0]=='+' || operators[0] == '-'))
                {
                    operand = operators[0].ToString();
                    display = operand;
                    operators.RemoveAt(0);
                    return;
                }
                operand2 = double.Parse(digit);
                if (round == 0)
                {
                    round = 1;
                    operand1 = operand2;
                }
                
                operand = "";
            }
            catch(Exception )
            {
                display = "-E-";
            }
        }
       
        public void Addition(string digit)
        {
            try
            {
                operand2 = double.Parse(digit);
                operand1 = operand1 + operand2;
                display =operand1.ToString();
                operand = "";
            }
            catch (Exception )
            {
                display = "-E-";
            }
        }
        public void Subtract(string digit)
        {
            try
            {
                operand2 = double.Parse(digit);
                operand1 = operand1 - operand2;
                display = operand1.ToString();
                operand = "";
            }
            catch (Exception)
            {
                display = "-E-";
            }
        }
        public void Multiply(string digit)
        {
            try
            {
                operand2 = double.Parse(digit);

                operand1 = operand1 * operand2;
                display = operand1.ToString();
                operand = "";
            }
            catch (Exception)
            {
                display = "-E-";
            }
        }
        public void Divide(string digit)
        {
            try
            {
                operand2 = double.Parse(digit);
                if(operand2==0)
                {
                    display = "-E-";
                    return;
                }
                operand1 = operand1 / operand2;
                display = operand1.ToString();
                operand = "";
            }
            catch (Exception)
            {
                display = "-E-";
            }
        }
    }
}
