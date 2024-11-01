using HospitalAppointmentSystem.Model.Dtos;
using HospitalAppointmentSystem.Model.Dtos.Responses;
using HospitalAppointmentSystem.Model.Entities;

namespace HospitalAppointmentSystem.Service.Abstracts;

public interface IAppointmentService
{
    List<AppointmentResponse> GetAll();
  
    AppointmentResponse? GetById(Guid id);
    AppointmentResponse Add(AppointmentCreateRequest create);
    AppointmentResponse Update(AppointmentUpdateRequest update);
    AppointmentResponse? Delete(Guid id);

}