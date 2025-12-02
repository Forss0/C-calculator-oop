using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

public interface IPatientRepository
{
    List<Patient> GetAll();
    Patient Get(int id);
    void Add(Patient p);
    void Update(Patient p);
    void Delete(int id);
}
