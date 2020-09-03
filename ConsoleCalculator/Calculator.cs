using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string FirstNumber = "0";
        public string SecondNumber = "";
        public bool isDecimal = false;
        public char Operator = '+';
        
        //Basic Arrithmetic Operations
        private void basicOperation()
        {
           
            switch (Operator)
            {
                //Addition of Two Numbers
                case '+':
                    FirstNumber = (Double.Parse(FirstNumber) + Double.Parse(SecondNumber)).ToString();
                    break;
                //Substration of Two Numbers
                case '-':
                    FirstNumber = (Double.Parse(FirstNumber) - Double.Parse(SecondNumber)).ToString();
                    break;

                //Multipication of Two Numbers
                case 'x':
                case 'X':
                    FirstNumber = (Double.Parse(FirstNumber) * Double.Parse(SecondNumber)).ToString();
                    break;
                //Division of Two Numbers
                case '/':
                    if (SecondNumber == "0") //Dividing by 0
                        throw new DivideByZeroException();
                    FirstNumber = (Double.Parse(FirstNumber) / Double.Parse(SecondNumber)).ToString();
                    break;

            }
        }
        //Clear or Reset the calculator
        private void clearConsole()
        {
            FirstNumber = "0";
            SecondNumber = "";
            isDecimal = false;
            Operator = '+';

        }

        //To change the Sign of Number
        private void toggleSign()
        {
            double Number = -Double.Parse(SecondNumber);
            SecondNumber = Number.ToString();
        }
        public string SendKeyPress(char key)
        {
            //Result of Any equation Generated is Stored in Answer
            string Answer = "0";

            try
            {
                 if (ValidNumber(key)) //Check whether number is Valid Or not
                {
                    if (key == '0' && !isDecimal) //for zeroes before decimal
                        SecondNumber = Int32.Parse(SecondNumber + key).ToString();
                    else
                        SecondNumber += key;
                    Answer = SecondNumber;
                }
                else if (ValidOperator(key)) //Check whether operator is valid or not
                {
                    isDecimal = false; //if no occurence of decimal is there
                    basicOperation();
                    Answer = FirstNumber;
                    if (key != '=') //if key is not "Equals" sign then for next iteration operator will be choosen as key
                        Operator = key;
                    SecondNumber = "";
                }
                else if (key == 'C' || key == 'c') // To clear the console by pressing c
                {
                    clearConsole();
                }
                else if (key == 'S' || key == 's') //To change the sign of number
                {
                    toggleSign();
                    Answer = SecondNumber;
                }
                else if (key == '.' && !isDecimal) //if first time occurence of decimal then its ok otherwise will not run  
                {                                  //so giving number with only with one decimal operator
                    SecondNumber += key;
                    isDecimal = true;
                    Answer = SecondNumber;
                }
                

            }
            catch (DivideByZeroException e) //divide by zero exception handled in basic opertion method
            {
                Answer = "-E-";
            }

            return Answer;
        }
        

        private bool ValidNumber(char key) // checks whether the key entered is between numbers 0 to 9
        {
            if (key >= '0' && key <= '9')
            {
                return true;
            }
            return false;
        }

        private bool ValidOperator(char key) // checks whether the key entered is valid operator or not
        {

            if (key == '+' || key == '-' || key == 'x' || key == 'X' || key == '/' || key == '=')
            {
                return true;
            }
            return false;
        }
 
    }
}
