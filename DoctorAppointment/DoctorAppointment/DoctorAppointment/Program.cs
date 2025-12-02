

using DoctorAppointment.Models;
using DoctorAppointment.Repositories;
using DoctorAppointment.Services;

Console.WriteLine("Choose storage:");
Console.WriteLine("1 — JSON");
Console.WriteLine("2 — XML");

IRepository<Doctor> doctorRepo;
IRepository<Patient> patientRepo;
IRepository<Appointment> appointRepo;

string choice = Console.ReadLine();

if (choice == "1")
{
    doctorRepo = new JsonRepository<Doctor>("doctors.json");
    patientRepo = new JsonRepository<Patient>("patients.json");
    appointRepo = new JsonRepository<Appointment>("appointments.json");
}
else
{
    doctorRepo = new XmlRepository<Doctor>("doctors.xml");
    patientRepo = new XmlRepository<Patient>("patients.xml");
    appointRepo = new XmlRepository<Appointment>("appointments.xml");
}

var doctorService = new DoctorService(doctorRepo);
var patientService = new PatientService(patientRepo);
var appointmentService = new AppointmentService(appointRepo);

while (true)
{
    Console.WriteLine("\n=== MAIN MENU ===");
    Console.WriteLine("1. Doctors");
    Console.WriteLine("2. Patients");
    Console.WriteLine("3. Appointments");
    Console.WriteLine("0. Exit");

    switch (Console.ReadLine())
    {
        case "1": doctorService.Menu(); break;
        case "2": patientService.Menu(); break;
        case "3": appointmentService.Menu(); break;
        case "0": return;
    }
}
