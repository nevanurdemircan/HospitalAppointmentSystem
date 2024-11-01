using AutoMapper;
using HospitalAppointmentSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Abstracts;

public interface IAppointmentRepository
{
    List<Appointment> GetAll();
    Appointment? GetById(Guid id);
    void Add(Appointment appointment);
    void Update(Appointment appointment);
    void Remove(Appointment appointment);
    IQueryable<Appointment> Appointments { get; }
    Task SaveChangesAsync();


}