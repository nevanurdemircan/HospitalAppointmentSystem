using HospitalAppointmentSystem.Model.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitalAppointmentSystem.Model.Dtos.Responses;

public class DoctorResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Branch Branch { get; set; }
    public List<AppointmentResponse> Patients { get; set; }

    public DoctorResponse()
    {
        
    }
}