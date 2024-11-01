using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using HospitalAppointmentSystem.Model.Enums;

namespace HospitalAppointmentSystem.Model.Entities;

public class Doctor
{
    public int Id { get; set; }
  
    [Required(ErrorMessage = "Doktor adı zorunludur.")]
    public string Name { get; set; }
  
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public Branch Branch { get; set; }
    public List<Appointment> Patients { get; set; }
}