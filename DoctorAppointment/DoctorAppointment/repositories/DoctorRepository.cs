

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DoctorAppointment.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private const string FileName = "doctors.json";
        private List<Doctor> _doctors;

        public DoctorRepository()
        {
            if (File.Exists(FileName))
                _doctors = JsonSerializer.Deserialize<List<Doctor>>(File.ReadAllText(FileName));
            else
                _doctors = new List<Doctor>();
        }

        private void Save() =>
            File.WriteAllText(FileName, JsonSerializer.Serialize(_doctors, new JsonSerializerOptions { WriteIndented = true }));

        public List<Doctor> GetAll() => _doctors;

        public Doctor Get(int id) => _doctors.FirstOrDefault(x => x.Id == id);

        public void Add(Doctor d)
        {
            d.Id = _doctors.Count == 0 ? 1 : _doctors.Max(x => x.Id) + 1;
            _doctors.Add(d);
            Save();
        }

        public void Update(Doctor d)
        {
            var doc = Get(d.Id);
            if (doc == null) return;

            doc.Name = d.Name;
            doc.Specialization = d.Specialization;

            Save();
        }

        public void Delete(int id)
        {
            var d = Get(id);
            if (d != null)
            {
                _doctors.Remove(d);
                Save();
            }
        }
    }
}
