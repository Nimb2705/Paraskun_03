using System;
namespace IntegralsSpace
{
    public class Integral
    {
        public delegate double FuncDelegate(double x);
        public delegate double IntegralDelegate(double a, double b, int n, FuncDelegate f);
        public static double Func(double x)=>x * Math.Sin(2 * x - 1);
        public static double LeftRectIntegral(double a, double b, int n, FuncDelegate f)
        {
            double result = 0, h = (b - a) / n;
            for (int i = 0; i < n; ++i)
            {
                result += f(a + i * h);
            }
            return result * h;
        }
        public static double MidRectIntegral(double a, double b, int n, FuncDelegate f)
        {
            double result = 0, h = (b - a) / n;
            for (int i = 0; i < n; ++i)
            {
                result += f(a + (i + 0.5) * h);
            }
            return result * h;
        }
        public static double RightRectIntegral(double a, double b, int n, FuncDelegate f)
        {
            double h = (b - a) / n;
            double sum = 0d;
            for (int i = 1; i <= n; i++)
            {
                double x = a + i * h;
                sum += f(x);
            }
            return h * sum;
        }
        public static double TrapIntegral(double a, double b, int n, FuncDelegate f)
        {
            double sum = 0.0;
            double h = (b - a) / n;
            for (int i = 0; i < n; i++)
                sum += 0.5 * h * (f(a + i * h) + f(a + (i + 1) * h));
            return sum;
        }
        public static double SimpsonIntegral(double a, double b, int n, FuncDelegate f)
        {
            double sum = 0;
            double h = (b - a) / n;
            for (int i = 0; i < n; i++)
                sum += (f(a + h * i) + 4 * f(a + h * (i + 0.5)) + f(a + h * (i + 1)) * h / 3);
            return sum;
        }
    }
}