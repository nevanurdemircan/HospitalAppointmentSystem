using HospitalAppointmentSystem.Model.Enums;

namespace HospitalAppointmentSystem.Model.Dtos.Responses;

public class AppointmentResponse
{
    public Guid Id { get; set; }
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DoctorId { get; set; }
    public string DoctorName { get; set; }
    public Branch Branch { get; set; }
}