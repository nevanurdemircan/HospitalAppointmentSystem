using HospitalAppointmentSystem.Core.Constants;

namespace HospitalAppointmentSystem.Core.Responses;

public class ApiResponse <T>
{
   public bool Status { get; set; }
   public string Message { get; set; }
   public T Body { get; set; }

   private ApiResponse(bool status, string message)
   {
      Status = status;
      Message = message;
   }

   private ApiResponse(bool status, string message, T body)
   {
      Status = status;
      Message = message;
      Body = body;
   }

   public static ApiResponse<T> Success(T body)
   {
      return new ApiResponse<T>(true, ApiConstant.GlobalSuccessMessage, body);
   }

   public static ApiResponse<T> Failed(string message)
   {
      return new ApiResponse<T>(false, message);
   }
}