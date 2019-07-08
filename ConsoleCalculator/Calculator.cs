using System;
using System.Text.RegularExpressions;

namespace ConsoleCalculator
{
    public class Calculator
    {
        string FirstOperand = null;
        string SecondOperand = null;
        string Operation = null;

        const string ErrorCode = "-E-";
        const string DefaultState = "0";

        public Calculator()
        {
            //Console.Clear();
            Console.WriteLine("0");
        }

        public string SendKeyPress(char key)
        {
        
            switch(key)
            {
                // Case when key is a number
                case var number when  CheckForDigit(key) == true :
                    // To check if operating still on number 1
                    if (Operation == null)
                    {

                        //To avoid leading zeros
                        if (FirstOperand == "0")
                            FirstOperand = null;

                        FirstOperand += key;
                        return FirstOperand;
                    }
                    // Operating on number 2 if operator is not null
                    SecondOperand += key;
                    return SecondOperand;

                // Case when key is Operation
                case var operationCheck when CheckForOperation(key) == true :

                    // To check for new or any previous operations
                    if(Operation == null)
                    {
                        Operation += key;

                        return FirstOperand;
                    }

                    FirstOperand = CalculateAnswer(FirstOperand, SecondOperand, Operation);
                    SecondOperand = null;
                    Operation = key.ToString();

                    return FirstOperand;

                // Case when result is returned
                case '=':

                    // if Equal sign tped abruptly, return to default state
                    if (CheckForNullValues() == true)
                        return DefaultState;

                    else if (FirstOperand != null && SecondOperand == null)
                        return FirstOperand;

                    return CalculateAnswer(FirstOperand, SecondOperand, Operation); ;

                // Case when user toggles sign
                case 'S': case 's':
                    return (Operation == null) ? FirstOperand = ToggleSign(FirstOperand) : SecondOperand = ToggleSign(SecondOperand);

                // Case when decimal operations are used
                case '.':
                    if(Operation == null)
                    {
                        // To check if current operand already is a float number
                        if (FirstOperand.Contains("."))
                            return FirstOperand;
                        return FirstOperand += key;
                    }

                    if (SecondOperand.Contains("."))
                        return SecondOperand;
                    return SecondOperand += key;

                // Case when values are reset and default state is returned
                case 'C': case 'c':
                    Reset();
                    return DefaultState;
            }

            //Error occurred while parsing character
            //Resetting all values and returning error code
            Reset();
            return ErrorCode;
        }

        private void Reset()
        {
            FirstOperand = null;
            SecondOperand = null;
            Operation = null;
        }

        private bool CheckForDigit(char digit)
        {
            return new Regex(@"[0-9]").IsMatch(digit.ToString()) ;
        }

        private bool CheckForOperation(char operation)
        {
            return new Regex(@"[+\-Xx\/]").IsMatch(operation.ToString());
        }

        private bool CheckForNullValues()
        {
            return string.IsNullOrEmpty(FirstOperand) && string.IsNullOrEmpty(SecondOperand) && string.IsNullOrEmpty(Operation);
        }

        private string CalculateAnswer(string FirstOperand, string SecondOperand , string Operation)
        {
            float.TryParse(FirstOperand, out float firstNumber);
            float.TryParse(SecondOperand, out float secondNumber);

            switch (Operation)
            {
                case "+":
                    return (firstNumber + secondNumber).ToString();
                case "-":
                    return (firstNumber - secondNumber).ToString();
                case "X":
                case "x":
                    return (firstNumber * secondNumber).ToString();
                case "/":
                    if (secondNumber == 0)
                        return ErrorCode;
                    return (firstNumber / secondNumber).ToString();
            }

            return ErrorCode;
        }

        private string ToggleSign(string Operand)
        {
            float.TryParse(Operand, out float number);

            return (-1 * number).ToString();
        }
    }
}
