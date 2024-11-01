using System.ComponentModel.DataAnnotations;
using HospitalAppointmentSystem.Model.Enums;

namespace HospitalAppointmentSystem.Model.Dtos;

public class CreateDoctorRequest
{
    [Required(ErrorMessage = "Doktor adı zorunludur.")]
    public string Name { get; set; }

    public Branch Branch { get; set; }

    public CreateDoctorRequest() { }

 
}
