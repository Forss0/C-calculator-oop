using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAppointmentRepository
{
    List<Appointment> GetAll();
    Appointment Get(int id);
    void Add(Appointment a);
    void Update(Appointment a);
    void Delete(int id);
}
