
using DoctorAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Doctor : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Specialty { get; set; }
}