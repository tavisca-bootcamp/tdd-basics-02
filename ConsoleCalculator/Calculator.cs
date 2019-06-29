using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private HashSet<char> possibleNumber;
        private HashSet<char> possibleOperator;
        private HashSet<char> possibleSpecialChar;
        private float firstNumber;
        private float secodNumber;
        private char inputOperator;
        private float result;
        private bool isDecimalEntry;

        public Calculator()
        {
            possibleNumber = new HashSet<char>{'0','1','2','3','4','5','6','7','8','9'};
            possibleOperator = new HashSet<char>{'-','+','*','/','='};
            possibleSpecialChar = new HashSet<char>{'s','c'};
            firstNumber = 0;
            secodNumber = 0;
            inputOperator = 'n';
            result = 0;
            isDecimalEntry = true;
        }
        public string SendKeyPress(char key)
        {
           if(possibleNumber.Contains(key)){
               if(isDecimalEntry){
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
               else{
                    if(inputOperator.Equals('n'))
                    {
                        float number = int.Parse(key.ToString());
                        number /= 10;
                        firstNumber += number;
                        return firstNumber.ToString();
                    }
                    else{
                        float number = int.Parse(key.ToString());
                        number /= 10;
                        secodNumber += number;
                        return secodNumber.ToString();
                    }
               }
           }
           else if(key.Equals('.')){
                   isDecimalEntry = false;
                   if(inputOperator.Equals('n'))
                        return firstNumber.ToString() + ".";
                    else
                        return secodNumber.ToString() + ".";
           }
           else if(possibleOperator.Contains(key)){
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
           else if(key.Equals('c')){
               firstNumber = 0;
               secodNumber = 0;
               inputOperator = 'n';
               result = 0;

               return "0";
           }
           else if(key.Equals('s')){
               if(inputOperator.Equals('n')){
                   firstNumber = -firstNumber;
                   return firstNumber.ToString();
               }
               else{
                   secodNumber = -secodNumber;
                   return secodNumber.ToString();
               }
           }
           

           return "";
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
                    result = firstNumber / secodNumber;
                    break;
                }
                case 'n':{
                    result = firstNumber;
                    break;
                }
            }
            
            firstNumber = result;
            secodNumber = 0;
            result = 0;
            return firstNumber.ToString();
    }   }
}
