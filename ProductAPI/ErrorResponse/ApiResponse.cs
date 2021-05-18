using System;

namespace ProductAPI.ErrorResponse
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, You have made!",
                401 => "Authorised! you are not.",
                404 => "Resource Found! It was not.",
                500 => "A fatal serverError Occurred.",
                _ => null
            };
        }
    }
}
