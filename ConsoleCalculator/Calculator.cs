using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private List<float> ListOfTwoNumbers;
        private char Sign;
        private string Number;
        private String NumberBeforeSign;
        private float Result;
        private List<char> ListOfKeys;
        private readonly char[] ValidOperatorList;
        private readonly char[] ValidDigitList;


        public Calculator()
        {
            ListOfTwoNumbers = new List<float>();
            ListOfKeys = new List<char>();
            NumberBeforeSign = "";
            Number = "";
            ValidOperatorList = new char[] { '+', '-', 'x', '/' };
            ValidDigitList = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
        }
        
        public bool IsValidKey(char key)
        {
            char [] keysList = {'0','1','2','3','4','5','6','7','8','9','.','-','+','x','/','s','c','=' };

            if (keysList.Contains(key))
                return true;
            return false;

        }

       private void HandleCKeyPress()
        {
            Number = "0";
            NumberBeforeSign = "0";
            ListOfTwoNumbers.Clear();
            ListOfKeys.Clear();
            ListOfKeys.Add('c');
        }

        private void HandleSKeyPress()
        {
            int toggledNumber;
            if (Number != "")
            {
                toggledNumber = -int.Parse(Number);
                NumberBeforeSign = toggledNumber.ToString();
                Number = toggledNumber.ToString();
            }

            else
            {
                toggledNumber = -int.Parse(NumberBeforeSign);
                Number = toggledNumber.ToString();
                //NumberBeforeSign = Number;
            }
        }

        private void HandleEqualtoKeyPress()
        {
            if (ListOfTwoNumbers.Count == 1 && ValidOperatorList.Contains(ListOfKeys[ListOfKeys.Count - 2]))
            {
                ListOfTwoNumbers.Add(ListOfTwoNumbers[0]);
                NumberBeforeSign = CalculateResult();
               
            }
            else if (Number != "")
            {
                ListOfTwoNumbers.Add(int.Parse(Number));
                //NumberBeforeSign = Number;
                NumberBeforeSign = CalculateResult();
                
            }
           
        }

        private void HandleZeroKeyPress()
        {
            Number = "0";
        }

        private void HandleDigitKeyPress(char key)
        {
            if ((Number == "0") && (ListOfKeys[ListOfKeys.Count - 2] == 'c'))
                Number = key.ToString();
            else
            {
                if (ListOfTwoNumbers.Count == 1 && Number == "" && ListOfKeys.Last() == 's')
                    Number = key.ToString();
                else
                    Number += key;
            }

        }

        private void HandleOperatorKeyPress(char key)
        {
            if ((Number != "") && (ListOfTwoNumbers.Count == 1))
            {
                ListOfTwoNumbers.Add(int.Parse(Number));

                NumberBeforeSign = CalculateResult();
                Number = "";
                Sign = key;
                
            }

            else if ((Number == "") && (ListOfTwoNumbers.Count == 1))
            {
                Sign = key;
            }

            else
            {
                Sign = key;
                ListOfTwoNumbers.Add(int.Parse(Number));
                NumberBeforeSign = Number;
                Number = "";
            }
        }

        public string Operate(char key)
        {

           
            key = Char.ToLower(key);
            ListOfKeys.Add(key);

            
            if (key == '0' && Number == "0")
            {
                HandleZeroKeyPress();
            }

            else if (key == '.' && Number.Contains("."))
            {
                Number = Number;
            }

            else if (key == 'c')
            {
                HandleCKeyPress();
            }

            else if (key == 's')
            {
                HandleSKeyPress();
            }


            else if (ValidDigitList.Contains(key))
            {
                HandleDigitKeyPress(key);
            }


            else if (ValidOperatorList.Contains(key))
            {
                HandleOperatorKeyPress(key);
                return NumberBeforeSign;
            }


            else if (key == '=')
            {
                HandleEqualtoKeyPress();
                return NumberBeforeSign;
            }


            if (ValidOperatorList.Contains(key) || !IsValidKey(key))
                return NumberBeforeSign;
            return Number;

        }

        public string CalculateResult()
        {
            bool divideByZeroErrorStatus = false;  
            switch(Sign)
            {
                case '+':
                    Result = ListOfTwoNumbers.Sum();
                    break;
                case '-':
                    Result = ListOfTwoNumbers[0] - ListOfTwoNumbers[1];
                    break;
                case 'x':
                    Result = ListOfTwoNumbers[0] * ListOfTwoNumbers[1];
                    break;
                case '/':
                    if (ListOfTwoNumbers[1] == 0)
                        divideByZeroErrorStatus = true;
                    else
                        Result = ListOfTwoNumbers[0] / ListOfTwoNumbers[1];
                    break;
                default:
                    break;
            }
            
            ListOfTwoNumbers.Clear();
            ListOfTwoNumbers.Add(Result);
            NumberBeforeSign = Result.ToString();
            Number = "";
            return (divideByZeroErrorStatus)?"-E-":Result.ToString();
        }

     
    }
}
