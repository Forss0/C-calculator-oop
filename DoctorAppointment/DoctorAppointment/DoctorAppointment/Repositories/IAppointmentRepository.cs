

using System;

public class IAppointmentRepository
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime VisitDate { get; set; }
}
