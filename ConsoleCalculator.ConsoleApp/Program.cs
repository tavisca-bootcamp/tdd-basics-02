using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            ConsoleKeyInfo key;
            Console.WriteLine("0");
           
            while (IsKillSwitch(key = Console.ReadKey(true)) == false)
            {
                Console.Clear();
                calc.SendKeyPress(key.KeyChar);
                break;
            }
            Console.Clear();
          }

        private static bool IsKillSwitch(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.X || key.Modifiers == ConsoleModifiers.Control;
        }
    }
}
