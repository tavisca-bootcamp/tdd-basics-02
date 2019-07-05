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
            if ((key >= '0' && key <= '9' ) || key == '.')
                currentValue = CalculatorDisplay(key);
		    
		    else if (key == 'c' || key == 'C')
               Reset();
		    
            else
                SetupCalculation(key);
            
		return currentValue;
        }

        public void SetupCalculation(char key)
        {
                
            if (currentOperator == '\0')
            {
                currentOperator = key;
                currentValue = store;
                bool ifSuccess = int.TryParse(store, out int currentValueInt);
                store = "";
                value_store.Enqueue(currentValueInt);
            }
                
            else if (value_store.Count == 1)
            {
                int previousValue = value_store.Dequeue();
                bool ifSuccess = int.TryParse(store, out int presentValue);

                string ans = PerformCalculation(previousValue, presentValue, key == '=' ? currentOperator : key);
                    
                currentValue = ans;
                bool ifTrue = int.TryParse(ans, out int newValue);
                value_store.Enqueue(newValue);
                store = "";
            }
        }

        public string PerformCalculation(int previousValue, int presentValue, char key)
        {
            int result = 0;
            switch (key)
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

        public string CalculatorDisplay(char key)
        {
                if(currentValue == "0" && key == '0')
                        currentValue = "0";
                else
                {
                    if(key == '.')
                    {
                        if(currentValue.Contains("."))
                            return currentValue;
                        else
                        {
                            currentValue = currentValue + key;
                            store = store + key;
                        }
                    }
                    else
                    {
                        currentValue = store + key;
                        store = store + key;
                    }
                }
        return currentValue;
        }

        public void Reset()
        {
            currentOperator = '\0';
            store = "";
            value_store.Clear();
            currentValue = "0";
        }
    }
}
