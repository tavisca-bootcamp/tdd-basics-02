using System;
using System.Linq;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string firstOperand;
        public string secondOperand;
        public string result;
        public char lastOperator;
        public bool validOperand;
        public bool validOperator;


        public Calculator()
        {
            firstOperand = null;
            secondOperand = null;
            result = "";
            lastOperator = 'N';
            validOperand = false;
            validOperator = false;
        }        

        public string SendKeyPress(char key)
        {
            // Add your implementation here.
                        
            // to check if key is valid or not
            switch(key){
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
                case '.':
                    validOperand = IsValidOperand(key);                        
                    break;

                case '+':
                case '-':
                case 'x':
                case 'X':
                case '/':
                    validOperator = IsValidOperator(key);
                    lastOperator = key;
                    break;
                 
                case '=':
                case 'c':
                case 'C':
                case 's':
                case 'S':
                    validOperator = IsValidOperator(key);                    
                    break;    
            }
            // obtaining first operand
            if(validOperator == false && validOperand == true){
                firstOperand += key;
                result = firstOperand;
            }
                
            // obtaining second operand
            if(validOperator == true && validOperand == true){
                if(key != 'c' && key != 'C' && key != 's' && key != 'S'){
                    secondOperand += key;
                    result = secondOperand;
                }
                    
                else
                    result = "-E-";
            }
            //obtaining decimal numbers
            if(key == '.'){
                if(validOperator == false){
                    firstOperand = DecimalPoint(firstOperand);
                    result = firstOperand;
                }
                    
                else{
                    secondOperand = DecimalPoint(secondOperand);
                    result = secondOperand;
                }
                    
            }
            
            if(key == 'c' || key == 'C')
                result = ClearConsole();
            if(key == 's' || key == 'S'){

                // change sign of first operand as operator is not pressed yet nor second operand
                if(secondOperand.Equals(null) && validOperator == false){
                    firstOperand = ToggleSign(firstOperand);
                    result = firstOperand;
                }
                    
                // change sign of second operand
                else{
                    secondOperand = ToggleSign(secondOperand);
                    result = secondOperand;
                }
                    
            }
            if(!string.Equals(firstOperand, null) && !string.Equals(secondOperand, null) && key == '=' ){

                if(lastOperator == '+') // Addition
                    result = Add(firstOperand, secondOperand);
                if(lastOperator == '-')  // Subtraction
                    result = Subtract(firstOperand, secondOperand);
                if(lastOperator == 'x' || lastOperator == 'X')  // Multiplication
                    result = Multiply(firstOperand, secondOperand);
                if(lastOperator == '/')  //Division
                    result = Divide(firstOperand, secondOperand);
                
            }

            /*if (result.Contains('.'))
            {
                string substring = result.Substring(result.IndexOf('.')+1);
                int checkZero = Convert.ToInt32(substring);
                if(checkZero == 0)
                    result = result.Substring(0, result.IndexOf('.'));                 
            }*/
                

            return result;

           // throw new NotImplementedException();
        }

        public bool IsValidOperator(char key){

            char[] validOperator = {'+','-','/','=','x','X','c','C','s','S'};
            //if(validOperator.Contains(key) == true)
            return validOperator.Contains(key);
           // else
             //   return false;

        }
        
        public bool IsValidOperand(char key){
            char[] validOperand = {'0','1','2','3','4','5','6','7','8','9'};
            //if(validOperand.Contains(key) == true)
                return validOperand.Contains(key);
            //else
              //  return false;
        }

        public string DecimalPoint(string operand){
            // adding decimal point when no numeric value is present and . key is pressed
            if(string.Equals(operand, null))
                operand="0.";
            else{
                // adding decimal point when numeric value is present
                if(!operand.Contains('.') && Convert.ToInt32(operand) != 0)
                    operand +=".";
                // ignoring multiple decimal points and ignoring multiple zeroes before decimal point
                if (operand.Contains('.')) {
                    if(Convert.ToDouble(operand) == 0.0)
                    operand = "0.";
                }
                
            }
                return operand;                         
        }

        public string Add(string operand1, string operand2){
            // addition of two numerics
            double sum = (Convert.ToDouble(operand1)) + (Convert.ToDouble(operand2));
            return sum.ToString();
        }

        public string Subtract(string operand1, string operand2){
            // subtraction of two numerics
            double difference = Convert.ToDouble(operand1) - Convert.ToDouble(operand2);
            return difference.ToString();
        }

        public string Multiply(string operand1, string operand2){
            // multiplication of two numerics
            double product = Convert.ToDouble(operand1) * Convert.ToDouble(operand2);
            return product.ToString();
        }

        public string Divide(string operand1, string operand2){
            // division of two numerics
            double quotient;
            try
            {
                if (Convert.ToDouble(operand2) == 0.0)
                    throw new DivideByZeroException();
                else
                    quotient = Convert.ToDouble(operand1) / Convert.ToDouble(operand2);
            }
            catch(DivideByZeroException){
                return "-E-";
            }
            return quotient.ToString();
        }

        public string ToggleSign(string operand1){
            return (-1 * (Convert.ToDouble(operand1))).ToString();
        }

        public string ClearConsole(){
            return "0";        
        }                     
    }
}


