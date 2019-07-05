using System;
using System.Collections;
using System.Collections.Generic;
namespace ConsoleCalculator
{
    public class Calculator
    {   
            Stack<String> keys = new Stack<String>();
            public string SendKeyPress(char key)
            {
                
               
                //list of expected numbers
                ArrayList numbersList = new ArrayList() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                //list of operatons for single operands
                ArrayList singleNumberOperations = new ArrayList() { "S", "C", ".", "s", "c" };

                //list of operations for two operands
                ArrayList doubleNumberOperations = new ArrayList() { "+", "-", "X", "/","x"};


                try
                {
                    //Check whether stack is empty and key is number
                    if (keys.Count == 0 && numbersList.Contains(key + ""))
                    {
                        keys.Push(key + "");
                        return keys.Peek();
                    }

                    //conditon to check stack has number and key is also number
                    else if (keys.Count == 1 && numbersList.Contains(key + ""))
                    {
                        String temp = keys.Pop();
                        temp += key;
                        keys.Push(temp);
                        return keys.Peek();
                    }

                    //condition to check whether operator is for singleOperand
                    else if (singleNumberOperations.Contains(key + ""))
                    {
                        String temp = keys.Pop();
                        temp = SingleOperandUtil(temp, key + "");
                        keys.Push(temp);
                        return temp;
                    }

                    //condition to check wheather operaotion is doubleoperand and digit is already in stack
                    else if (keys.Count == 1 && doubleNumberOperations.Contains(key + ""))
                    {
                        keys.Push(key + "");
                        return keys.Peek();
                    }

                //condition to check whether number and operator is present in stack
                else if (keys.Count == 2)
                {
                    keys.Push(key + "");
                    return keys.Peek();
                }

                //condition to check that stack has two numbers and one operator when = is hit 
                else if (keys.Count == 3 && key == '=')
                    {
                        string temp = OperationUtil(keys.Pop(), keys.Pop(), keys.Pop());
                        return temp;
                    }

                    //condition to check that stack has two numbers and one operator for multiple calculations
                    else if (keys.Count == 3)
                    {
                        string temp = OperationUtil(keys.Pop(), keys.Pop(), keys.Pop());
                        keys.Push(temp);
                        keys.Push(key + "");
                        return temp;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.GetType().Name);
                }
                return "E";
            }


            //Method for calculation operation between two numbers
            public string OperationUtil(string number1, string operation, string number2)
            {
                try
                {
                    double numb1 = double.Parse(number1);
                    double numb2 = double.Parse(number2);
                    switch (operation)
                    {

                        case "+":
                            return (numb2 + numb1).ToString();

                        case "-":
                            return (numb2 - numb1).ToString();

                        case "X":
                            return (numb2 * numb1).ToString();

                        case "/":
                            //checing whether denominator is 0
                            if (numb1 == 0)
                            {

                                return "E";
                            }
                            return (numb2 / numb1).ToString();
                    }
                }
                catch
                {
                    throw;
                }
                return "E";
            }

            //Method for calculation operations for single number
            public string SingleOperandUtil(string number, string key)
            {
                try
                {
                    //check whether S hits
                    if (key.Equals("s") || key.Equals("S"))
                    {
                        //parsing number to double
                        double numb = double.Parse(number);

                        //checking whether numb is positive or negative
                        if (numb > 0)
                        {
                            return number.Insert(0, "-"); ;
                        }

                        else
                        {
                            return number.Substring(1, number.Length - 1);
                        }


                    }

                    //check whether c hits
                    else if (key.Equals("c") || key.Equals("C"))
                    {
                        keys = new Stack<String>();
                        return "0";
                    }

                    //check whether . hits
                    else if (key.Equals("."))
                    {
                        //parsing number to double
                        double numb = double.Parse(number);

                        int index = number.IndexOf(".");

                        //  checking whether . is already present or not
                        if (index != -1)
                        {
                            number = number.Remove(index);
                            return number.Insert(number.Length, ".");
                        }
                        else
                        {
                            return number.Insert(number.Length, ".");
                        }
                    }
                }
                catch
                {
                    throw;
                }

                return "E";
            }


        }
    }
 
  
        
    

