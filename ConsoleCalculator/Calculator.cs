using System;
using System.Text.RegularExpressions;

namespace ConsoleCalculator
{
    public class Calculator
    {
        const string ErrorCode = "-E-";
        const string InitailValue = "0";

        string firstOperand = null;
        string secondOperand = null;
        string arthimaticOperator = null;

        Helper helper = new Helper();
        Validation validate = new Validation();

        public Calculator()
        {
            Console.WriteLine("0");
        }

        public string SendKeyPress(char key)
        {

            switch (key)
            {
                case var number when validate.IsNumericKey(key) == true:
                    if (arthimaticOperator == null)
                        return firstOperand = helper.AssignOperand(firstOperand, key);
                    else
                        return secondOperand = helper.AssignOperand(secondOperand, key);

                case var res when validate.IsArithmaticOperationKey(key) == true:
                    if (checkNull())
                        return calculate(key);
                    else
                    {
                        arthimaticOperator = key.ToString();
                        return firstOperand;
                    }

                case var res when validate.IsAlphabetKey(key) == true:
                    return firstOperand;

                case '.':
                    if (arthimaticOperator == null)
                        return firstOperand = helper.AssignDecimalToOperand(firstOperand, key);
                    else
                        return secondOperand = helper.AssignDecimalToOperand(secondOperand, key);

                case '=':
                    return calculate(key);


                case 's':
                case 'S':
                    return (arthimaticOperator == null)
                   ? firstOperand = helper.toggleSign(firstOperand)
                   : secondOperand = helper.toggleSign(secondOperand);

                case 'c':
                case 'C':
                    resetCalculator();
                    return InitailValue;

                default:
                    resetCalculator();
                    return ErrorCode;
            }
        }


        private bool checkNull()
        {
            return firstOperand != null && 
                   secondOperand != null && 
                   arthimaticOperator != null;
        }

      
        private string calculate(char key)
        {
            if (checkNull())
            {
                firstOperand = Calculations(firstOperand, secondOperand, arthimaticOperator);
                secondOperand = null;
                arthimaticOperator = key.ToString();
                return firstOperand;
            }
            else
                return firstOperand;
            
        }

        private void resetCalculator()
        {
            firstOperand = null;
            secondOperand = null;
            arthimaticOperator = null;
        }

        private string Calculations(string FirstOperand, string SecondOperand, string Operation)
        {
            switch (Operation)
            {
                case "+":
                    return (double.Parse(FirstOperand) + double.Parse(SecondOperand)).ToString();

                case "-":
                    return (double.Parse(FirstOperand) - double.Parse(SecondOperand)).ToString();
                case "X":
                case "x":
                    return (double.Parse(FirstOperand) * double.Parse(SecondOperand)).ToString();
                case "/":
                    if (double.Parse(SecondOperand) == 0)
                        return ErrorCode;
                    return (double.Parse(FirstOperand) / double.Parse(SecondOperand)).ToString();
            }

            return ErrorCode;
        }


    }
}
