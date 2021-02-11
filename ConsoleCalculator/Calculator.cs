using System;

namespace ConsoleCalculator
{

    public class Calculator
    {
        string FirstOperand = null;
        string SecondOperand = null;
        string Operator = null;
        public string ErrorCode = "-E-";
        const string InitialValue = "0";

        IdentifyInput identify = new IdentifyInput();
        Maker make = new Maker();
        public Calculator()
        {
            Console.WriteLine("0");
        }
        public string SendKeyPress(char key)
        {

            if (identify.isNumeral(key))
            {
                if (Operator == null)
                {
                    return FirstOperand = make.AssignOperand(FirstOperand, key);
                }
                else
                {
                    return SecondOperand = make.AssignOperand(SecondOperand, key);
                }
            }
            else if (identify.isOperator(key))
            {
                if (SecondOperand != null)
                {
                    FirstOperand = Calculate(FirstOperand, SecondOperand, key.ToString());
                    SecondOperand = null;
                    return FirstOperand;
                }
                else
                {
                    Operator = key.ToString();
                    return FirstOperand;
                }
            }
            else if (identify.isAlphabet(key))
            {
                switch (key)
                {
                    case 'c':
                    case 'C':
                        ResetCalculator();
                        return InitialValue;
                    case 's':
                    case 'S':
                        if (Operator == null && FirstOperand != null)
                            return FirstOperand = make.ToggleOperand(FirstOperand);
                        else
                        {
                            if(SecondOperand == null)
                                return FirstOperand = make.ToggleOperand(FirstOperand);
                            else
                                return SecondOperand = make.ToggleOperand(SecondOperand);
                        }
                        
                    default:
                        return ErrorCode;
                }
            }
            else if (key == '.')
            {
                if (SecondOperand == null && Operator == null)
                    FirstOperand = make.AssignOperand(FirstOperand, key);
                else if (Operator != null && FirstOperand != null)
                {
                    SecondOperand = make.AssignOperand(SecondOperand, key);
                }
            }
            else if (key == '=')
            {
                if(SecondOperand == null)
                {
                    if (FirstOperand != null && Operator != null)
                    {
                        return FirstOperand = Calculate(FirstOperand, FirstOperand, Operator);
                    }
                    else
                        return FirstOperand;
                }
                FirstOperand =  Calculate(FirstOperand, SecondOperand, Operator);
                SecondOperand = null;
                return FirstOperand;
            }
            else
            {
                ResetCalculator();
                return ErrorCode;
            }

            return FirstOperand;
        }

        public void ResetCalculator()
        {
            FirstOperand = null;
            SecondOperand = null;
            Operator = null;
        }
        public string Calculate(string FirstOperand, string SecondOperand, string Operator)
        {
            
            switch (Operator)
            {
                case "+":
                    return (double.Parse(FirstOperand) + double.Parse(SecondOperand)).ToString();
                case "-":
                    return (double.Parse(FirstOperand) - double.Parse(SecondOperand)).ToString();
                case "*":
                    return (double.Parse(FirstOperand) * double.Parse(SecondOperand)).ToString();
                case "/":
                    if (double.Parse(SecondOperand) == 0)
                    {
                        ResetCalculator();
                        return ErrorCode;
                    }
                    else
                        FirstOperand = (double.Parse(FirstOperand) + double.Parse(SecondOperand)).ToString();
                    break;
                default:
                    return ErrorCode;
            }
            return ErrorCode;
        }

    }
    public class Maker
    {
        public string AssignOperand(string operand, char key)
        {
            FormatInput format = new FormatInput();

            if (operand == null || operand == "")
            {
                if (key == '.')
                    operand = "0" + key.ToString();
                else
                    operand = key.ToString();
            }
            else
                operand = format.CheckLeadingZeros(operand, key);
            return operand;
        }
        public string ToggleOperand(string operand)
        {
            var res = -1 * double.Parse(operand);
            return res.ToString();
        }

        
        
    }
    public class FormatInput
    {
        public string CheckLeadingZeros(string operand, char key)
        {
            if(operand != null && operand == "0")
            {
                return operand = key.ToString();
            }
            if (key == '.' && operand.Contains("."))
                return operand;
            return operand += key.ToString();
        }
    }
    public class IdentifyInput
    {
        public bool isNumeral(char key)
        {
            return (key <= '9' && key >= '0');
        }
        public bool isAlphabet(char key)
        {
            return (key >= 'A' && key <= 'Z') || (key >= 'a' && key <= 'z');
        }
        public bool isOperator(char key)
        {
            string opSigns = "+-*/";
            return opSigns.Contains(key.ToString());
        }
    }
}
