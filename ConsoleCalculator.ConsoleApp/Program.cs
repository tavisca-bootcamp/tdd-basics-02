using System;

namespace ConsoleCalculator.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            ConsoleKeyInfo key;
            Console.WriteLine("Press Ctrl + C to close the program.");
            Console.Write("0");
            while (IsKillSwitch(key = Console.ReadKey(true)) == false)
            {
                Console.Clear();
                //  Console.WriteLine(key.KeyChar);

                Console.WriteLine(Calculator.SendKeyPress(key.KeyChar));
            }
        }

        private static bool IsKillSwitch(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.C && key.Modifiers == ConsoleModifiers.Control;
        }
    }
}
