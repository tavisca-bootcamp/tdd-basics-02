using System;


namespace ConsoleCalculator
{   
    public class Calculator
    {
        private static bool Begin = true;
        private ProcessOperations Po = new ProcessOperations();
        public string SendKeyPress(char key){
            if(Begin){
                Console.Write("0");
                Begin = false;
            }
            string output = "-E-";
            try{
                output = Po.ProcessResult(key);
                if(output == "") output = "-E-";
            }
            catch(Exception){
              
            }
            return output;
        }
    }

}


    
