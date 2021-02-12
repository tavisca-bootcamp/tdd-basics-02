using System;
//using Operation;

namespace ConsoleCalculator
{
    public class Calculator
    {
        double arguement1 = 0;
        string arguement1String = "";
        char operation = '0';
        double arguement2 = 0;
        string arguement2String = "";
        double result = 0;
        bool arguement2Added = false;


        // Function to reset the calculator to default values
        public void resetCalculator()
        {
            arguement1 = 0;
            arguement1String = "";
            arguement2 = 0;
            arguement2String = "";
            operation ='0';
            arguement2Added = false;
        }

        public double ParseStringToDouble(string arguement) {
            if(Double.TryParse(arguement, out double temporary))
            {
                return temporary;
            }
            else
            {
                return Double.NaN;
            }
        }


        public string SendKeyPress(char key)
        {
            // Add your implementation here.

            // Condition to input the values of Arguements
            if((key >= 48 && key <= 57) || key == '.')
            {
                // If operation is not yet given, means still arguement 1 inputted
                if(operation.Equals('0'))
                {
                    // if '.' is pressed then check if last value was also a '.'
                    // Input only if the last value is not a '.'
                    // Else give an error

                    if(key == '.' )
                    {
                        if(!arguement1String.EndsWith("."))
                            arguement1String += key;
                    }
                    else
                    {
                            arguement1String += key;
                    }

                    arguement1 = ParseStringToDouble(arguement1String);

                    if (Double.IsNaN(arguement1))
                    {
                        resetCalculator();
                        return "-E-";
                    }
                    else
                    {
                        return arguement1.ToString();
                    }
                }
                else
                {

                    arguement2Added = true;
                    if (key == '.' )
                    {
                        if(!arguement2String.EndsWith("."))
                            arguement2String += key;
                    }
                    else
                    {
                            arguement2String += key;
                    }

                    arguement2 = ParseStringToDouble(arguement2String);

                    if (Double.IsNaN(arguement2))
                    {
                        resetCalculator();
                        return "-E-";
                    }
                    else
                    {
                        
                        return arguement2.ToString();
                    }
                }
                
            }
            else if(key == '=')
            {
                if (!arguement2Added)
                {
                    arguement2 = arguement1;
                }
                result = Operations.Operation(arguement1, arguement2, operation);
                
                resetCalculator();

                if (Double.IsNaN(result) || Double.IsInfinity(result))
                {
                    return "-E-";
                }
                else
                {
                    return (result).ToString();
                }
            }

            // Resetting the calculator
            else if (key == 'C' || key == 'c')
            {
                resetCalculator();
                return "0";
            }

            // Toggling the sign of arguements
            else if (key == 's' || key == 'S') {
                if(operation == '0')
                {
                    arguement1 *= -1;
                    return (arguement1).ToString();
                }
                else
                {
                    arguement2 *= -1;
                    return (arguement2).ToString();
                }
            }

            else 
            {
                // If already 2 arguements have been inputted
                if(operation != '0')
                {
                    double temp = Operations.Operation(arguement1, arguement2, operation);
                    resetCalculator();
                    arguement1 = temp;
                    arguement1String = arguement1.ToString();
                    // If output is Not a Number then give error;
                    if (Double.IsNaN(arguement1))
                    {
                        resetCalculator();
                        return "-E-";
                    }
                }

               if(key == '+')
                {
                    operation = '+';
                }
               else if(key == '-')
                {
                    operation = '-';
                }
               else if(key == 'x')
                {
                    operation = '*';
                }
               else if(key == '/')
                {
                    operation = '/';
                }
                return arguement1.ToString();
            }
        }
    }
}
