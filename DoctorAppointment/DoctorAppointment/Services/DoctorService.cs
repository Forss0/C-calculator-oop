

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DoctorAppointment.Repositories;

namespace DoctorAppointment.Services;
public class DoctorService
{
    private readonly IDoctorRepository _repo;

    public DoctorService(IDoctorRepository repo)
    {
        _repo = repo;
    }

    public void ShowAll()
    {
        Console.WriteLine("\nСписок докторов:");
        foreach (var d in _repo.GetAll())
            Console.WriteLine($"{d.Id}. {d.Name} — {d.Specialization}");
    }

    public void Create()
    {
        Console.Write("Имя доктора: ");
        string name = Console.ReadLine();

        Console.Write("Специализация: ");
        string spec = Console.ReadLine();

        _repo.Add(new Doctor
        {
            Name = name,
            Specialization = spec
        });

        Console.WriteLine("Доктор добавлен!");
    }

    public void Update()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        var d = _repo.Get(id);
        if (d == null)
        {
            Console.WriteLine("Доктор не найден!");
            return;
        }

        Console.Write("Новое имя: ");
        d.Name = Console.ReadLine();

        Console.Write("Новая специализация: ");
        d.Specialization = Console.ReadLine();

        _repo.Update(d);

        Console.WriteLine("Доктор обновлён!");
    }

    public void Delete()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        _repo.Delete(id);

        Console.WriteLine("Доктор удалён!");
    }

    public void Menu()
    {
        bool run = true;

        while (run)
        {
            Console.WriteLine("\n--- DOCTORS ---");
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
