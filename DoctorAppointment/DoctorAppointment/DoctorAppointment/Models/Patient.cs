

using DoctorAppointment.Models;

public class Patient : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

}