using System;
using System.Collections;

namespace ConsoleCalculator

{
        public class Calculator
    {
        string result="";
        char op='#';
        int temp;
        double ans=double.MinValue;
        int Flag=0;
        public string operation(char key)
        {
            if(key=='+')
            {
                if(Flag==0&&op!='#')
                {
                    Flag=1;
                    SendKeyPress(op);
                    op='+';
                }
                else
                {
                    if(ans!=double.MinValue)
                        ans+=double.Parse(result);
                    
                    else
                    ans =double.Parse(result);
                    op='+';
                    Flag=0;
                    result="";
                    

                }
            }
            else if(key=='-')
            {
                 if(Flag==0&&op!='#')
                {
                    Flag=1;
                    SendKeyPress(op);
                    op='-';
                }
                else
                {
                    if(ans!=double.MinValue)
                        ans-=double.Parse(result);
                    
                    else
                    ans =double.Parse(result);
                    op='-';
                    Flag=0;
                    result="";
                    
                 }
            }
            else if(key=='x'||key=='X')
            {
                 if(Flag==0&&op!='#')
                {
                    Flag=1;
                    SendKeyPress(op);
                    op='x';
                }
                else
                {
                    if(ans!=double.MinValue)
                        ans*=double.Parse(result);
                    
                    else
                    ans =double.Parse(result);
                    op='x';
                    Flag=0;
                    result="";
                    
                }
            }
            else if(key=='/')
            {
                 if(Flag==0&&op!='#')
                {
                    Flag=1;
                    if(SendKeyPress(op)=="-E-")
                    {
                        return "-E-";
                    }
                    op='/';
                }
                else
                {
                    if(ans!=double.MinValue)
                    {
                        if(double.Parse(result)!=0)
                        {
                            ans/=double.Parse(result);

                        }
                        else
                            return "-E-";
                    }
                    else
                    ans =double.Parse(result);
                    op='/';
                    Flag=0;
                    result="";
                    
            }
            }



            return result.ToString();
        }
        public string DigitCalc(char key)
        {
            if(!result.Equals("0"))
               result+=key;
            return result;
        }
        public string Reset(char key)
        {
            result="";
            ans=double.MinValue;
            Flag=0;
                          
            return "0";

        }
        public string ChangeSign(char key)
        {
            if(int.TryParse(result,out temp))
                result=(-1*temp).ToString();
            else 
                result=(-1*double.Parse(result)).ToString();
                        
            return result;
        }
        public string DoubleValue(char key)
        {
            if(int.TryParse(result,out temp))
                result+=key;
                            
            return result;
        }
        public string CalculateValue(char key)
        {
            if(result=="")
                result=ans.ToString();
                           
            return SendKeyPress(op);
        }
        public string SendKeyPress(char key)
        {
           
            switch(key)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':return DigitCalc(key);

                case 's':
                case 'S':  return ChangeSign(key);

                case 'c':
                case 'C': return Reset(key);

                case '.': return DoubleValue(key);

                case '+':
                case '-':
                case 'x':
                case 'X':
                case '/':
                          return operation(key);
                        
                case '=': return CalculateValue(key);
                            
                         
                default :
                        return result;

            }
        }
        
            public string CalculateExpression(string exp)
            {
                string answer="";
                foreach(char c in exp)
                {
                    answer+=SendKeyPress(c);

                }
                return  answer;
            }
            
        }
}
