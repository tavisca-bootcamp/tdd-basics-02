using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        static string number = string.Empty;
        static string operation = string.Empty;
        static string secondNumber = string.Empty;

        public string SendKeyPress(char key)
        {
            switch(key)
            {
                case 'c':
                    ResetAll();
                    return "0";
                case 'C':
                    ResetAll();
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
                    return ShowNumber(key);
                
                case '+':
                    SetCalculationSymbol(key);
                    break;
                case '-':
                    SetCalculationSymbol(key);
                    break;
                case 'x':
                    SetCalculationSymbol(key);
                    break;
                case '/':
                    SetCalculationSymbol(key);
                    break;
                case '=':
                    if (!string.IsNullOrEmpty(operation))
                    {
                        string previousOperation = operation;
                        operation = string.Empty;
                        return DoCalculation(previousOperation);
                    }
                    break;
                default:
                    return string.Empty;
                
            }

            return number;
        }

        private string DoCalculation(string operation)
        {
            string answer=string.Empty;
            switch(operation)
            {
                case "+":
                    double parsedNumber;
                    double parsedSecondNumber;
                    if(double.TryParse(number,out parsedNumber) && double.TryParse(secondNumber,out parsedSecondNumber))
                    {
                        answer =  (parsedNumber + parsedSecondNumber).ToString();
                        secondNumber = string.Empty;
                        number = answer;
                        break;
                    }
                    else
                    {
                        secondNumber = number;
                        return DoCalculation(operation);
                    }
                case "-":
                    if(double.TryParse(number,out parsedNumber) && double.TryParse(secondNumber,out parsedSecondNumber))
                    {
                        answer = (parsedNumber - parsedSecondNumber).ToString();
                        secondNumber = string.Empty;
                        number = answer;
                        break;
                    }
                    else
                    {
                        secondNumber = number;
                        return DoCalculation(operation);
                    }
                case "/":
                    if (secondNumber == "0")
                    {
                        return "-E-";
                    }
                    else
                    {
                        if(double.TryParse(number,out parsedNumber) && double.TryParse(secondNumber,out parsedSecondNumber))
                        {
                            answer = (parsedNumber / parsedSecondNumber).ToString();
                            secondNumber = string.Empty;
                            number = answer;
                            break;
                        }
                        else
                        {
                            secondNumber = number;
                            return DoCalculation(operation);
                        }
                    }
                case "x":
                    if(double.TryParse(number,out parsedNumber) && double.TryParse(secondNumber,out parsedSecondNumber))
                    {
                        answer = (parsedNumber * parsedSecondNumber).ToString();
                        secondNumber = string.Empty;
                        number = answer;
                        break;
                    }
                    else
                    {
                        secondNumber = number;
                        return DoCalculation(operation);
                    }
            }
            return answer;
        }

        public void ResetAll()
        {
            number = string.Empty;
            secondNumber = string.Empty;
            operation = string.Empty;
        }

        private void SetCalculationSymbol(char key)
        {

            if ( string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(number))
            {
                operation = key.ToString();
            }
            else
            {
                DoCalculation(operation);
                operation = key.ToString();
            }
        }

        private string ShowNumber(char key)
        {
            if ( string.IsNullOrEmpty(operation))
            {
                if(key=='s' || key == 'S')
                {
                    double parsedNumber;
                    double.TryParse(number,out parsedNumber);
                    number = ( parsedNumber * -1 ).ToString();
                    return number;
                }
                if (key == '.')
                {
                    if (!number.Contains("."))
                    {
                        return number += ".";
                    }
                    else
                    {
                        return number;
                    }
                }
                if (!(number == "0" && key == '0'))
                {
                    if (number == "0")
                    {
                        number = key.ToString();
                    }
                    else
                    {
                        number += key.ToString();
                    }
                }
                return number;
            }
            else
            {
                if (key == 's')
                {
                    double parsedSecondNumber;
                    double.TryParse(secondNumber,out parsedSecondNumber);
                    secondNumber = (parsedSecondNumber * -1 ).ToString();
                    return secondNumber;
                }
                if (key == '.')
                {
                    if (!secondNumber.Contains("."))
                    {
                        return secondNumber += ".";
                    }
                    else
                    {
                        return secondNumber;
                    }
                }
                if (!(secondNumber == "0" && key == '0'))
                {
                    if (secondNumber == "0")
                    {
                        secondNumber = key.ToString();
                    }
                    else
                    {
                        secondNumber += key.ToString();
                    }
                }
                return secondNumber;
            }
        }
    }
}
