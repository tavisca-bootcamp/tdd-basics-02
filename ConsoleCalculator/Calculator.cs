using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleCalculator
{
    public class Calculator
    {
        string inputString = "";
        Double[] Number = new Double[20];
        int i = 0, j = 0;

        int flagAdditionalSign = 0;
        int signFlag = 0;
        char[] sign = new char[20];

        Double LastNumber = 0;
        Double result = 0;

        public double SendKeyPress(char key)
        {
            inputString = inputString + Convert.ToString(key);           
            Console.Write(key);
            ConsoleKeyInfo keyinfo;

            do
            {
                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.C)
                {
                    Console.Clear();
                    Console.Write("0");
                    Array.Clear(Number, 0, Number.Length);
                    Array.Clear(sign, 0, sign.Length);
                    i = 0;
                    result = 0;
                    flagAdditionalSign = 0;
                    inputString = "";
                }
                else
                {

                    inputString = inputString + Convert.ToString(keyinfo.KeyChar);
                    Console.Clear();
                    Console.WriteLine(inputString);
                    if (inputString == "0")
                    {
                        string check = "";
                        do
                        {
                            keyinfo = Console.ReadKey();
                            check = Convert.ToString(keyinfo.KeyChar);
                            inputString = inputString + Convert.ToString(keyinfo.KeyChar);
                            Console.Clear();
                            Console.Write("0");
                            if (inputString[inputString.Length - 1].ToString() == ".")
                            {
                                Console.Clear();
                                inputString = "0.";
                                Console.Write("0.");
                                break;
                            }
                        } while (check == "0");
                    }

                    if (inputString == "0.")
                    {
                        string check = "";
                        do
                        {
                            keyinfo = Console.ReadKey();
                            check = Convert.ToString(keyinfo.KeyChar);
                            inputString = inputString + Convert.ToString(keyinfo.KeyChar);
                            Console.Clear();
                            Console.Write("0.");
                            if (inputString[inputString.Length - 1].ToString() != ".")
                            {
                                Console.Clear();
                                inputString = "0." + Convert.ToString(keyinfo.KeyChar);
                                Console.Write(inputString);
                                break;
                            }
                        } while (check == ".");
                    }

                    if (keyinfo.Key == ConsoleKey.S)
                    {
                        Console.Clear();
                        inputString = inputString.Split('S')[0];
                        if (signFlag == 0)
                        {
                            Console.WriteLine("-" + inputString);
                            signFlag = 1;
                        }
                        else
                        {
                            Console.WriteLine(inputString);
                            signFlag = 0;
                        }
                    }
                    else if (inputString.Contains("="))
                    {
                        Console.Clear();
                        if (inputString.Length != 1)
                        {
                            if (signFlag == 0)
                            {
                                LastNumber = Convert.ToDouble(inputString.Split('=')[0]);
                                Number[i] = LastNumber;
                                i++;
                            }
                            else
                            {
                                LastNumber = -1 * Convert.ToDouble(inputString.Split('=')[0]);
                                Number[i] = LastNumber;
                                i++;
                            }

                        }
                        else
                        {
                            flagAdditionalSign = 1;
                        }

                        int signCounter = 0;
                        for (j = 0; j < i; j++)
                        {
                            if (j == 0)
                            {
                                result = result + Number[j];
                            }
                            else
                            {
                                result = Calculation(result, Number[j], sign[signCounter]);
                                signCounter++;
                            }
                         }
                         if (flagAdditionalSign == 1)
                         {
                                result = Calculation(result,result,sign[signCounter]);
                         }                        

                        if (Double.IsInfinity(result))
                        {
                            Console.Write("-E-");
                        }
                        else
                        {
                              Console.Write(result);
                        }

                    }
                    else if (inputString[inputString.Length - 1].ToString() == "+" || inputString[inputString.Length - 1].ToString() == "-" || inputString[inputString.Length - 1].ToString() == "*" || inputString[inputString.Length - 1].ToString() == "/")
                    {
                        if (signFlag == 0)
                        {
                            Number[i] = Convert.ToDouble(inputString.Substring(0, inputString.Length - 1));
                        }
                        else
                        {
                            Number[i] = -1 * Convert.ToDouble(inputString.Substring(0, inputString.Length - 1));
                        }
                        sign[i] = inputString[inputString.Length - 1];
                        inputString = "";
                        Console.Clear();
                        Console.Write(Number[i]);
                        i++;
                        signFlag = 0;
                    }
                }

            } while (keyinfo.Key != ConsoleKey.X);
            
            return result;
            
            throw new NotImplementedException();
        }

        public static Double Calculation(Double no1,Double no2,char sign)
        {
            Double result=0;
            switch (sign)
            {
                case '+':
                    result = no1 + no2;
                    break;
                case '-':
                    result = no1 - no2;
                    break;
                case '*':
                    result = no1 * no2;
                    break;
                case '/':
                    result = no1 / no2;
                 break;
            }
            return result;
        }

    }
}
