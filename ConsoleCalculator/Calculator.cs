using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string number1 = "";
        private string number2 = "";
        private string operation = "";

        public string SendKeyPress(char key)
        {
            // Add your implementation here.
            // throw new NotImplementedException();
            switch (key)
            {
                case 'C':
                case 'c':
                    clearSceen();
                    return "0";
                case '.':
                case 'S':
                case 's':
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return Getnumber(key);

                case '+':
                    SetOperations(key);
                    break;
                case '-':
                    SetOperations(key);
                    break;
                case 'x':
                    SetOperations(key);
                    break;
                case '/':
                    SetOperations(key);
                    break;
                case '=':
                    if (operation != "")
                    {
                        string previousOperation = operation;
                        operation = "";
                        return DoCalculation(previousOperation);
                    }
                    break;
                default:
                    return "";

            }
            return number1;
        }

        private void clearSceen()
        {
            //throw new NotImplementedException();
            number1 = "";
            number2 = "";
            operation = "";

        }


        private void SetOperations(char key)
        {
            //throw new NotImplementedException();
            if (operation == "" && number1 != "")
            {
                operation = key.ToString();
            }
            else
            {
                DoCalculation(operation);
                operation = key.ToString();
            }
        }

        private string DoCalculation(string operation)
        {
            //throw new NotImplementedException();
            string answer = "";
            if (operation == "+")
            {

                try
                {
                    answer = (double.Parse(number1) + double.Parse(number2)).ToString();
                    number2 = "";
                    number1 = answer;
                }
                catch (FormatException e)
                {
                    number2 = number1;
                    return DoCalculation(operation);
                }

            }
            else if (operation == "-")
            {
                try
                {
                    answer = (double.Parse(number1) - double.Parse(number2)).ToString();
                    number2 = "";
                    number1 = answer;
                }
                catch (FormatException e)
                {
                    number2 = number1;
                    return DoCalculation(operation);
                }
            }
            else if (operation == "/")
            {
                if (number2 == "0")
                {
                    return "-E-";
                }
                else
                {
                    try
                    {
                        answer = (double.Parse(number1) / double.Parse(number2)).ToString();
                        number2 = "";
                        number1 = answer;
                    }
                    catch (Exception e)
                    {
                        number2 = number1;
                        return DoCalculation(operation);
                    }
                }
            }
            else if (operation == "x")
            {
                try
                {
                    answer = (double.Parse(number1) * double.Parse(number2)).ToString();
                    number2 = "";
                    number1 = answer;
                }
                catch (Exception e)
                {
                    number2 = number1;
                    return DoCalculation(operation);
                }
            }
            return answer;
        }



        private string Getnumber(char key)
        {
            //throw new NotImplementedException();
            if (operation == "")
            {
                if (key == 's' || key == 'S')
                {
                    number1 = (double.Parse(number1) * -1).ToString();
                    return number1;
                }
                if (key == '.')
                {
                    if (!number1.Contains("."))
                    {
                        return number1 += ".";
                    }
                    else
                    {
                        return number1;
                    }
                }
                if (!(number1 == "0" && key == '0'))
                {
                    if (number1 == "0")
                    {
                        number1 = key.ToString();
                    }
                    else
                    {
                        number1 += key.ToString();

                    }
                }

                return number1;
            }
            else
            {
                if (key == 's')
                {
                    number2 = (double.Parse(number2) * -1).ToString();
                    return number2;
                }
                if (key == '.')
                {
                    if (!number2.Contains("."))
                    {
                        return number2 += ".";
                    }
                    else
                    {
                        return number2;
                    }
                }
                if (!(number2 == "0" && key == '0'))
                {
                    if (number2 == "0")
                    {
                        number2 = key.ToString();
                    }
                    else
                    {
                        number2 += key.ToString();

                    }
                }

                return number2;
            }
        }
    }
}
