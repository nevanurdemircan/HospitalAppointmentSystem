using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Model.Dtos;

public class AppointmentCreateRequest
{
    [Required(ErrorMessage = "Hasta adı zorunludur.")]
    public string PatientName { get; set; }

    public DateTime AppointmentDate { get; set; }

    public int DoctorId { get; set; }

    public AppointmentCreateRequest()
    {
    }
}