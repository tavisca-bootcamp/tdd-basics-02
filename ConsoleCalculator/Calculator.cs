using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private HashSet<char> possibleNumber;
        private HashSet<char> possibleOperator;
        private decimal firstNumber;
        private decimal secodNumber;
        private char inputOperator;
        private decimal result;
        private bool isDecimalEntry;

        public Calculator()
        {
            possibleNumber = new HashSet<char>{'0','1','2','3','4','5','6','7','8','9'};
            possibleOperator = new HashSet<char>{'-','+','*','/','='};
            firstNumber = 0;
            secodNumber = 0;
            inputOperator = 'n';
            result = 0;
            isDecimalEntry = true;
        }
        public string SendKeyPress(char key)
        {
           if(possibleNumber.Contains(key))
               return NumberPressed(key);
           
           else if(key.Equals('.'))
                return DotPressed();
           
           else if(possibleOperator.Contains(key))
                return OperatorPressed(key);
           
           else if(key.Equals('c')){
               SetVariablesNull();
               return "0";
           }
           else if(key.Equals('s'))
               return SignButtonPressed();

           return "";
        }

        private string NumberPressed(char key)
        {
            if(isDecimalEntry)
                return DecimalEntry(key);
            else
                return FloatEntry(key);
        }

        private string DotPressed()
        {
           isDecimalEntry = false;
            if(inputOperator.Equals('n'))
                return firstNumber.ToString() + ".";
            else
                return secodNumber.ToString() + ".";
        }

        private string SignButtonPressed()
        {
            if(inputOperator.Equals('n')){
                firstNumber = -firstNumber;
                return firstNumber.ToString();
            }
            else{
                secodNumber = -secodNumber;
                return secodNumber.ToString();
            }
        }

        private string OperatorPressed(char key)
        {
            string returningNumber = "";

            if(key.Equals('='))
                return calculate();

            //if this condition evalutes to true it means that the operator has been pressed just after the firstNumber and the display should display the firstNumber
            if(result == 0 && secodNumber == 0)
                returningNumber =  firstNumber.ToString();
            else // the secondNumber has also been inputted and the operator has been inputted in the previos call and now the result needs to be calculated 
                returningNumber =  calculate();
            
            inputOperator = key;
            isDecimalEntry = true;
            return returningNumber;
        }

        private string FloatEntry(char key)
        {
            if(inputOperator.Equals('n'))
            {
                if(firstNumber.ToString().Contains("."))
                    firstNumber = (decimal.Parse(firstNumber.ToString() + key.ToString()));
                else
                    firstNumber = decimal.Parse(firstNumber.ToString() + "." + key.ToString());
                return firstNumber.ToString();
            }
            else{
                if(secodNumber.ToString().Contains("."))
                    secodNumber = decimal.Parse(secodNumber.ToString() + key.ToString());
                else
                    secodNumber = decimal.Parse(secodNumber.ToString() + "." + key.ToString());
                return secodNumber.ToString();
            }
        }

        private string DecimalEntry(char key)
        {
            if(inputOperator.Equals('n'))
            {
                firstNumber = firstNumber * 10;
                firstNumber += int.Parse(key.ToString());
                return firstNumber.ToString();
            }
            else{
                secodNumber = secodNumber * 10;
                secodNumber += int.Parse(key.ToString());
                return secodNumber.ToString();
            }
        }

        public void SetVariablesNull(){
            firstNumber = result;
            secodNumber = 0;
            result = 0;
            inputOperator = 'n';
            isDecimalEntry = true;
    }


        private string calculate()
        {
            switch(inputOperator){
                case '+':
                {
                    result = firstNumber + secodNumber;
                    break;
                }
                case '-':
                {
                    result = firstNumber - secodNumber;
                    break;
                }
                case '*':
                {
                    result = firstNumber * secodNumber;
                    break;
                }
                case '/':
                {
                    if(secodNumber == 0)
                        return "-E-";
                    result = Math.Round(firstNumber / secodNumber,4);
                    break;
                }
                case 'n':{
                    result = firstNumber;
                    break;
                }
            }
            SetVariablesNull();
            return firstNumber.ToString();
    } 
    
      }


}
