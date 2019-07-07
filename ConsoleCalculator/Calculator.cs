using System;
using System.Linq;

namespace ConsoleCalculator
{
    public class Calculator
    {
        static string[] Allinputs=new[]{"1","2","3","4","5","6","7","8","9","0",".","s","c","+","-","/","x","="};
        static string keyPressed="", temp="0",temp2="0",opertor="",msg=""; //temps assigned with zero to hold decimal values
        static double A=0,B=0;                                                 //to store operands A and B                                        
        static bool Flag=false;                                            //flag helps to find 2nd operator
        public string SendKeyPress(char key)
        {
            keyPressed=key.ToString();
            ValidateKey(keyPressed);                                    //validity check must be done
        
            if(keyPressed=="c" || keyPressed=="C")                       //reset everything
            {
                A=0;B=0;temp="";temp2="";Flag=false;
                return "0";
            }

            //Extraction of first operand=========================================================================================
            else if(keyPressed!="+" && keyPressed!="-" && keyPressed!="x" && keyPressed!="X" && keyPressed!="/" && Flag==false)                      //extract out first operand
            {  
                if((keyPressed!="s" && keyPressed!="S") && (keyPressed!="c" && keyPressed!="C"))
                {
                    temp=string.Concat(temp,keyPressed);
                    A=Double.Parse(temp);
                }               
                //toogle sign change for first Operand                             
                if(keyPressed=="s" || keyPressed=="S")
                    A=A*(-1);        
                return ($"{A}\n");
            }
               
            //Extraction Of Operator==================================================================================================
            else if(keyPressed=="+" || keyPressed=="-" || keyPressed=="x" || keyPressed=="X"|| keyPressed=="/")                             //extraction of operator
            {
                opertor=keyPressed;
                if(Flag==true)              //for continious calculation,flag tell presence of b
                {
                    try
                    {
                        A=Calculate(A,B,opertor);
                        B=0;
                    }
                    catch(DivideByZeroException)
                    {
                        msg="error";
                        return ("-E-");
                    }
                }
                if(msg=="")                             //do not print if exception occured
                {
                    Flag=true;
                    temp2="";
                    return ($"{A}\n{opertor}\n");
                    } 
            }

            //Extraction of 2nd Operand=========================================================================================
            else if(keyPressed!="=" && Flag==true)               
            {
                if((keyPressed!="s" && keyPressed!="S") && (keyPressed!="c" && keyPressed!="C"))
                {
                    temp2=string.Concat(temp2,keyPressed);
                    B=Double.Parse(temp2);
                }
                                                            //toogle sign change for 2nd Operand
                if(keyPressed=="s" || keyPressed=="S")                
                    B=B*(-1);
                return ($"{A}\n{opertor}\n{B}\n");
            }

            else if(keyPressed=="=")                              
            {
                
                temp=""; temp2="";                      
                try
                {
                    A=Calculate(A,B,opertor);
                    opertor="";
                    B=0;
                    Flag=false;                     //after result new oprand will store in b always
                    return ($"{A}");               
                }
                catch(DivideByZeroException)
                {
                    return ("-E-");
                }     
            }
            return "-E-";
        }
        public static double Calculate(double A,double B,string opertor)
        {
            if(opertor=="+")
                return A+B;
            else if(opertor=="/")
            {
                if(B==0)
                    throw new DivideByZeroException();
                else
                    return A/B;
            }
            else if(opertor=="x" || opertor=="X")
                return A*B;
            else if(opertor=="-")
                return A-B;
            else
                return 0;       //if no operator provide then this is default result
        }

        public static void ValidateKey(string key)
        {
            if(Allinputs.Contains(key,StringComparer.OrdinalIgnoreCase)==false)
                throw new ArgumentException("Enter only numbers to calculate");
        }
    }
}
