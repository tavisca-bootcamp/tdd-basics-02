using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        static string userPressedKey = "";
        static string result = "";
        static string first="";
        static char operand;
        static bool flag = false;

        public string SendKeyPress(char key)
        {
           if(Char.IsLetter(key))
            {
                key = char.ToLower(key);

                if (key == 'x') key = '*';

                switch (key)
                {
                    case 'c':
                        ClearCalculator();
                        break;
                    case 's':
                        ChangedSign();
                        break;
                    
                }
            }
           if(char.IsDigit(key))
            {
                if(key == '0')
                {
                    if(String.IsNullOrEmpty(userPressedKey) || userPressedKey == "0")
                    {
                        userPressedKey = "0";
                    }
                    else
                    {
                            userPressedKey += key;
                    }
                }
                else
                {
                    // to remove zero infront of the digit  
                    if (userPressedKey == "0")
                    {
                        userPressedKey = key.ToString();
                    }
                    else
                    {
                        userPressedKey += key;
                    }
                }
            }
            else
            {
                switch (key)
                {
                    case '+':
                    case '-':
                    case '/':
                    case '*':
                        if (flag == false)
                        {
                            setVariable(userPressedKey, key);
                            flag = true;
                        }
                        else
                        {//if user press multiple operand then it will calculate
                            return RepeatOpertaion(key);
                        }
                        break;
                    case '=':
                       // Console.WriteLine($"first : {first} results : {result} userPressedKey : {userPressedKey} operand : {operand}");
                        if (flag == true && !string.IsNullOrEmpty(result)) userPressedKey = result;
                        result = PerformsOperation(first,userPressedKey, operand);
                        userPressedKey = "0";
                        return result;

                    case '.':
                        checkReaptationOfDot(key);
                        break;

                }

            }

            return userPressedKey;
        }
        //reseting all the values
        public static void ClearCalculator()
        {
             userPressedKey = "0";
             result = "";
             first = "";
            operand = char.MinValue;
             flag = false;
            Console.Clear();
        }

        public static void ChangedSign()
        {
            double signNumber = 0.0;
            if(!string.IsNullOrEmpty(userPressedKey))
            {
                double.TryParse(userPressedKey, out signNumber);
                signNumber = signNumber * -1;
            }
            userPressedKey = signNumber.ToString();
        }

        public static void checkReaptationOfDot(char key)
        {
            if(!string.IsNullOrEmpty(userPressedKey))
            {
                if(!userPressedKey.Contains("."))
                {
                    userPressedKey += key;
                }
            }
            else
            {
                userPressedKey = "0";
            }
        }

        public static void setVariable(string fst, char symbol)
        {
            //intialize the variable for performing the operations
            first = fst;
            operand = symbol;
            userPressedKey = "";
            
        }

        public static string RepeatOpertaion(char operation)
        {
            if(string.IsNullOrEmpty(result))
            {
                result = first;
            }
            result = PerformsOperation(result, userPressedKey, operation);
            userPressedKey = "0";
            first = result;
            operand = operation;
            return result;
        }

        public static string PerformsOperation(string first,string second, char operation)
        {
            double number1, number2, result = 0.0;
            double.TryParse(first, out number1);
            double.TryParse(second, out number2);

            switch (operation)
            {
                case '+':
                    result = number1 + number2;
                    break;
                case '-':
                    result = number1 - number2;
                    break;
                case '/':
                    if (number2 > 0)
                    {
                        result = (number1 / number2);
                    }
                    else
                    {
                        return "-E-";
                    }
                    break;
                case '*':
                    result = number1 * number2;
                    break;
            }

            return result.ToString("0.##");

        }

    }
}
