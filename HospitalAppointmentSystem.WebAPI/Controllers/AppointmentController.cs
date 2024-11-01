using HospitalAppointmentSystem.Core.Responses;
using HospitalAppointmentSystem.Model.Dtos;
using HospitalAppointmentSystem.Model.Dtos.Responses;
using HospitalAppointmentSystem.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost]
    public ApiResponse<AppointmentResponse> AddAppointment([FromBody] AppointmentCreateRequest appointmentRequest)
    {
        var appointmentResponse = _appointmentService.Add(appointmentRequest);
        return ApiResponse<AppointmentResponse>.Success(appointmentResponse);
    }

    [HttpGet]
    public ApiResponse<List<AppointmentResponse>> GetAll()
    {
        List<AppointmentResponse> appointments = _appointmentService.GetAll();
        return ApiResponse<List<AppointmentResponse>>.Success(appointments);
    }

    [HttpGet("{id}")]
    public ApiResponse<AppointmentResponse> GetById([FromRoute] Guid id)
    {
        AppointmentResponse appointment = _appointmentService.GetById(id);
        return ApiResponse<AppointmentResponse>.Success(appointment);
    }

    [HttpPut]
    public ApiResponse<AppointmentResponse> Update([FromBody] AppointmentUpdateRequest appointmentRequest)
    {
        var updatedAppointment = _appointmentService.Update(appointmentRequest);

        return ApiResponse<AppointmentResponse>.Success(updatedAppointment);
    }

    [HttpDelete("{id}")]
    public ApiResponse<AppointmentResponse> Delete([FromRoute] Guid id)
    {
        var deletedAppointment = _appointmentService.Delete(id);
        return ApiResponse<AppointmentResponse>.Success(deletedAppointment);
    }
}