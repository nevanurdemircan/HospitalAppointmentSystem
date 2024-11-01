using HospitalAppointmentSystem.Model.Dtos;
using HospitalAppointmentSystem.Model.Dtos.Responses;
using HospitalAppointmentSystem.Model.Entities;

namespace HospitalAppointmentSystem.Service.Abstracts;

public interface IDoctorService
{
    List<DoctorResponse> GetAllPatients();
    List<DoctorResponse> GetAll();
    DoctorResponse? GetById(int id);
    DoctorResponse Add(CreateDoctorRequest create);
    DoctorResponse Update(UpdateDoctorRequest update);
    
    DoctorResponse? Delete(int id);

}