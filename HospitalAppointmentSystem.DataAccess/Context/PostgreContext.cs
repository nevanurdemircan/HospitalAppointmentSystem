using HospitalAppointmentSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class PostgreContext : DbContext
{
    public PostgreContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=hospital_appoinment_system_db; Username=my-postgres;Password=31.10.01Nd; TrustServerCertificate=true");
    }
    
   public DbSet<Doctor> Doctors { get; set; }
   public DbSet<Appointment> Appointments { get; set; }
    
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       modelBuilder.Entity<Doctor>()
           .Property(d => d.Branch)
           .HasConversion<string>()
           .IsRequired();

       base.OnModelCreating(modelBuilder);
   }
}