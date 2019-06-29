using System;

namespace ConsoleCalculator
{
    public class ProcessOperations
    {
        public char Operator = 'N';

        private double Result = Double.MinValue;

        private string ConsoleOutput = "";

        public bool HasBeenProcessed = false;

        private const int Error = -1;

        public string ProcessResult(char token){
            switch(token){
                
                case 's':
                case 'S':int Temp = 0;
                         if(int.TryParse(ConsoleOutput, out Temp))
                            ConsoleOutput = (-Temp).ToString();
                         else
                            ConsoleOutput = (-Double.Parse(ConsoleOutput)).ToString();
                         return ConsoleOutput;


                case 'c':
                case 'C': ConsoleOutput = "";
                          HasBeenProcessed = false;
                          Result = Double.MinValue;
                          return "0";
                
                case '.':int Temp1 = 0;
                         if(int.TryParse(ConsoleOutput, out Temp1))
                            ConsoleOutput += token;
                         return ConsoleOutput;
                case '+': 
                         if(!HasBeenProcessed && Operator != 'N'){
                            HasBeenProcessed = true;
                            ProcessResult(Operator);
                            Operator = '+';
                          }
                          else{
                              if(Operator == token){
                                  Console.Write("\b \b");
                              }
                              HasBeenProcessed = false;
                              Operator = '+';
                              if(Result != Double.MinValue)
                                Result += Double.Parse(ConsoleOutput);
                              else
                                Result = Double.Parse(ConsoleOutput);
                              ConsoleOutput = "";
                          }
                          return Result.ToString();
                
                case '-': 
                         if(!HasBeenProcessed && Operator != 'N'){
                            HasBeenProcessed = true;
                            ProcessResult(Operator);
                            Operator = '-';
                          }
                          else{
                              if(Operator == token){
                                  Console.Write("\b \b");
                              }
                              HasBeenProcessed = false;
                              Operator = '-';
                              if(Result != Double.MinValue)
                                Result -= Double.Parse(ConsoleOutput);
                              else
                                Result = Double.Parse(ConsoleOutput);
                              ConsoleOutput = "";
                          }
                          
                          return Result.ToString();
                case 'x':
                case 'X':
                        if(!HasBeenProcessed && Operator != 'N'){
                            HasBeenProcessed = true;
                            ProcessResult(Operator);
                            Operator = 'x';
                          }
                          else{
                              if(Operator == token){
                                  Console.Write("\b \b");
                              }
                              HasBeenProcessed = false;
                              Operator = 'x';
                              if(Result != Double.MinValue)
                                Result *= Double.Parse(ConsoleOutput);
                              else
                                Result = Double.Parse(ConsoleOutput);
                              ConsoleOutput = "";
                          }

                          ConsoleOutput = "";
                          return Result.ToString();
                case '/': 
                            if(!HasBeenProcessed && Operator != 'N'){
                            HasBeenProcessed = true;
                            if(ProcessResult(Operator) == "-E-")
                                return "-E-";
                            ProcessResult(Operator);
                            Operator = '/';
                          }
                          else{
                              if(Operator == token){
                                  Console.Write("\b \b");
                              }
                              HasBeenProcessed = false;
                              Operator = '/';
                              if(Result != Double.MinValue)
                              {
                                  if(Double.Parse(ConsoleOutput) != 0)
                                    Result /= Double.Parse(ConsoleOutput);
                                  else
                                    return "-E-";
                              }
                              else
                                Result = Double.Parse(ConsoleOutput);
                              ConsoleOutput = "";
                          }
                          return Result.ToString();
                case '0':if(!(ConsoleOutput.Equals("0")))
                            ConsoleOutput += token;
                         return ConsoleOutput;
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9': ConsoleOutput += token;
                          return ConsoleOutput;
                
                case '=':if(ConsoleOutput == "")
                            ConsoleOutput = Result.ToString();
                         return ProcessResult(Operator);
                default: return ConsoleOutput;
                
            }
        }


    }
}