using HospitalAppointmentSystem.Core.Responses;
using HospitalAppointmentSystem.Model.Dtos;
using HospitalAppointmentSystem.Model.Dtos.Responses;
using HospitalAppointmentSystem.Model.Entities;
using HospitalAppointmentSystem.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("getallpatients")]
    public ApiResponse<List<DoctorResponse>> GetAllPatients()
    {
        List<DoctorResponse> doctors = _doctorService.GetAllPatients();
        return ApiResponse<List<DoctorResponse>>.Success(doctors);
    }

    [HttpGet()]
    public ApiResponse<List<DoctorResponse>> GetAll()
    {
        List<DoctorResponse> doctorResponses = _doctorService.GetAll();
        return ApiResponse<List<DoctorResponse>>.Success(doctorResponses);
    }

    [HttpPost()]
    public ApiResponse<DoctorResponse> Add([FromBody] CreateDoctorRequest doctorRequest)
    {
        DoctorResponse added = _doctorService.Add(doctorRequest);
        return ApiResponse<DoctorResponse>.Success(added);
    }

    [HttpGet("{id}")]
    public ApiResponse<DoctorResponse> GetById([FromRoute] int id)
    {
        DoctorResponse doctor = _doctorService.GetById(id);
        return ApiResponse<DoctorResponse>.Success(doctor);
    }

    [HttpPut]
    public ApiResponse<DoctorResponse> Update(UpdateDoctorRequest doctorRequest)
    {
        DoctorResponse updated = _doctorService.Update(doctorRequest);
        return ApiResponse<DoctorResponse>.Success(updated);
    }

    [HttpDelete("{id}")]
    public ApiResponse<DoctorResponse> Delete([FromRoute] int id)
    {
        var deletedDoctor = _doctorService.Delete(id);
        return ApiResponse<DoctorResponse>.Success(deletedDoctor);
    }
}