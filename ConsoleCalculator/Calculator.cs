using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
           Double operand1=0;
           Double operand2=0;
           Double decimalnum=-1;
           Double dividecounter=10;
           
           char operatorhere='0';//initialise the operatorhere as zero as it should be other than +,-,*,/
        public string SendKeyPress(char key)
        {
            // Add your implementation here.
            if(key=='c' || key=='C'){
                ResetAll();
                return operand1.ToString();
            }

            if(operatorhere=='0'){//when first character inserted

            if(key=='s' || key=='S'){
               return ToggleSign();
            }

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
                   case '9': if(decimalnum!=-1){
                              double temp=key-'0';
                             decimalnum=(temp/dividecounter);
                              dividecounter*=10;
                             operand1+=decimalnum;
                              }else{
                               operand1*=10;
                               operand1+=key-'0';
                               }
                             break;
                            
                   case '.': if(decimalnum==-1){
                                decimalnum=0.0;
                                return operand1.ToString()+".";
                                 }
                            
                             break;           
               }

               switch(key)
               { 
                   case '+':
                   case '-':
                   case 'x':
                   case 'X':
                   case '/':operatorhere=key;
                            decimalnum=-1;dividecounter=10;//reset the decimal
                            break;
               }

             return operand1.ToString();

            }else{//when operator has been inserted

               if(key=='s' || key=='S'){
                   return ToggleSign();     
                  }

                  switch(key){ 
                   case '0':
                   case '1':
                   case '2':
                   case '3':
                   case '4':
                   case '5':
                   case '6':
                   case '7':
                   case '8':
                   case '9': if(decimalnum!=-1){//adding the number after decimal
                              double temp=key-'0';
                              decimalnum=(temp/dividecounter);
                              dividecounter*=10;
                              operand2+=decimalnum;
                              }else{
                                  operand2*=10;
                                  operand2+=key-'0';}
                               return operand2.ToString();   
                   case '.': if(decimalnum==-1){
                                decimalnum=0.0;
                                return operand2.ToString()+".";
                                 } 
                                 break;                   
               }

               switch(key){ 
                   case '+':
                   case '-':
                   case 'x':             
                   case 'X':
                   case '/':
                   case '=':operand1=performOperation(operand1,operand2,operatorhere);
                            operand2=0;
                            operatorhere=key;
                            decimalnum=-1;dividecounter=10;//reset decimal
                            break;       
               }
               
             String displayOutput=operand1.ToString();

              if(displayOutput=="Infinity")//Error check
              {  displayOutput="-E-";
                 operand1=0;
              }

             return displayOutput;

             }
              
        }


        double performOperation(double operand1,double operand2,char operatorhere){
            
           switch(operatorhere)
               { 
                   case '+':return operand1+operand2;       
                   case '-':return operand1-operand2;
                   case 'X':         
                   case 'x':return operand1*operand2;
                   case '/':return operand1/operand2;
                   case '=':return operand1;
               }
               return 0;
        }

       void ResetAll(){//Reset method
           operand1=0;
           operand2=0;
           decimalnum=-1;
           dividecounter=10;
           operatorhere='0';
       }

       String ToggleSign(){
           if(operatorhere=='0' || operatorhere=='=' || operand2==0){
               operand1*=-1;
               return operand1.ToString();
           }else{
                  operand2*=-1;
                 return operand2.ToString(); 
           }

       } 
    }
}
