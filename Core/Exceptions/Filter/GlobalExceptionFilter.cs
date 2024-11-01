using HospitalAppointmentSystem.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Exceptions.Filter;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BaseBusinessException)
        {
          var response = ApiResponse<string>.Failed(context.Exception.Message);
          var result = new ObjectResult(response);
          context.Result = result;
          context.ExceptionHandled = true;
        }
    }
}