using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Model.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Hasta adı zorunludur.")]
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}