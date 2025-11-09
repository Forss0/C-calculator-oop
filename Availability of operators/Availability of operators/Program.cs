

using System;
using Availability_of_operators.Work.Models;
using Availability_of_operators.Work.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Тест класу Employee ===");
        Employee e1 = new Employee(5000);
        Employee e2 = new Employee(7000);

        e1 += 500;
        e2 -= 1000;

        Console.WriteLine($"Зарплата e1: {e1.Salary}");
        Console.WriteLine($"Зарплата e2: {e2.Salary}");
        Console.WriteLine($"Рівні зарплати? {(e1 == e2)}");


        Console.WriteLine("\n=== Тест класу City ===");
        City c1 = new City(1000000);
        City c2 = new City(500000);

        c1 += 10000;
        c2 -= 20000;

        Console.WriteLine($"c1: {c1.Population}");
        Console.WriteLine($"c2: {c2.Population}");
        Console.WriteLine($"c1 > c2 ? {(c1 > c2)}");


        Console.WriteLine("\n=== Тест класу CreditCard ===");
        CreditCard card1 = new CreditCard(1000, 123);
        CreditCard card2 = new CreditCard(5000, 123);

        card1 += 500;
        card2 -= 1000;

        Console.WriteLine($"card1 гроші: {card1.Money}");
        Console.WriteLine($"card2 гроші: {card2.Money}");
        Console.WriteLine($"CVC однаковий? {(card1 == card2)}");



        Console.WriteLine("\n=== Тест класу Matrix ===");

        Matrix m1 = new Matrix(2, 2);
        Matrix m2 = new Matrix(2, 2);

        m1[0, 0] = 1; m1[0, 1] = 2;
        m1[1, 0] = 3; m1[1, 1] = 4;

        m2[0, 0] = 5; m2[0, 1] = 6;
        m2[1, 0] = 7; m2[1, 1] = 8;

        Matrix sum = m1 + m2;

        Console.WriteLine("Результат додавання:");
        Console.WriteLine($"{sum[0, 0]} {sum[0, 1]}");
        Console.WriteLine($"{sum[1, 0]} {sum[1, 1]}");
    }
}
