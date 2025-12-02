

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using DoctorAppointment.Models;

namespace DoctorAppointment.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDataStorage _storage;
        private const string FileName = "doctors.data";

        public DoctorRepository(IDataStorage storage)
        {
            _storage = storage;
        }

        public List<Doctor> GetAll()
        {
            return _storage.Load<Doctor>(FileName);
        }

        public Doctor? Get(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Add(Doctor doctor)
        {
            var list = GetAll();
            doctor.Id = list.Count == 0 ? 1 : list.Max(x => x.Id) + 1;
            list.Add(doctor);
            _storage.Save(FileName, list);
        }

        public void Update(Doctor doctor)
        {
            var list = GetAll();
            int i = list.FindIndex(x => x.Id == doctor.Id);

            if (i >= 0)
            {
                list[i] = doctor;
                _storage.Save(FileName, list);
            }
        }

        public void Delete(int id)
        {
            var list = GetAll();
            list.RemoveAll(x => x.Id == id);
            _storage.Save(FileName, list);
        }
    }
}
