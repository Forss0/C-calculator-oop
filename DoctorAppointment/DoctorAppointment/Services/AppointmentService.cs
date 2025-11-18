

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

public class AppointmentService
{
    private readonly IAppointmentRepository _repo;

    public AppointmentService(IAppointmentRepository repo)
    {
        _repo = repo;
    }

    public void ShowAll()
    {
        Console.WriteLine("\nСписок записей:");
        foreach (var a in _repo.GetAll())
            Console.WriteLine($"{a.Id}. Доктор #{a.DoctorId}, Пациент #{a.PatientId}, Дата: {a.VisitDate}");
    }

    public void Create()
    {
        Console.Write("ID доктора: ");
        int doctorId = int.Parse(Console.ReadLine());

        Console.Write("ID пациента: ");
        int patientId = int.Parse(Console.ReadLine());

        Console.Write("Дата визита (гггг-мм-дд чч:мм): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        _repo.Add(new Appointment
        {
            DoctorId = doctorId,
            PatientId = patientId,
            VisitDate = date
        });

        Console.WriteLine("Запись добавлена!");
    }

    public void Update()
    {
        Console.Write("ID записи: ");
        int id = int.Parse(Console.ReadLine());

        var a = _repo.Get(id);
        if (a == null)
        {
            Console.WriteLine("Запись не найдена!");
            return;
        }

        Console.Write("Новый ID доктора: ");
        a.DoctorId = int.Parse(Console.ReadLine());

        Console.Write("Новый ID пациента: ");
        a.PatientId = int.Parse(Console.ReadLine());

        Console.Write("Новая дата визита: ");
        a.VisitDate = DateTime.Parse(Console.ReadLine());

        _repo.Update(a);

        Console.WriteLine("Запись обновлена!");
    }

    public void Delete()
    {
        Console.Write("ID записи: ");
        int id = int.Parse(Console.ReadLine());

        _repo.Delete(id);

        Console.WriteLine("Запись удалена!");
    }

    public void Menu()
    {
        bool run = true;

        while (run)
        {
            Console.WriteLine("\n--- APPOINTMENTS ---");
            Console.WriteLine("1. Показать все");
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
