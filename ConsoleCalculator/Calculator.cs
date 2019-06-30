using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private List<string> operandsList;
        private char operatorSign;

        public Calculator()
        {
            operandsList = new List<string>(){"0"};
            operatorSign = '\0';
        }

        public string SendKeyPress(char key)
        {
            //If user entered invalid character
            if(!"0123456789.-+x/sc=XCS".Contains(key.ToString()))
                return this.operandsList.Last();
            else
                return PerformCalculation(key);
        }

        public String PerformCalculation(char key)
        {
            try
            {
                if(PressedDigitOrPeriod(key))
                {
                    AppendDigitToDisplay(key);
                }
                else if(PressedSignToggle(key))
                {
                    ToggleSign();
                }
                else if(PressedClear(key))
                {
                    ClearCurrentOperands();
                }
                else if(PressedEqualsTo(key))
                {
                    string result = EvaluateResult();
                    ClearCurrentOperands();
                    PushToOperandsList(result);  
                }
                //If key pressed is an operator
                else
                {
                    //If there is already an operator, then evaluate current expression
                    //and store result in current operand
                    if(this.operatorSign != '\0')
                    {
                        string result = EvaluateResult();
                        ClearCurrentOperands();
                        PushToOperandsList(result);
                    }
                    //Store the new operator and move to next operand which is initially 0
                    this.operatorSign = key;
                    this.operandsList.Add("0");
                    //Since entered key is operand, return the first operand
                    return operandsList.First();
                }
            }
            catch(ArithmeticException)
            {
                ClearCurrentOperands();
                return "-E-";
            }
            //Return recently stored operand.
            return operandsList.Last();
        }

        public bool PressedDigitOrPeriod(char key)
        {
            return Char.IsDigit(key) || key == '.';
        }

        public bool PressedSignToggle(char key)
        {
            return key == 's' || key == 'S';
        }

        public bool PressedClear(char key)
        {
            return key == 'c' || key == 'C';
        }

        public bool PressedEqualsTo(char key)
        {
            return key == '=';
        }

        public void AppendDigitToDisplay(char digit)
        {
            String currentNumber = this.operandsList.Last();
            //If key pressed is . and there is a . already present then ignore the key
            if(digit == '.' && currentNumber.Contains("."))
                return;
            //If current number is 0, then key is replaced with current number
            if(digit != '.' && currentNumber == "0")
                PushToOperandsList(digit.ToString());
            else
                PushToOperandsList(currentNumber + digit.ToString());
        }


        public void PushToOperandsList(string result)
        {
            operandsList[this.operandsList.Count - 1] = result;
        }

        public void ToggleSign()
        {
            string currentNumber = this.operandsList.Last();
            //Cannot toggle sign for 0.
            if(currentNumber == "0")
                return;
            //If number starts with '-', remove it.
            if(currentNumber[0] == '-')
                PushToOperandsList(currentNumber.Substring(1));
            //Else append "-" to the number.
            else
                PushToOperandsList("-" + currentNumber);
        }

        public void ClearCurrentOperands()
        {
            this.operandsList.Clear();
            this.operandsList.Add("0");
            this.operatorSign = '\0';
        }

        public string EvaluateResult()
        {
            float operand1 = float.Parse(operandsList[0]);
            float operand2 = float.Parse(operandsList[1]);
            switch(operatorSign)
            {
                case '+':
                    return Convert.ToString(operand1 + operand2);

                case '-':
                    return Convert.ToString(operand1 - operand2);

                case '/':
                    if(operand2 == 0)
                        throw new ArithmeticException();
                    return Convert.ToString(operand1 / operand2);

                case 'x':
                case 'X':
                    return Convert.ToString(operand1 * operand2);

                case '\0':
                    return operandsList.Last();
            }
            return "-E-";
        }
    }
}
