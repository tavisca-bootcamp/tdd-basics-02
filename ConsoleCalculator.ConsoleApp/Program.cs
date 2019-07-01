using System;
using System.Collections.Generic;

namespace ConsoleCalculator.App
{
    class Program
    { 
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            

            ConsoleKeyInfo key;
            Console.WriteLine("Press Ctrl + C to close the program.");
            while (IsKillSwitch(key = Console.ReadKey(true)) == false)
            {
                Console.Clear();
                Console.WriteLine("key pressed  " + key.KeyChar);
                string r = calc.SendKeyPress(key.KeyChar);
                Console.WriteLine(r);
                if (r.Equals("-E-"))
                    break;
            }
        }

        private static bool IsKillSwitch(ConsoleKeyInfo key)
        {
            //Console.WriteLine("cance  key pressed  " + key.KeyChar);
            return key.Key == ConsoleKey.C && key.Modifiers == ConsoleModifiers.Control;
        }
    }
}
