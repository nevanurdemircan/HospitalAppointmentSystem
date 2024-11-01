using DataAccess.Abstracts;
using DataAccess.Context;
using HospitalAppointmentSystem.Model.Dtos.Responses;
using HospitalAppointmentSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes;

public class EfDoctorRepository : IDoctorRepository
{
    private PostgreContext _context;

    public EfDoctorRepository(PostgreContext context)
    {
        _context = context;
    }

    public List<Doctor> GetAllPatients()
    {
        return _context.Doctors
            .Include(d => d.Patients)
            .ToList();
    }

    public List<Doctor> GetAll()
    {
        return _context.Doctors.ToList();
    }

    public Doctor? GetById(int id)
    {
        return _context.Doctors
            .Include(d => d.Patients)
            .FirstOrDefault(d => d.Id == id);
    }

    public void Add(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
    }

    public void Update(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
    }

    public void Remove(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}