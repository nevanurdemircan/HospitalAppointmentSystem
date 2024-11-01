using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Model.Dtos;

public class AppointmentUpdateRequest
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Hasta adı zorunludur.")]
    public string PatientName { get; set; }

    public DateTime AppointmentDate { get; set; }

    public int DoctorId { get; set; }

    public AppointmentUpdateRequest()
    {
    }
}