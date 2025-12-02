using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Repositories
{
    public interface IDataStorage
    {
        void Save<T>(string file, List<T> data);
        List<T> Load<T>(string file);
    }
}
