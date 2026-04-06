

namespace Zest.Application.DTOs
{
    /// <summary>
    /// Represents a standard API response containing a status code, message, and a collection of data items.
    /// </summary>
    /// <remarks>This class provides a consistent structure for API responses, supporting both success and
    /// failure scenarios. Use the static methods to create standardized responses for API endpoints.</remarks>
    /// <typeparam name="T">The type of the data items included in the response.</typeparam>
    public class ApiResponseDto<T>
    {
        /// <summary>
        /// Gets or sets the HTTP status code associated with the response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the message content.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of data items of type T.
        /// </summary>
        public IEnumerable<T>? Data { get; set; }

        /// <summary>
        /// Creates a successful API response containing the specified data, message, and status code.
        /// </summary>
        /// <param name="data">The collection of data items to include in the response. This value is assigned to the Data property of the
        /// returned object.</param>
        /// <param name="message">An optional message describing the result of the operation. The default is "Success".</param>
        /// <param name="statusCode">The HTTP status code to associate with the response. The default is 200.</param>
        /// <returns>An ApiResponseDto<T> representing a successful response with the provided data, message, and status code.</returns>
        public static ApiResponseDto<T> Success(IEnumerable<T> data, string message = "Success", int statusCode = 200)
        {
            return new ApiResponseDto<T>
            {
                StatusCode = statusCode,
                Message = message,
                Data = data
            };
        }
        /// <summary>
        /// Creates a failed API response with the specified error message and status code.
        /// </summary>
        /// <param name="message">The error message to include in the response. Cannot be null.</param>
        /// <param name="statusCode">The HTTP status code to associate with the failure. The default is 400.</param>
        /// <returns>An instance of ApiResponseDto<T> representing a failed response with the specified message and status code.
        /// The Data property will be null.</returns>
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