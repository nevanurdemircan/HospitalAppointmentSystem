using DataAccess.Abstracts;
using Exceptions;
using HospitalAppointmentSystem.Model.Dtos;

namespace HospitalAppointmentSystem.Service.util;

public class AppointmentValidation
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentValidation(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public void AddValidate(AppointmentCreateRequest createRequest)
    {
        MinDayValidation(3, createRequest);
        IsDoctorAppointmentPoolFull(10, createRequest);
    }

    public void IsDoctorAppointmentPoolFull(int maxCount, AppointmentCreateRequest createRequest)
    {
        var currentAppointmentsCount = _appointmentRepository.GetAll()
            .Count(a => a.DoctorId == createRequest.DoctorId && a.AppointmentDate >= DateTime.Now);

        if (currentAppointmentsCount >= maxCount)
        {
            throw new ValidationException("Doktor dolu");
        }
    }

    public void MinDayValidation(int dayCount, AppointmentCreateRequest createRequest)
    {
        var minAppointmentDate = DateTime.Now.AddDays(dayCount);

        if (createRequest.AppointmentDate < minAppointmentDate)
        {
            throw new ValidationException("Minimum 3 gün sonrası için randevu alınız.");
        }
    }
}