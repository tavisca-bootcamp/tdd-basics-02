using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string result = "";
        public int ResetFlag = 0;     // reset all flags
        public double left = 0;
        public int OperateFlag = 0;   //let the = operator know what action to be performed (+,-,/,*)
        public int MultiplyFlag = 0;    
        public int DivisionFlag = 0;
        public int SubtractionFlag = 0;
        
         public Calculator()
        {
            Console.WriteLine(0);
        }
        
        

        public string SendKeyPress(char key)
        {
             if(this.validateKey(key))
            {
                if(key=='c'||key=='C')
                {
                    Reset();
                }
                else if(key=='s'|| key=='S')
                {
                    result = this.toggle(result);
                }
                else if((key == '+') || (key == '/') || (key == 'x') || (key == 'X') || (key == '-'))
                {
                    if (key == '+')
                    {
                        OnAddition();
                    }
                    else if (key == '/')
                    {
                            OnDivision();
                    }
                    else if (key == 'x' || key == 'X')
                    {
                        OnMultiplication();
                    }
                    else
                    {
                        OnSubtraction();
                    }
                    result = "";
                }
                else if (key == '=')
                {
                    if (OperateFlag == 1)               //operateflag to know which operation to do when = arrives
                    {
                        if (!result.Equals(""))
                            left += double.Parse(result);
                    }
                    else if (OperateFlag == 2)
                    {
                        if (!result.Equals(""))
                        {
                            if (double.Parse(result) != 0)
                            {
                                if (left != 0)
                                    left /= double.Parse(result);
                                else
                                    return "-E-";
                            }
                            else
                            {
                                return "-E-";
                            }
                        }
                    }
                    else if (OperateFlag == 3)
                    {
                        if (!result.Equals(""))
                            left *= double.Parse(result);
                    }
                    else if (OperateFlag == 4)
                    {
                        if(!result.Equals(""))
                            left -= double.Parse(result);
                    }
                    result = left.ToString();
                    left = 0;                                                  // to calculate even after = sign    2+3=5*2=10;
                }
                else if( (key!='+')&& (key!='/') && (key!='x') && (key!= 'X')&& (key!='-'))
                {
                    if (result.Equals("0") && key != '.')   //to accept '.' after 0 and accept number by removing default 0
                    {
                        result = Char.ToString(key);
                    }
                    else if (result.Contains('.') && key == '.') { }
                    else if (result.Equals("0.") && key == '.')
                    { }                                                        //do nothing
                    else
                        result += Char.ToString(key);
                }
               
            }
            
            return result;
        }
        
         public string toggle(string r)
        {
            if(r[0]!='-')
            {
                return ("-" + r);
            }
            else 
            {
                return (r.Substring(1));
            }
        }
        
        public void OnAddition() {
            if (!result.Equals("")) //to handle + after + i.e 2+3++
            {
                OperateFlag = 1;
                left += double.Parse(result);
            }
        }
        public void OnSubtraction() {
            if (!result.Equals(""))
            {
                OperateFlag = 4;
                if (SubtractionFlag == 0)
                {
                    SubtractionFlag = 1;
                    left = double.Parse(result);
                }
                else
                {
                    left -= double.Parse(result);
                }
            }
        }
        public void OnMultiplication() {
            if (!result.Equals(""))
            {
                OperateFlag = 3;
                if (MultiplyFlag == 0)
                {
                    MultiplyFlag = 1;
                    left = double.Parse(result);
                }
                else
                {
                    left *= double.Parse(result);
                }
            }
        }
        public void OnDivision() {
            if (!result.Equals(""))
            {
                OperateFlag = 2;        // operateflag to know which operation to perform when = arrives
                if (DivisionFlag == 0)  //Division flag to asign result value to variable 'left' initially after first time this if not executed
                {
                    DivisionFlag = 1;
                    left = double.Parse(result);  
                }
                else
                {
                    left /= double.Parse(result);
                }
            }
        }
        public void Reset()
        {
            result = "0";
            left = 0;
            ResetFlag = 1;
            MultiplyFlag = 0;
            DivisionFlag = 0;
            SubtractionFlag = 0;
        }
        public bool validateKey(char c)
        {
           bool result=(c=='0' || c=='1' || c=='2' || c=='3' || c=='4' || c=='5' || c=='6' || c=='7' ||c== '8' || c=='9' || c=='.' || c=='-' || c=='+' || c=='x' || c=='X' || c=='/' || c=='s' || c=='S' || c=='c' || c=='C' || c=='=')? true : false;
            return result;
        }
    }
}
