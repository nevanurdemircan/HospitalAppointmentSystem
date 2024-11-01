using DataAccess.Abstracts;
using DataAccess.Context;
using HospitalAppointmentSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes;

public class EfAppointmentRepository : IAppointmentRepository
{
    private readonly PostgreContext _context;

    public EfAppointmentRepository(PostgreContext context)
    {
        _context = context;
    }

    public List<Appointment> GetAll()
    {
        return _context.Appointments
            .Include(x => x.Doctor)
            .ToList();
    }

    public Appointment? GetById(Guid id)
    {
        Appointment appointment = _context.Appointments
            .Include(x => x.Doctor)
            .SingleOrDefault(x => x.Id == id);
        return appointment;
    }

    public void Add(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
    }

    public void Update(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
    }

    public void Remove(Appointment appointment)
    {
        _context.Appointments.Remove(appointment); 
    }

    public IQueryable<Appointment> Appointments => _context.Appointments.Include(a => a.Doctor);

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}