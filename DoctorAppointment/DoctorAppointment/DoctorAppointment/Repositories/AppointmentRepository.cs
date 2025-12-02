

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using DoctorAppointment.Models;
using DoctorAppointment.Repositories;

namespace DoctorAppointment.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private const string FileName = "appointments.json";
        private List<Appointment> _appointments;

        public AppointmentRepository()
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                _appointments = JsonSerializer.Deserialize<List<Appointment>>(json) ?? new List<Appointment>();
            }
            else
            {
                _appointments = new List<Appointment>();
            }
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(_appointments, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);
        }

        public List<Appointment> GetAll() => _appointments;

        public Appointment Get(int id) => _appointments.FirstOrDefault(x => x.Id == id);

        public void Add(Appointment a)
        {
            a.Id = _appointments.Count == 0 ? 1 : _appointments.Max(x => x.Id) + 1;
            _appointments.Add(a);
            Save();
        }

        public void Update(Appointment a)
        {
            var ap = Get(a.Id);
            if (ap == null) return;

            ap.DoctorId = a.DoctorId;
            ap.PatientId = a.PatientId;
            ap.VisitDate = a.VisitDate;

            Save();
        }

        public void Delete(int id)
        {
            var ap = Get(id);
            if (ap != null)
            {
                _appointments.Remove(ap);
                Save();
            }
        }
    }
}
