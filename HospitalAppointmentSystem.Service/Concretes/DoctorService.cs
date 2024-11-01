using AutoMapper;
using DataAccess.Abstracts;
using Exceptions;
using HospitalAppointmentSystem.Model.Dtos;
using HospitalAppointmentSystem.Model.Dtos.Responses;
using HospitalAppointmentSystem.Model.Entities;
using HospitalAppointmentSystem.Service.Abstracts;

namespace HospitalAppointmentSystem.Service.Concretes;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;

    public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public List<DoctorResponse> GetAllPatients()
    {
        try
        {
            List<Doctor> doctors = _doctorRepository.GetAllPatients();
            var doctorResponses = _mapper.Map<List<DoctorResponse>>(doctors);
            return doctorResponses;
        }
        catch (AutoMapperMappingException autoMapperEx)
        {
            throw new ValidationException(
                $"Doktorları getirirken bir hata oluştu: {autoMapperEx.InnerException?.Message} | Hata Detayları: {autoMapperEx.Message}");
        }
        catch (Exception ex)
        {
            throw new ValidationException($"Doktorları getirirken bir hata oluştu: {ex.Message}");
        }
    }

    public List<DoctorResponse> GetAll()
    {
        List<Doctor> doctors = _doctorRepository.GetAll();
        var doctorResponses = _mapper.Map<List<DoctorResponse>>(doctors);
        return doctorResponses;
    }

    public DoctorResponse? GetById(int id)
    {
        var doctor = _doctorRepository.GetById(id);
        if (doctor == null)
        {
            throw new KeyNotFoundException("Doctor not found");
        }

        var doctorResponse = _mapper.Map<DoctorResponse>(doctor);
        return doctorResponse;
    }

    public DoctorResponse Add(CreateDoctorRequest create)
    {
        if (string.IsNullOrWhiteSpace(create.Name))
        {
            throw new InvalidOperationException("Doktor adı boş olamaz.");
        }

        var doctor = _mapper.Map<Doctor>(create);
        _doctorRepository.Add(doctor);
        _doctorRepository.SaveChangesAsync().Wait();

        var doctorResponse = _mapper.Map<DoctorResponse>(doctor);
        return doctorResponse;
    }

    public DoctorResponse? Update(UpdateDoctorRequest update)
    {
        var doctor = _doctorRepository.GetById(update.Id);
        if (doctor == null)
        {
            return null;
        }

        if (string.IsNullOrWhiteSpace(update.Name))
        {
            throw new InvalidOperationException("Doktor adı boş olamaz.");
        }

        _mapper.Map(update, doctor);
        _doctorRepository.Update(doctor);
        _doctorRepository.SaveChangesAsync().Wait();

        var doctorResponse = _mapper.Map<DoctorResponse>(doctor);
        return doctorResponse;
    }

    public DoctorResponse? Delete(int id)
    {
        var doctor = _doctorRepository.GetById(id);
        if (doctor == null)
        {
            return null;
        }

        _doctorRepository.Remove(doctor);
        _doctorRepository.SaveChangesAsync().Wait();
        var doctorResponse = _mapper.Map<DoctorResponse>(doctor);
        return doctorResponse;
    }
}