using AutoMapper;
using DataAccess.Abstracts;
using Exceptions;
using HospitalAppointmentSystem.Model.Dtos;
using HospitalAppointmentSystem.Model.Dtos.Responses;
using HospitalAppointmentSystem.Model.Entities;
using HospitalAppointmentSystem.Service.Abstracts;
using HospitalAppointmentSystem.Service.util;
using ValidationException = Exceptions.ValidationException;
using NotFoundException = Exceptions.NotFoundException;

namespace HospitalAppointmentSystem.Service.Concretes;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    private readonly AppointmentValidation _appointmentValidation;

    public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper,
        AppointmentValidation appointmentValidation)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
        _appointmentValidation = appointmentValidation;
    }

    public List<AppointmentResponse> GetAll()
    {
        try
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();
            return _mapper.Map<List<AppointmentResponse>>(appointments);
        }
        catch (Exception ex)
        {
            throw new ValidationException($"Randevular alınırken bir hata oluştu: {ex.Message}");
        }
    }

    public AppointmentResponse GetById(Guid id)
    {
        try
        {
            var appointment = _appointmentRepository.GetById(id);
            if (appointment == null)
            {
                throw new NotFoundException("Randevu bulunamadı");
            }

            var appointmentResponse = _mapper.Map<AppointmentResponse>(appointment);
            return appointmentResponse;
        }
        catch (Exception ex)
        {
            throw new ValidationException($"Kimliğe göre randevu alınırken bir hata oluştu: {ex.Message}");
        }
    }


    public AppointmentResponse Add(AppointmentCreateRequest create)
    {
        try
        {
            _appointmentValidation.AddValidate(create);

            var appointment = _mapper.Map<Appointment>(create);
            _appointmentRepository.Add(appointment);
            _appointmentRepository.SaveChangesAsync().Wait();

            return _mapper.Map<AppointmentResponse>(appointment);
        }
        catch (Exception ex)
        {
            throw new ValidationException($"Randevu eklenirken bir hata oluştu: {ex.Message}");
        }
    }

    public AppointmentResponse Update(AppointmentUpdateRequest update)
    {
        if (update == null)
        {
            throw new BaseBusinessException("request null olamaz");
        }

        var appointment = _appointmentRepository.Appointments
            .FirstOrDefault(a => a.Id == update.Id);
        if (appointment == null)
        {
            throw new NotFoundException("Randevu bulunamadı");
        }

        _mapper.Map(update, appointment);
        _appointmentRepository.Update(appointment);
        _appointmentRepository.SaveChangesAsync();


        var result = _mapper.Map<AppointmentResponse>(appointment);
        if (result == null)
        {
            throw new BaseBusinessException($"Appointment with ID {result.Id} not found.");
        }

        return result;
    }

    public AppointmentResponse? Delete(Guid id)
    {
        Appointment? appointment = _appointmentRepository.GetById(id);

        if (appointment == null)
        {
            throw new NotFoundException("Randevu bulunamadı");
        }

        if (appointment.AppointmentDate < DateTime.Now)
        {
            _appointmentRepository.Remove(appointment);
            _appointmentRepository.SaveChangesAsync();
            return _mapper.Map<AppointmentResponse>(appointment);
        }

        return null;
    }
}