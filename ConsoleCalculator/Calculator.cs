using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string display="";
        private float result=float.MinValue;
        private char prevoperator='?';
        private int flag=0;
        public string SendKeyPress(char key)
        {
            // Add your implementation here.
            switch(key)
            {
                case 's':
                case 'S':   int temp;
                            if(int.TryParse(display,out temp)==true)
                                display=(-temp).ToString();
                            else
                                display=(-float.Parse(display)).ToString();
                            return display;
                
                case 'c':
                case 'C':   display="";
                            result=float.MinValue;
                            flag=0;
                            return "0";
                
                case '0':   if(!display.Equals("0"))
                                display+=key;
                            return display;
                
                case '.':   int t;
                            if(int.TryParse(display,out t)==true)
                                display+=key;
                            return display;
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':   display+=key;
                            return display;
                case '+':   if(flag==0 && prevoperator!='?')
                            {   
                                flag=1;
                                SendKeyPress(prevoperator);
                                prevoperator='+';
                            }
                            else
                            {
                                if(result!=float.MinValue)
                                    result+=float.Parse(display);    
                                else
                                    result=float.Parse(display);
                                prevoperator='+';
                                display="";
                                flag=0;
                            }
                            return result.ToString();
                case '-':   if(flag==0 && prevoperator!='?')
                            {   
                                flag=1;
                                SendKeyPress(prevoperator);
                                prevoperator='-';
                            }
                            else
                            {
                                if(result!=float.MinValue)
                                    result-=float.Parse(display);    
                                else
                                result=float.Parse(display);
                                prevoperator='-';
                                display="";
                                flag=0;
                            }
                            return result.ToString();            
                case 'X':
                case 'x':   if(flag==0 && prevoperator!='?')
                            {  
                                flag=1;
                                SendKeyPress(prevoperator);
                                prevoperator='x';
                            }
                            else
                            {
                                if(result!=float.MinValue)
                                    result*=float.Parse(display);    
                                else
                                    result=float.Parse(display);
                            prevoperator='x';
                            display="";
                            flag=0;
                            }
                            return result.ToString();
                case '/':   if(flag==0 && prevoperator!='?')
                            {   flag=1;
                                if(SendKeyPress(prevoperator)=="-E-")
                                    return "-E-";
                                prevoperator='/';
                            }
                            else
                            {
                                if(result!=float.MinValue)
                                {
                                    if(float.Parse(display)!=0)
                                        result/=float.Parse(display);
                                    else
                                        return "-E-";
                                }    
                                else
                                    result=float.Parse(display);
                                prevoperator='/';
                                display="";
                                flag=0;
                            }
                            return result.ToString();
                case '=': if(display=="")
                            display=result.ToString();
                          return SendKeyPress(prevoperator);
                          
                                                   
                default : return display;
            }
        }
    }
}
