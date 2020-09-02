using System;
using System.Text.RegularExpressions;

namespace ConsoleCalculator
{
    public class Calculator
    {
        const string ErrorCode = "-E-";
        const string InitailValue = "0";

        string firstOperand = null;
        string secondOperand = null;
        string arthimaticOperator = null;

        Helper helper = new Helper();
        Validation validate = new Validation();

        public Calculator()
        {
            Console.WriteLine("0");
        }

        public string SendKeyPress(char key)
        {
            // Add your implementation here.
            throw new NotImplementedException();
        }
    }
}
