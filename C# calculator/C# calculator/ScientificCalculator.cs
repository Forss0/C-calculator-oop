

using System;

namespace CalculatorLib
{
    public class ScientificCalculator : Calculator
    {
        // Перевизначення Divide з додатковою перевіркою
        public override double Divide(double a, double b)
        {
            if (double.IsNaN(a) || double.IsNaN(b))
                throw new InvalidOperationException("Некоректні дані!");

            // Виклик базового методу
            return base.Divide(a, b);
        }

        public double Pow(double a, double b)
        {
            LastResult = Math.Pow(a, b);
            return LastResult;
        }

        public double Sqrt(double a)
        {
            if (a < 0)
                throw new InvalidOperationException("Корінь з від’ємного числа неможливий!");
            LastResult = Math.Sqrt(a);
            return LastResult;
        }
    }
}
