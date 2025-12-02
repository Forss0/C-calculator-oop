using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Models
{
    public class Patient : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class Doctor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
    }

    public class Appointment : IEntity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
