
using DoctorAppointment.Models;
using DoctorAppointment.Repositories;

namespace DoctorAppointment.Services;

public class DoctorService
{
    private readonly IRepository<Doctor> _repo;
    private List<Doctor> _doctors;

    public DoctorService(IRepository<Doctor> repo)
    {
        _repo = repo;
        _doctors = _repo.GetAll();
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Doctors ---");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Show Doctors");
            Console.WriteLine("3. Delete Doctor");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");

            switch (Console.ReadLine())
            {
                case "1": Add(); break;
                case "2": Show(); break;
                case "3": Delete(); break;
                case "0": return;
            }
        }
    }

    private void Add()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Specialization: ");
        string spec = Console.ReadLine();

        int id = _doctors.Count == 0 ? 1 : _doctors.Max(d => d.Id) + 1;

        _doctors.Add(new Doctor
        {
            Id = id,
            Name = name,
            Specialty = spec
        });

        _repo.SaveAll(_doctors);
    }

    private void Show()
    {
        foreach (var d in _doctors)
            Console.WriteLine($"{d.Id}. {d.Name} - {d.Specialty}");
    }

    private void Delete()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        var doc = _doctors.FirstOrDefault(x => x.Id == id);
        if (doc == null)
        {
            Console.WriteLine("Not found!");
            return;
        }

        _doctors.Remove(doc);
        _repo.SaveAll(_doctors);
    }
}
