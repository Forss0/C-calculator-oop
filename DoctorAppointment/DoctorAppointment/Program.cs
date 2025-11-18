
using DoctorAppointment.Services;
using DoctorAppointment.Repositories;
namespace DoctorAppointment.Models;

using System;

class Program
{
    static void Main()
    {
        var patientService = new PatientService(new PatientRepository());
        var appointmentService = new AppointmentService(new AppointmentRepository());
        var doctorService = new DoctorService(new DoctorRepository());

        bool running = true;
        Console.OutputEncoding = System.Text.Encoding.UTF8;


        while (running)
        {
            Console.WriteLine("\n=== MAIN MENU ===");
            Console.WriteLine("1. Doctors");
            Console.WriteLine("2. Patients");
            Console.WriteLine("3. Appointments");
            Console.WriteLine("4. Exit");

            Console.Write("Select: ");
            int choice = int.Parse(Console.ReadLine());

            switch ((Menu)choice)
            {
                case Menu.Doctors:
                    doctorService.Menu();
                    break;

                case Menu.Patients:
                    patientServiceMenu(patientService);
                    break;

                case Menu.Appointments:
                    appointmentService.Menu();
                    break;

                case Menu.Exit:
                    running = false;
                    break;
            }
        }
    }

    static void patientServiceMenu(PatientService service)
    {
        bool run = true;
        while (run)
        {
            Console.WriteLine("\n--- Patients ---");
            Console.WriteLine("1. List");
            Console.WriteLine("2. Add");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Back");

            Console.Write("Select: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: service.ShowAll(); break;
                case 2: service.Create(); break;
                case 3: service.Update(); break;
                case 4: service.Delete(); break;
                case 5: run = false; break;
            }
        }
    }
}
