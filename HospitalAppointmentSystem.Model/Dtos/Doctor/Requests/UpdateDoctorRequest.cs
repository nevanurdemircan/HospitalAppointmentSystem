using System.ComponentModel.DataAnnotations;
using HospitalAppointmentSystem.Model.Enums;

namespace HospitalAppointmentSystem.Model.Dtos;

public class UpdateDoctorRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Doktor adı zorunludur.")]
    public string Name { get; set; }

    public Branch Branch { get; set; }

    public UpdateDoctorRequest() { }

 
}
