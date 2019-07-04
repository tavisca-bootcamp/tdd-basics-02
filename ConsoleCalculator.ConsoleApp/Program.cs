using System;

namespace ConsoleCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            ConsoleKeyInfo key;
            Console.WriteLine("Press Ctrl + C to close the program.");
            while (IsKillSwitch(key = Console.ReadKey(true)) == false)
            {
                Console.Clear();
                Console.WriteLine(calculator.SendKeyPress(key.KeyChar));
            }
        }

        private static bool IsKillSwitch(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.C && key.Modifiers == ConsoleModifiers.Control;
        }
    }
}
