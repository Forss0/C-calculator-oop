using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;

public class PatientRepository : IPatientRepository
{
    private const string FileName = "patients.json";
    private List<Patient> _patients;

    public PatientRepository()
    {
        if (File.Exists(FileName))
            _patients = JsonSerializer.Deserialize<List<Patient>>(File.ReadAllText(FileName));
        else
            _patients = new List<Patient>();
    }

    private void Save() =>
        File.WriteAllText(FileName, JsonSerializer.Serialize(_patients, new JsonSerializerOptions { WriteIndented = true }));


    public List<Patient> GetAll() => _patients;
    public Patient Get(int id) => _patients.FirstOrDefault(x => x.Id == id);

    public void Add(Patient patient)
    {
        patient.Id = _patients.Count == 0 ? 1 : _patients.Max(x => x.Id) + 1;
        _patients.Add(patient);
        Save();
    }

    public void Update(Patient patient)
    {
        var p = Get(patient.Id);
        if (p == null) return;
        p.FullName = patient.FullName;
        p.Age = patient.Age;
        Save();
    }

    public void Delete(int id)
    {
        var p = Get(id);
        if (p != null)
        {
            _patients.Remove(p);
            Save();
        }
    }
}
