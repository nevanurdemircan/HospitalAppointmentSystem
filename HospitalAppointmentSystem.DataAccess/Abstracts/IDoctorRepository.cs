using HospitalAppointmentSystem.Model.Dtos.Responses;
using HospitalAppointmentSystem.Model.Entities;

namespace DataAccess.Abstracts;

public interface IDoctorRepository
{
    List<Doctor> GetAllPatients();
    List<Doctor> GetAll();
    Doctor? GetById(int id);
    void Add(Doctor doctor);
    void Update(Doctor doctor);
    
    void Remove(Doctor doctor);
    
    Task SaveChangesAsync();

}