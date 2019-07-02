using System;

namespace ConsoleCalculator
{
       public class Calculator
    {
        static string keyPressed = "", res;
        static float op1, op2; //op1 and op2 are operands 
        static char op, lastKey; // lastkey holds the last key pressed and op represents the operator
        static int k = 0, m; // k is used for concatenation purposes and m is used when we have multiple operations to be performed without including an '=' sign
        public static string Compute(float a, float b, char op)
        {
            float result = 0;

            if (op == '+')
                result = a + b;
            else if (op == '-')
                result = a - b;
            else if (op == '/')
            {
                if (b == 0)
                    return "-E-";
                else
                    result = a / b;
            }
            else if (op == 'x' || op == 'X')
                result = a * b;

            return result.ToString();

        }

        public static string SendKeyPress(char key)
        {
            if (keyPressed == "0" && key == '.')
            {
                keyPressed = keyPressed + key;
                lastKey = key;
                k = 0;
                return keyPressed;
            }
            if (lastKey == '\0' && (key == '+' || key == '-' || key == '/' || key == 'x' || key == 'X' || key == '=' || key == 'S'))
            {
                k = 1;
                keyPressed = "0";
                lastKey = key;

                return keyPressed;
            }
            if (keyPressed == "-E-" && key == '=')
            {
                op = '\0';
                op1 = 0; op2 = 0;
                m = 0;
                k = 1;
                lastKey = key;
                return keyPressed;
            }
            if (lastKey == '.' && key == '.')
            {
                return keyPressed;
            }
            if (keyPressed.Contains(".") && key == '.')
            {
                keyPressed = "-E-";
                op = '\0';
                op1 = 0; op2 = 0;
                m = 0;
                k = 1;
                lastKey = key;
                return keyPressed;

            }
            if ((keyPressed == "0" || lastKey == '\0') && key == '0')
            {
                k = 1;
                keyPressed = "0";
                lastKey = key;
                return keyPressed;
            }
            if (lastKey == '\0' && keyPressed == "-E-")
                keyPressed = "";

            if (k == 1)
            {


                if ((lastKey == '+' || lastKey == '-' || lastKey == '/' || lastKey == 'x' || lastKey == 'X') && (key == '+' || key == '-' || key == '/' || key == 'x' || key == 'X'))
                {
                    op = key;
                    lastKey = key;
                    return keyPressed;
                }
                else if (keyPressed == "-E-" && (key == '+' || key == '-' || key == '/' || key == 'x' || key == 'X'))
                    return keyPressed;
                else if ((lastKey == '+' || lastKey == '-' || lastKey == '/' || lastKey == 'x' || lastKey == 'X') && key == '=')
                {
                    op1 = op2 = Convert.ToSingle(keyPressed);
                    op = lastKey;
                    keyPressed = Compute(op1, op2, op);
                    k = 0;
                    return keyPressed;
                }
                else
                {
                    keyPressed = "";
                }
                k = 0;
            }

            if ((key == '1' || key == '2' || key == '3' || key == '4' || key == '5' || key == '6' || key == '7' || key == '8' || key == '9' || key == '0' || key == '.') && k == 0)
            {
                keyPressed = keyPressed + key;
            }

            else if ((key == '+' || key == '-' || key == '/' || key == 'x' || key == 'X') && k == 0)
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //switching the operator 
                if (lastKey == '+' || lastKey == '-' || lastKey == '/' || lastKey == 'x' || lastKey == 'X')
                {
                    op = key;
                    k = 1;
                    lastKey = key;
                    return keyPressed;
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //if operator is followed by an '=' or operator is used for the 1st time and the last statement present on the screen is '-E-'
                if (m == 0 && keyPressed == "-E-")
                {
                    op = '\0';
                    op1 = 0; op2 = 0;
                    m = 0;
                    k = 1;
                    lastKey = key;
                    return keyPressed;
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //when we are computing something in which an operator is followed by some operand which is followed by another operator and statement on screen is not equal to '-E-'
                if (m == 1 && keyPressed != "-E-")
                {
                    op2 = Convert.ToSingle(keyPressed);
                    res = Compute(op1, op2, op);
                    keyPressed = res;
                    //################################################
                    //If an error occurs due to divisibility by 0
                    if (keyPressed == "-E-")
                    {
                        op = '\0';
                        op1 = 0; op2 = 0;
                        m = 0;
                        k = 1;
                        lastKey = key;
                        return keyPressed;
                    }
                    //################################################
                    else
                    {
                        op1 = Convert.ToSingle(keyPressed);
                        op = key;
                        k = 1;
                    }
                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //if operator is clicked the first time or after an '=' followed by an operand
                if (m == 0)
                {
                    m = 1;
                    k = 1;
                    op1 = Convert.ToSingle(keyPressed);
                    op = key;
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            else if (key == '=' && k == 0)
            {
                //when key pressed='=' but there is no operator to operate upon
                if (op == '\0')
                {
                    lastKey = key;
                    return keyPressed;
                }
                //when '=' is pressed followed by an operator
                if ((op != '\0') && (lastKey == 'c' || lastKey == 'C'))
                {
                    lastKey = key;
                    return keyPressed;
                }
                if (op != '\0' && (lastKey == '+' || lastKey == '-' || lastKey == '/' || lastKey == 'x' || lastKey == 'X'))
                {
                    op1 = op2 = Convert.ToSingle(keyPressed);
                    op = key;
                    keyPressed = Compute(op1, op2, op);
                    lastKey = key;
                    return keyPressed;
                }

                //computing op1 operand op2
                if (m == 1 || m == 0)
                {
                    m = 0;
                    //k=1;
                    op2 = Convert.ToSingle(keyPressed);
                    res = Compute(op1, op2, op);
                    keyPressed = res;
                }

            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //resetting the calculator..
            else if (key == 'C' || key == 'c')
            {
                op = '\0';
                op1 = 0;
                op2 = 0;
                keyPressed = "0";
                k = 1;
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Switching the sign of the operator
            else if (key == 'S' || key == 's')
            {
                if (Convert.ToSingle(keyPressed) < 0)
                    keyPressed = keyPressed.Substring(1, keyPressed.Length - 1);
                else
                    keyPressed = "-" + keyPressed;
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            else
            {
                keyPressed = "-E-";
                op = '\0';
                op1 = 0; op2 = 0;
                m = 0;
                k = 1;
                lastKey = key;
                return keyPressed;

            }
            lastKey = key;
            return keyPressed;
            }
    }
}
