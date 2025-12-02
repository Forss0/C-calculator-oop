

using System;
using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Models;
using DoctorAppointment.Repositories;

namespace DoctorAppointment.Services
{
    public class PatientService
    {
        private readonly IRepository<Patient> _repo;
        private List<Patient> _patients;

        public PatientService(IRepository<Patient> repo)
        {
            _repo = repo;
            _patients = _repo.GetAll() ?? new List<Patient>();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Patients ---");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Show Patients");
                Console.WriteLine("3. Delete Patient");
                Console.WriteLine("0. Back");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": Add(); break;
                    case "2": Show(); break;
                    case "3": Delete(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный выбор."); break;
                }
            }
        }

        private void Add()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            int id = _patients.Count == 0 ? 1 : _patients.Max(p => p.Id) + 1;

            var patient = new Patient
            {
                Id = id,
                Name = name,
                Phone = phone
            };

            _patients.Add(patient);
            _repo.SaveAll(_patients);

            Console.WriteLine("Пациент добавлен.");
        }

        private void Show()
        {
            if (_patients.Count == 0)
            {
                Console.WriteLine("Пациентов нет.");
                return;
            }

            foreach (var p in _patients)
                Console.WriteLine($"{p.Id}. {p.Name} - {p.Phone}");
        }

        private void Delete()
        {
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Некорректный ID.");
                return;
            }

            var p = _patients.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                Console.WriteLine("Пациент не найден.");
                return;
            }

            _patients.Remove(p);
            _repo.SaveAll(_patients);

            Console.WriteLine("Пациент удалён.");
        }
    }
}
