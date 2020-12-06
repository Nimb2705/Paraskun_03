using System;
using System.Globalization;
using IntegralsSpace;

namespace LabWork3
{
    class Program
    {
        public static Integral.IntegralDelegate SelectMethod(char marker)
        {
            switch (char.ToUpper(marker))
            {
                case 'L':
                    return Integral.LeftRectIntegral;
                case 'M':
                    return Integral.MidRectIntegral;
                case 'R':
                    return Integral.RightRectIntegral;
                case 'T':
                    return Integral.TrapIntegral;
                case 'S':
                    return Integral.SimpsonIntegral;
                default:
                    return Integral.LeftRectIntegral;
            }
        }

        private static void EnterData(out double a, out double b, out int n)
        {
            Console.Write("Enter a:");
            a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Enter b:");
            b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Enter n:");
            n = int.Parse(Console.ReadLine());
        }

        private static char GetMethodSelector()
        {
            Console.WriteLine("[L] - Left rectanles");
            Console.WriteLine("[M] - Middle rectanles");
            Console.WriteLine("[R] - Right rectanles");
            Console.WriteLine("[T] - Trapezoid");
            Console.WriteLine("[P] - Parabola");
            Console.Write("Select a method: ");
            char selector = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return selector;
        }
        private static bool CheckContinue()
        {
            Console.Write("Press any key to continue or F4 or Ctrl + Q to exit: ");
            var keyInfo = Console.ReadKey();
            return !((keyInfo.Modifiers == ConsoleModifiers.Control)&(keyInfo.Key == ConsoleKey.Q))&&!(keyInfo.Key == ConsoleKey.F4);
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                char selector = GetMethodSelector();
                Integral.IntegralDelegate method = SelectMethod(selector);
                EnterData(out double a, out double b, out int n);
                double result = method(a, b, n, Integral.Func);
                Console.WriteLine($"Value of integral: {result}");
            } while (CheckContinue());
        }
    }
}