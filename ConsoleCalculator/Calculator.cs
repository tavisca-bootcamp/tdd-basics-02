using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Calculator
    {
        List<double> values = new List<double>();
        List<char> operations = new List<char>();
        static int pow = 10;
        static bool isOperation = false,dotActive = false;
        public string SendKeyPress(char key)
        {    
            if (Char.IsDigit(key))
            {   if (values.Count == 0)
                    values.Add(0);

                if (!dotActive)
                {
                    values[values.Count - 1] = (values[values.Count - 1] * 10) + Int32.Parse(key.ToString());
                    pow = 10;
                }
                else
                {
                    values[values.Count - 1] = values[values.Count - 1] + (Double.Parse(key.ToString()) / pow);
                    pow *= 10;
                }
            }
            if (key.Equals('-') || key.Equals('+') || key.Equals('/') || key.Equals('*'))
            {
                values.Add(0);
                dotActive = false;
                operations.Add(key);
                return values[values.Count - 2].ToString();
            }
            if (key.Equals('.'))
                dotActive = true;

            if (Char.ToUpperInvariant(key).Equals('S'))
            {
                values[values.Count - 1] *= (-1);
            }
            if (Char.ToUpperInvariant(key).Equals('C'))
            {
                values.Clear();
                values.Add(0);
                operations.Clear();
                return "0";
            }
            if (key.Equals('='))
            {
                if (operations.Count == values.Count - 1)
                {
                    for (int i = 0; i < operations.Count; i++)
                    {       if (operations[i].Equals('*'))
                                values[0] = values[0] * values[1];
                            if (operations[i].Equals('/'))
                            {
                                if (values[1] != 0)
                                    values[0] = values[0] / values[1];
                                else
                                    return "-E-";
                            }
                            if (operations[i].Equals('+'))
                                values[0] = values[0] + values[1];
                            if (operations[i].Equals('-'))
                                values[0] = values[0] - values[1];
                            values.RemoveAt(1);
                    }
                    return values[0].ToString();
                }
                return "-E-";
            }
            return values[values.Count - 1].ToString();
        }
    }
}
