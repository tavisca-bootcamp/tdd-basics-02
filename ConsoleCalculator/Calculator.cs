using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        String displayResult = "0";
        bool IsOperation(char input){
            if(input=='+'||input=='-'||input=='x'||input=='/'|| input=='s'|| 
            input=='c'||input=='='||input=='X'||input=='C'||input=='S'){
                    return true;
            }
            return false;
        }

        bool IsNumber(char input){
            try{
                int inputKey = input - '0';
                if(inputKey < 10 && inputKey >= 0){
                    return true;
                }
            }catch{
                return false;
            }
            
            return false;
        }

        public string SendKeyPress(char key)
        {
            isOperationPerformed = false;

            if(IsOperation(key)){
                operator_click(key);
            }

            if (key == '.')
            { 
               if(!displayResult.Contains("."))
                   displayResult = displayResult + key;

            }else if(IsNumber(key)){
                if ((displayResult == "0") || (isOperationPerformed)){
                    if(key != '0')
                        displayResult = ""+key;
                }
                else
                    displayResult = displayResult + key;
            }

            
            return displayResult;
        }

        private void operator_click(char key)
        {

            if (resultValue != 0)
            {
                PerformCalculation();
                operationPerformed = ""+key;
                isOperationPerformed = true;
            }
            else
            {

                operationPerformed = ""+key;
                resultValue = Double.Parse(displayResult);
                isOperationPerformed = true;
            }
        }

        private void ToggleSign()
        {
            resultValue *= -1;
        }

        private void ResetAll()
        {
            displayResult = "0";
            resultValue = 0;
        }

        private void PerformCalculation()
        {
            switch (operationPerformed)
            {
                case "+":
                    displayResult = (resultValue + Double.Parse(displayResult)).ToString();
                    break;
                case "-":
                    displayResult = (resultValue - Double.Parse(displayResult)).ToString();
                    break;
                case "x": case "X":
                    displayResult = (resultValue * Double.Parse(displayResult)).ToString();
                    break;
                case "/":
                    displayResult = (resultValue / Double.Parse(displayResult)).ToString();
                    break;
                case "s": case "S": ToggleSign();
                    break;
                case "c": case "C": ResetAll();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(displayResult);
        }
    }
}
