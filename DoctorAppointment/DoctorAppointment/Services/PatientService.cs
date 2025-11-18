

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

public class PatientService
{
    private readonly IPatientRepository _repo;

    public PatientService(IPatientRepository repo)
    {
        _repo = repo;
    }

    public void ShowAll()
    {
        Console.WriteLine("\nСписок пациентов:");
        foreach (var p in _repo.GetAll())
            Console.WriteLine($"{p.Id}. {p.FullName} — {p.Age} лет");
    }

    public void Create()
    {
        Console.Write("ФИО: ");
        string name = Console.ReadLine();

        Console.Write("Возраст: ");
        int age = int.Parse(Console.ReadLine());

        _repo.Add(new Patient
        {
            FullName = name,
            Age = age
        });

        Console.WriteLine("Пациент добавлен!");
    }

    public void Update()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        var p = _repo.Get(id);
        if (p == null)
        {
            Console.WriteLine("Пациент не найден!");
            return;
        }

        Console.Write("Новое ФИО: ");
        p.FullName = Console.ReadLine();

        Console.Write("Новый возраст: ");
        p.Age = int.Parse(Console.ReadLine());

        _repo.Update(p);

        Console.WriteLine("Пациент обновлён!");
    }

    public void Delete()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        _repo.Delete(id);

        Console.WriteLine("Пациент удалён!");
    }

    public void Menu()
    {
        bool run = true;

        while (run)
        {
            Console.WriteLine("\n--- PATIENTS ---");
            Console.WriteLine("1. Показать всех");
            Console.WriteLine("2. Добавить");
            Console.WriteLine("3. Обновить");
            Console.WriteLine("4. Удалить");
            Console.WriteLine("5. Назад");

            Console.Write("Выбор: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: ShowAll(); break;
                case 2: Create(); break;
                case 3: Update(); break;
                case 4: Delete(); break;
                case 5: run = false; break;
                default: Console.WriteLine("Неверный выбор!"); break;
            }
        }
    }
}
