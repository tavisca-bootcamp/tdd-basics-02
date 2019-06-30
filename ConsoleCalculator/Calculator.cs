using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        int resultInt = 0;
        int numberInt = 0;
        decimal resultDecimal = 0;
        decimal numberDecimal = 0;
        string operand = "";
        bool isDecimal = false;
        string checkOperator = "";

        public string SendKeyPress(char key)
        {
            if(IsNumber(key) && !isDecimal){
                operand += ""+key;
            }
            else if(IsNumber(key) && isDecimal){
                if(operand.Equals("")){
                    operand = "0.";
                }
                else{
                    operand += key;
                }
            }
            else if(IsOperation(key)){
                if(!operand.Equals("") && !isDecimal){
                    numberInt = Int32.Parse(operand);
                }
                else if(!operand.Equals("") && isDecimal){
                    numberDecimal = Decimal.Parse(operand);
                }
                
                try{
                    switch(key){
                        case '+': if(!isDecimal) Addition(numberInt);
                                else Addition(numberDecimal);
                                break;
                        case '-': if(!isDecimal) Subtraction(numberInt);
                                else Subtraction(numberDecimal);
                                break;
                        case 'x': case 'X': if(!isDecimal) Multiplication(numberInt);
                                else Multiplication(numberDecimal);
                                break;
                        case '/': if(!isDecimal) Division(numberInt);
                                else Division(numberDecimal);
                                break;
                        case '.': isDecimal = true;
                                operand += ".";
                                break;
                        case 's': case 'S': ToggleSign();
                                break;
                        case 'c': case 'C': ResetAll();
                                break;
                        case '=': if(isDecimal){
                                        return ""+numberDecimal;
                                    }
                                    return ""+numberDecimal;
                        //default : break;
                        
                    }
                }catch{
                    return "-E-";
                }
                
            }
            if(isDecimal){
                    return ""+numberDecimal;
                }
                return ""+numberDecimal;
        }

        bool IsNumber(char input){
            try{
                int inputKey = input - '0';
                if(inputKey < 10 && inputKey >= 0){
                    return true;
                }
            }catch{
                
            }
            
            return false;
        }

        bool IsOperation(char input){
            if(input=='+'||input=='-'||input=='x'||input=='/'||input=='.'||
                input=='s'|| input=='c'||input=='='||input=='X'||input=='C'||input=='S'){
                    return true;
            }
            return false;
        }

        /*bool NotRepeatingOperation(char input){
            if(input=='+'||input=='-'||input=='x'||input=='/'||input=='.'||
                input=='s'|| input=='c'||input=='='||input=='X'||input=='C'||input=='S'){
                    return true;
            }
        }*/
        void Addition(int  operand){
            resultInt += operand;
        }
        void Subtraction(int operand){
            resultInt -= operand;
        }
        void Multiplication(int operand){
            resultInt *= operand;
        }
        void Division(int operand){
            resultInt /= operand;
        }
        
        void Addition(decimal operand){
            resultDecimal += operand;
        }
        void Subtraction(decimal operand){
            resultDecimal -= operand;
        }
        void Multiplication(decimal operand){
            resultDecimal *= operand;
        }
        void Division(decimal operand){
            resultDecimal /= operand;
        }

        void ToggleSign(){
            resultInt *= -1;
            resultDecimal *= -1;
        }
        void ResetAll(){
            resultInt = 0;
            resultDecimal = 0;
            numberInt = 0;
            numberDecimal = 0;
            operand = "";
            isDecimal = false;
            checkOperator = "";
        }
        /* void ReturnResult(){

        }*/
    }
}
