using AutoMapper;
using HospitalAppointmentSystem.Model.Dtos;
using HospitalAppointmentSystem.Model.Dtos.Responses;
using HospitalAppointmentSystem.Model.Entities;

namespace HospitalAppointmentSystem.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AppointmentCreateRequest, Appointment>();
        CreateMap<AppointmentUpdateRequest, Appointment>();
        CreateMap<Appointment, AppointmentResponse>();
        
        CreateMap<CreateDoctorRequest, Doctor>();
        CreateMap<UpdateDoctorRequest, Doctor>();
        CreateMap<Doctor, DoctorResponse>();
    }
}