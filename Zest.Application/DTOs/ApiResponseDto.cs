using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zest.Application.DTOs
{
    
    public class ApiResponseDto<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<T>? Data { get; set; }

        public static ApiResponseDto<T> Success(IEnumerable<T> data, string message = "Success", int statusCode = 200)
        {
            return new ApiResponseDto<T>
            {
                StatusCode = statusCode,
                Message = message,
                Data = data
            };
        }

        public static ApiResponseDto<T> Failure(string message, int statusCode = 400)
        {
            return new ApiResponseDto<T>
            {
                StatusCode = statusCode,
                Message = message,
                Data = null
            };
        }
    }
}
