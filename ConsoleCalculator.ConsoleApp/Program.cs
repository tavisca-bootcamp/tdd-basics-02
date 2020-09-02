using System;

namespace ConsoleCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            Console.TreatControlCAsInput = true;
            Console.WriteLine("Press Ctrl + C to close the program.");
            var calc = new Calculator();
            while (IsKillSwitch(key = Console.ReadKey(true)) == false)
            {
                Console.Clear();
                Console.WriteLine(calc.SendKeyPress(key.KeyChar));
            }
        }

        private static bool IsKillSwitch(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.C && key.Modifiers == ConsoleModifiers.Control;
        }
    }
}
