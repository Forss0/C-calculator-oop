
using System;
using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Models;
using DoctorAppointment.Repositories;

namespace DoctorAppointment.Services
{
    public class AppointmentService
    {
        private readonly IRepository<Appointment> _repo;
        private List<Appointment> _list;

        public AppointmentService(IRepository<Appointment> repo)
        {
            _repo = repo;
            _list = _repo.GetAll() ?? new List<Appointment>();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Appointments ---");
                Console.WriteLine("1. Add Appointment");
                Console.WriteLine("2. Show Appointments");
                Console.WriteLine("3. Delete Appointment");
                Console.WriteLine("0. Back");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": Add(); break;
                    case "2": Show(); break;
                    case "3": Delete(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        private void Add()
        {
            Console.Write("Doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Console.WriteLine("Invalid Doctor ID.");
                return;
            }

            Console.Write("Patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                Console.WriteLine("Invalid Patient ID.");
                return;
            }

            Console.Write("Date (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime visitDate))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            int id = _list.Count == 0 ? 1 : _list.Max(a => a.Id) + 1;

            var appointment = new Appointment
            {
                Id = id,
                DoctorId = doctorId,
                PatientId = patientId,
                VisitDate = visitDate
            };

            _list.Add(appointment);
            _repo.SaveAll(_list);

            Console.WriteLine("Appointment added.");
        }

        private void Show()
        {
            if (_list.Count == 0)
            {
                Console.WriteLine("No appointments found.");
                return;
            }

            foreach (var a in _list)
                Console.WriteLine($"{a.Id}. Doctor {a.DoctorId}, Patient {a.PatientId}, Date {a.VisitDate}");
        }

        private void Delete()
        {
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var a = _list.FirstOrDefault(x => x.Id == id);
            if (a == null)
            {
                Console.WriteLine("Appointment not found!");
                return;
            }

            _list.Remove(a);
            _repo.SaveAll(_list);

            Console.WriteLine("Appointment deleted.");
        }
    }
}
