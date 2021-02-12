using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string displayChar = "";
        private float result = float.MaxValue;
        private char previousOperator = '~';
        private int flag = 0;
        const char TOGGLE_SIGN_COMMAND = 'S';
        const char CLEAR_DISPLAY_COMMAND = 'C';
        const char ADD = '+';
        const char SUBTRACT = '-';
        const char MULTIPLY = '*';
        const char DIVIDE = '/';
        const char EQUALS = '=';
        const char DECIMAL_POINT = '.';

        public string SendKeyPress(char key)
        {
            switch (key)
            {
                case '0':
                    if (!displayChar.Equals("0"))
                    {
                      displayChar += key;
                    }
                    return displayChar;

                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':   displayChar += key;
                    return displayChar;

                case DECIMAL_POINT:   
                    if (int.TryParse(displayChar,out int temp)==true)           //Checks if the displayed character is a number
                    {      
                        displayChar += key;
                    }
                    return displayChar;

                case 'c':
                case CLEAR_DISPLAY_COMMAND:             //Clear Display Command: 'C' and 'c'
                    displayChar = "";                
                    result = float.MaxValue;
                    flag = 0;
                    return "0";

                case 's':
                case TOGGLE_SIGN_COMMAND:               //Toggle Sign Command: 'S' and 's'
                    int temp1;                         
                    if(int.TryParse(displayChar,out temp1) == true)
                    {
                        displayChar = (-temp1).ToString();
                    }
                    else
                    {
                        displayChar = (-float.Parse(displayChar)).ToString();
                    }
                    return displayChar;

                case ADD:
                    if (flag == 0 && previousOperator!='~')
                    {
                        flag = 1;
                        SendKeyPress(previousOperator);
                    }
                    else
                    {
                        if (result != float.MaxValue)
                            result += float.Parse(displayChar);     //adding 2nd number to result
                        else
                            result = float.Parse(displayChar);      //storing 1st number in result

                        previousOperator = '+';
                        flag = 0;
                        displayChar = "";
                    }

                    return result.ToString();

                case SUBTRACT:
                    if (flag == 0 && previousOperator != '~')
                    {
                        flag = 1;
                        SendKeyPress(previousOperator);
                    }
                    else
                    {
                        if (result != float.MaxValue)
                            result -= float.Parse(displayChar);     //Subtracting 2nd number from result
                        else
                            result = float.Parse(displayChar);      //storing 1st number in result

                        previousOperator = '-';
                        flag = 0;
                        displayChar = "";
                    }

                    return result.ToString();


                case 'x':
                case MULTIPLY:                                       //Multplication command : 'X' or 'x'
                    if (flag == 0 && previousOperator != '~')
                    {
                        flag = 1;
                        SendKeyPress(previousOperator);
                    }
                    else
                    {
                        if (result != float.MaxValue)
                            result *= float.Parse(displayChar);
                        else
                            result = float.Parse(displayChar);

                        previousOperator = 'x';
                        displayChar = "";
                        flag = 0;
                    }
                    return result.ToString();


                case DIVIDE:
                    if (flag == 0 && previousOperator != '~')
                    {
                        flag = 1;
                        if (SendKeyPress(previousOperator) == "-E-")
                            return "-E-";
                    }
                    else
                    {
                        if (result != float.MaxValue)
                        {
                            if (float.Parse(displayChar) != 0)
                                result /= float.Parse(displayChar);
                            else
                                return "-E-";
                        }
                        else
                            result = float.Parse(displayChar);

                        previousOperator = '/';
                        displayChar = "";
                        flag = 0;
                    }
                    return result.ToString();

                case EQUALS:
                    if (displayChar == "")
                    {
                        displayChar = result.ToString();
                    }
                    return SendKeyPress(previousOperator);

                default: return displayChar;
            }
            

            
        }
    }
}
