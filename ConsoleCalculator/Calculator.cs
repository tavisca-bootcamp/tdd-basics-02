using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private char currentOperator = '\0'; //Cureent Operation Operator
	    private string store = "0"; //Value to be stored in Queue
        private string currentValue = "0"; //Current Value on which operation is to be performed
	    private Queue<int> value_store = new Queue<int>(); //To store the output after operation

        public string SendKeyPress(char key)
        {
            //For cases to display when the key is anything other than Operator.
		    if(key != '+' && key !='-' && key !='x' && key !='X' && key !='/' && key != '=' && key != 'c' && key != 'C' && key != 's' && key != 'S')
		    {
                //When the Display is 0 and the key entered is also 0; Used to avoid concatenation like 00 
                if(currentValue == "0" && key == '0')
                        currentValue = "0";
                //For Decimal Format to avoid multiple concatenation of Decimal(.)
                else
                {
                
                    if(key == '.')
                    {
                        if(currentValue.Contains("."))
                            return currentValue;
                        else
                        {
                            currentValue = currentValue+key;
                            store = store + key;

                        }
                    }
                    //For other Digit inputs
                    else
                    {
                        currentValue = store + key;
                        store = store + key;
                    }
                }
		    }
            //When C || c is entered to RESET the calculator
		    else if(key == 'c' || key == 'C')
		    {
                currentOperator = '\0';
                store = "";
                value_store.Clear();
                currentValue = "0";
                
		    }
            //When Operator is entered; To perfrom operation on the operands
            else
            {
                //When there is no operator entered so operand needs to be stored in the Queue
                if (currentOperator == '\0')
                {
                    currentOperator = key;
                    currentValue = store;
                    int currentValueInt;
                    bool ifSuccess = int.TryParse(store, out currentValueInt);
                    store = "";
                    value_store.Enqueue(currentValueInt);
                }
                //Now when the value is stored and an Operator is received
                else if (value_store.Count == 1)
                {
                    int previousValue = value_store.Dequeue(); //Removed value from queue to perform operation on it
                    int presentValue, newValue;
                    bool ifSuccess = int.TryParse(store, out presentValue);
                    string ans = "";

                    //When we have received '='; we directly need to evaluate the operation
                    if(key == '=')
                        ans = PerformCalculation(previousValue, presentValue, currentOperator);
                        
                    //When we receive any other operator so we need to consecutively keep on performing those operation
                    else
                        ans = PerformCalculation(previousValue, presentValue, key);

                    currentValue = ans;
                    bool ifTrue = int.TryParse(ans, out newValue);
                    value_store.Enqueue(newValue);
                    store = "";
                }
            }
		return currentValue;
        }

        public string PerformCalculation(int previousValue, int presentValue, char key)
        {
            int result = 0;
            switch(key)
            {
                case '+':
                    result = previousValue+presentValue;
                    return result.ToString();
                case '-':
                    result = previousValue-presentValue;
                    return result.ToString();
                case 'x':
                case 'X':
                    result = previousValue*presentValue;
                    return result.ToString();
                case '/':
                    if(presentValue == 0)
                        return "-E-";
                    else
                    {
                        double resultDivide = (double)previousValue / (double)presentValue;
                        return resultDivide.ToString();
                    }
                case 's':
                case 'S':
                    result = previousValue + (presentValue * -1);
                    return result.ToString();  
            }
            return "-E-";
        }
    }
}
