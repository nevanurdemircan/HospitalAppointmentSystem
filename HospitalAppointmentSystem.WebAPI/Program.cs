using System.Text.Json.Serialization;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Context;
using Exceptions.Filter;
using HospitalAppointmentSystem.Service.Abstracts;
using HospitalAppointmentSystem.Service.Concretes;
using HospitalAppointmentSystem.Service.Profiles;
using HospitalAppointmentSystem.Service.util;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddDbContext<PostgreContext>();

builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDoctorRepository, EfDoctorRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentRepository, EfAppointmentRepository>();
builder.Services.AddScoped<AppointmentValidation>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(option => option.Filters.Add<GlobalExceptionFilter>());
builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();