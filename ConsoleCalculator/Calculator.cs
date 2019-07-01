using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private char currentOperator='\0';
	    private string store="0";
        private string currentValue="0";
	    private Queue<int> value_store = new Queue<int>(); 

        public string SendKeyPress(char key)
        {
            
		    if(key != '+' && key !='-' && key !='x' && key !='X' && key !='/' && key != '=' && key != 'c' && key != 'C' && key != 's' && key != 'S')
		    {  
                if(currentValue=="0" && key =='0')
                        currentValue="0";
                else
                {
                    if(key=='.')
                    {
                        if(currentValue.Contains("."))
                            return currentValue;
                        else
                        {
                            currentValue=currentValue+key;
                            store=store+key;

                        }
                    }
                    else
                    {
                        currentValue=store+key;
                        store=store+key;
                    }
                }
		    }
		    else if(key == 'c' || key == 'C')
		    {
                currentOperator='\0';
                store="";
                value_store.Clear();
                currentValue="0";
                
		    }
            else
            {
                if (currentOperator == '\0')
                {
                    currentOperator=key;
                    currentValue=store;
                    int currentValueInt;
                    bool ifSuccess = int.TryParse(store, out currentValueInt);
                    store="";
                    value_store.Enqueue(currentValueInt);
                }
                else if (value_store.Count==1)
                {
                    int previousValue=value_store.Dequeue();
                    int presentValue, newValue;
                    bool ifSuccess = int.TryParse(store, out presentValue);
                    string ans="";
                    if(key=='=')
                        ans=performCalculation(previousValue, presentValue, currentOperator);
                    else
                        ans=performCalculation(previousValue, presentValue, key);
                    currentValue=ans;
                    bool ifTrue=int.TryParse(ans, out newValue);
                    value_store.Enqueue(newValue);
                    store="";
                }
            }
		return currentValue;
        }

        public string performCalculation(int previousValue, int presentValue, char key)
        {
            int result=0;
            switch(key)
            {
                case '+':
                    result=previousValue+presentValue;
                    return result.ToString();
                case '-':
                    result=previousValue-presentValue;
                    return result.ToString();
                case 'x':
                case 'X':
                    result=previousValue*presentValue;
                    return result.ToString();
                case '/':
                    if(presentValue==0)
                        return "-E-";
                    else
                    {
                        double resultDivide=(double)previousValue/(double)presentValue;
                        return resultDivide.ToString();
                    }
                case 's':
                case 'S':
                    result=previousValue+(presentValue*-1);
                    return result.ToString();  
            }
            return "-E-";
        }
    }
}
