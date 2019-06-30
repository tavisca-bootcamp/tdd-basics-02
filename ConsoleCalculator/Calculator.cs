using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private string oprand1 = "";
        private string oprand2 = "";
        private char? _operator =null ; //converting value type to nullable type

        public string SendKeyPress(char key)
        {

            #region clear the screen with "0"
            if (key == 'c' || key == 'C')
            {
                clearHistory();
                return "0";
            }



            #region toogle the sign of the current oprand
            if (key == 'S' || key == 's')
            {
                //check which oprand we're working with and change the sign.
                if (_operator == null) //means we're currently working with oprand1
                {
                    oprand1 = (-1 * float.TryParse(oprand1)).ToString;
                    return oprand1;
                }
                else
                {
                    oprand2 = (-1 * float.TryParse(oprand1)).ToString;
                    return oprand2;
                }
            }


            #region checking which no. is entered and then update the current oprand accordingly.
            switch (key)
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
                case '9':
                    //always check which oprand is under process
                    if(_operator == null)
                    {
                        //means working with oprand1
                        //don't append zeros multiple times so,
                        if (oprand1 == "0") oprand1 = key.ToString;
                        else
                        {
                            oprand1 += key.ToString;
                            return oprand1;
                        }

                    }
                    else
                    {
                        //means working with oprand2
                        if (oprand2 == "0") oprand2 = key.ToString;
                        else
                        {
                            oprand2 += key.ToString;
                            return oprand2;
                        }
                    }
            }


            #region avoid adding multiple zeros after '.'
            if (key == '.')
            {
                //so always checking with oprand we're woking with
                if(_operator == null)  //means we're currently working with oprand1
                {
                    if(lastCharOf(oprand1) != '.')
                    {
                        oprand1 += key.ToString;
                        return oprand1;
                    }
                }
                else
                {
                    if(lastCharOf(oprand2) != '.')
                    {
                        oprand2 += key.ToString;
                        return oprand2;
                    }
                }
            }


            #region oprator handling
            switch (key)
            {
                case '+':
                case '-':
                case 'X':
                case 'x':
                case '/':
                    if (_operator == null) return oprand1;

                    //for sequence of opration we have to process last two oprand and store the result in oprand1
                    oprand1 = processLastTwo();

                    if (oprand1 == "error") return error();

                    number2 = "";

                    // Assign current operation as _oprand
                    _operator = key;
                    return number1;
            }


            if(key == '=')
            {
                // Pressing '=' without any operations
                if (_operator == null) return oprand1;

                oprand1 = SendKeyPress((char)_operator);
                if (oprand1 == "-E-") return error();

                oprand2 = "";
                _operator = null;

                return oprand1;
            }

            #region ignoring keys other then specified
            if(_oprator == null){
                return oprand1;
            }else
                return oprand2;


        }

        private void error()
        {
            clearHistory();
            return "-E-";
        }

        private string processLastTwo()
        {
            float x = float.Parse(this.oprand1);
            float y = float.Parse(this.oprand2);

            switch (_operator)
            {
                case '+':
                    return (x + y).ToString();

                case '-':
                    return (x - y).ToString();

                case 'x':
                case 'X':
                    return (x * y).ToString();

                case '/':
                    if (y == 0) return "error";
                    return (x / y).ToString();
            }
            return "";
        }
        
        private char lastCharOf(string oprand)
        {
            oprand[oprand.Length - 1];
        }

        private void clearHistory()
        {
            oprand2 = "0"; oprand1 = "0"; _operator = null;
        }
    }
}
