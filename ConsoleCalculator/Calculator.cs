using System;
using System.Linq;

namespace ConsoleCalculator
{
    public class Calculator
    {
        string keyPressed="", temp="0",temp2="0",opertor="",msg=""; //temps assigned with zero to hold . values
        double A=0,B=0;                                                 //to store operands
        public double test=0;                                         
        bool Flag=false;                                        //flag helps to find 2nd operator
            
        public void SendKeyPress(char key)
        {
            ValidateKey(key);                                      //validity check must be done
            keyPressed=key.ToString(); 

            //Extraction of first operand=========================================================================================
            if(keyPressed=="c" || keyPressed=="C")                  //reset everything
            {
                Console.Clear();
                System.Console.WriteLine("0");
                A=0;B=0;temp="";temp2="";Flag=false;
            }

            else if((keyPressed!="+" && keyPressed!="-" && keyPressed!="x" && keyPressed!="X" && keyPressed!="/") && Flag==false)                      //extract out first operand
            {  
                if((keyPressed!="s" && keyPressed!="S") && (keyPressed!="c" && keyPressed!="C"))
                {
                    temp=string.Concat(temp,keyPressed);
                    A=Double.Parse(temp);
                }               
                Console.Clear();  
                //toogle sign change for first Operand                             
                if(keyPressed=="s" || keyPressed=="S")
                    A=A*(-1);        
                Console.Write($"{A}\n");
            }
               
            //Extraction Of Operator==================================================================================================
            else if(keyPressed=="+" || keyPressed=="-" || keyPressed=="x" || keyPressed=="X"|| keyPressed=="/")                             //extraction of operator
            {
                opertor=keyPressed;
                if(Flag==true)              //for concussive operator continusly,flag tell presence of b
                {
                    try
                    {
                        Console.Clear();
                        A=Calculate(A,B,opertor);
                        test=A;                             //extra var to unit testing
                        B=0;
                    }
                    catch(DivideByZeroException)
                    {
                        Console.Clear();
                        Console.WriteLine("-E-");
                        msg="error";
                    }
                }
                if(msg=="")                             //do not print if exception occured
                    Console.Write($"{A}\n{opertor}\n");  
                Flag=true;
                temp2="";   
            }

            //Extraction of 2nd Operand=========================================================================================
            else if(keyPressed!="=" && Flag==true)               
            {
                if((keyPressed!="s" && keyPressed!="S") && (keyPressed!="c" && keyPressed!="C"))
                {
                    temp2=string.Concat(temp2,keyPressed);
                    B=Double.Parse(temp2);
                }
                Console.Clear();
                //toogle sign change for 2nd Operand
                if(keyPressed=="s" || keyPressed=="S")                
                    B=B*(-1);
                Console.Write($"{A}\n{opertor}\n{B}\n");
            }

            else if(keyPressed=="=")                                //check for b is given or not
            {
                
                temp=""; temp2="";
                try
                {
                    Console.WriteLine($"{A}\n{opertor}\n{B}\n{keyPressed}\n{Calculate(A,B,opertor)}");
                    A=Calculate(A,B,opertor);
                    test=A;                                           //for unit testing
                    opertor="";B=0;
                }
                catch(DivideByZeroException)
                {
                    Console.WriteLine("-E-");
                }
                    
            }
                
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

        public static void ValidateKey(char key)
        {
            char[] input=new char[]{'1','2','3','4','5','6','7','8','9','0','.','s','S','c','C','+','-','/','x','X','='};
            if(input.Contains(key)==false)
                throw new ArgumentException("Enter only numbers to calculate");
        }
    }
}
