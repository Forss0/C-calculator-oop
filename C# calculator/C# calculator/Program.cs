
using System;
using CalculatorLib;

namespace CalculatorApp
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Виберіть тип калькулятора:");
            Console.WriteLine("1. Звичайний");
            Console.WriteLine("2. Науковий");
            Console.Write("Ваш вибір: ");

            string? choice = Console.ReadLine();
            Calculator calc = choice == "2" ? new ScientificCalculator() : new Calculator();

            while (true)
            {
                Console.WriteLine("\n=== Меню ===");
                Console.WriteLine("1. + Додавання");
                Console.WriteLine("2. - Віднімання");
                Console.WriteLine("3. * Множення");
                Console.WriteLine("4. / Ділення");
                if (calc is ScientificCalculator)
                {
                    Console.WriteLine("5. Степінь");
                    Console.WriteLine("6. Квадратний корінь");
                }
                Console.WriteLine("0. Вихід");
                Console.Write("Операція: ");

                string? op = Console.ReadLine();
                if (op == "0") break;

                try
                {
                    double a, b;
                    switch (op)
                    {
                        case "1":
                            (a, b) = ReadTwo();
                            Console.WriteLine("Результат: " + calc.Add(a, b));
                            break;
                        case "2":
                            (a, b) = ReadTwo();
                            Console.WriteLine("Результат: " + calc.Subtract(a, b));
                            break;
                        case "3":
                            (a, b) = ReadTwo();
                            Console.WriteLine("Результат: " + calc.Multiply(a, b));
                            break;
                        case "4":
                            (a, b) = ReadTwo();
                            Console.WriteLine("Результат: " + calc.Divide(a, b));
                            break;
                        case "5" when calc is ScientificCalculator sci:
                            (a, b) = ReadTwo();
                            Console.WriteLine("Результат: " + sci.Pow(a, b));
                            break;
                        case "6" when calc is ScientificCalculator sci2:
                            a = Read("Введіть число: ");
                            Console.WriteLine("Результат: " + sci2.Sqrt(a));
                            break;
                        default:
                            Console.WriteLine("Невірний вибір!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка: " + ex.Message);
                }
            }

            Console.WriteLine("До побачення!");
        }

        static (double, double) ReadTwo()
        {
            double a = Read("Перше число: ");
            double b = Read("Друге число: ");
            return (a, b);
        }

        static double Read(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (double.TryParse(Console.ReadLine(), out double n))
                    return n;
                Console.WriteLine("Некоректне число, спробуйте ще раз.");
            }
        }
    }
}
