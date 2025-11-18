

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

public interface IDoctorRepository
{
    List<Doctor> GetAll();
    Doctor Get(int id);
    void Add(Doctor d);
    void Update(Doctor d);
    void Delete(int id);
}
