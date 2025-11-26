

using System;

namespace Garbage_collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // === Тестування класу "П'єса" ===
            Console.WriteLine("\n=== Тестування класу П'єса ===");

            using (Play play = new Play("Ревізор", "Колобок", "Комедія", 1836))
            {
                Console.WriteLine("Вивід інформації про п'єсу:");
                play.ShowInfo();
            }

            // === Тестування класу "Магазин" ===
            Console.WriteLine("\n=== Тестування класу Магазин ===");

            using (Store store = new Store("АТБ", "Прилуки, вул. Київська 291", StoreType.Household))
            {
                Console.WriteLine("Вивід інформації про магазин:");
                store.ShowInfo();
            }

            Console.WriteLine("\nТестування завершено.\n");
        }
    }
}
