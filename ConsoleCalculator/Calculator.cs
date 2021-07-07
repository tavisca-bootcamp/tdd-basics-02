using System;
using System.Collections;
using System.Data;

namespace ConsoleCalculator

{
        public class Calculator
    {
        string result="";
        char op='#';
        int temp,ind=0,finalsign=0;
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
                    {
                        
                        ans =double.Parse(result);
                    }
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

            
                return ans.ToString();

          
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
        
             if(finalsign%2!=0)
              {
                  ans*=-1.0;
              }
            if(result==""){
              
             
                result=ans.ToString();
            }
                           
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
        public bool isOperand(char c)
        {
            return (c>='0'&&c<='9');
        }
            public bool isInvalidExpr(string expr)
            {
                if(expr.Length==0)
                return true;
                if(expr[0]=='+'||expr[0]=='/'||expr[0]=='*')
                return true;
                if(expr[expr.Length-1]=='=')
                {
                    if(expr[expr.Length-2]=='+'||expr[expr.Length-2]=='-'||expr[expr.Length-2]=='*'||expr[expr.Length-2]=='/')
                    return true;
                    else
                    return false;
                }
                else
                {
                    if(expr[expr.Length-1]=='C'||expr[expr.Length-1]=='c')
                    return false;
                    else if(isOperand(expr[expr.Length-1]))
                    return false;
                    else
                    return true;
                }
    
               
    
            }
         public bool isOperator(char key)
         {
             if(key=='+'||key=='-'||key=='*'||key=='/')
             return true;
             else
             return false;
         }
            public string CalculateExpression(string exp)
            {
                    string answer="";
                    if(isInvalidExpr(exp))
                    return "-E-";
                    ind=0;
                    foreach(char c in exp)
                    {
                        ind++;
                       if(c=='-'&&ind==1)
                       {
                           finalsign++;
                    
                           continue;
                       }
                       if(c=='-'&&isOperator(exp[ind-1]))
                       {
                           if(isOperand(exp[ind-2]))
                           {
                               goto l;
                           }
                         finalsign++;
                         continue;
                       }
                       l:
                        answer=SendKeyPress(c);
                    }
                    

                    return answer;
            }

            
        }
}
