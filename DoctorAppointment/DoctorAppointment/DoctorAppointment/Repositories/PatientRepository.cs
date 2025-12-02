using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DoctorAppointment.Models;

namespace DoctorAppointment.Repositories
{
    public class PatientRepository
    {
        private readonly IDataStorage storage;
        private const string FileName = "patients.data";

        public PatientRepository(IDataStorage storage)
        {
            this.storage = storage;
        }

        public List<Patient> GetAll()
            => storage.Load<Patient>(FileName);

        public Patient? Get(int id)
            => GetAll().FirstOrDefault(x => x.Id == id);

        public void Add(Patient p)
        {
            var list = GetAll();
            p.Id = list.Count == 0 ? 1 : list.Max(x => x.Id) + 1;
            list.Add(p);
            storage.Save(FileName, list);
        }

        public void Update(Patient p)
        {
            var list = GetAll();
            int i = list.FindIndex(x => x.Id == p.Id);
            if (i >= 0)
            {
                list[i] = p;
                storage.Save(FileName, list);
            }
        }

        public void Delete(int id)
        {
            var list = GetAll();
            list.RemoveAll(x => x.Id == id);
            storage.Save(FileName, list);
        }
    }
}
