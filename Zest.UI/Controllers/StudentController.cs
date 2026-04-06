using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zest.Application.Commons.Constants;
using Zest.Application.DTOs;
using Zest.Application.DTOs.Student;
using Zest.Application.Interfaces;

namespace Zest.UI.Controllers
{

    /// <summary>
    /// handles student related operations .
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        /// <summary>
        /// Add new student in the system .
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequestDto dto)
        {
            StudentResponseDto? result = await _studentService.CreateAsync(dto);

            ApiResponseDto<StudentResponseDto>? response = ApiResponseDto<StudentResponseDto>.Success(
                new List<StudentResponseDto> { result },
               Constants.StudentCreateMessage,
                StatusCodes.Status201Created
            );

            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Gets student by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            StudentResponseDto? result = await _studentService.GetByIdAsync(id);

            if (result is null)
            {
                ApiResponseDto<StudentResponseDto> fail = ApiResponseDto<StudentResponseDto>.Failure(
                    Constants.StudentNotFoundMessage,
                    StatusCodes.Status404NotFound
                );
                return StatusCode(fail.StatusCode, fail);
            }

            ApiResponseDto<StudentResponseDto> response = ApiResponseDto<StudentResponseDto>.Success(
                new List<StudentResponseDto> { result },
               Constants.StudentRetrivedMessage
            );

            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Gets all students in the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<StudentResponseDto> result = await _studentService.GetAllAsync();

            ApiResponseDto<StudentResponseDto> response = ApiResponseDto<StudentResponseDto>.Success(
                result,
                  Constants.StudentRetrivedMessage
            );

            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Update a student in the system by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentRequestDto dto)
        {
            StudentResponseDto? result = await _studentService.PatchAsync(id, dto);

            if (result is null)
            {
                ApiResponseDto<StudentResponseDto> fail = ApiResponseDto<StudentResponseDto>.Failure(
                     Constants.StudentNotFoundMessage,
                    StatusCodes.Status404NotFound
                );
                return StatusCode(fail.StatusCode, fail);
            }

            ApiResponseDto<StudentResponseDto> response = ApiResponseDto<StudentResponseDto>.Success(
                new List<StudentResponseDto> { result },
                  Constants.StudentUpdatedMessage
            );

            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Delete student.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _studentService.DeleteAsync(id);

            if (!success)
            {
                ApiResponseDto<StudentResponseDto> fail = ApiResponseDto<StudentResponseDto>.Failure(
                     Constants.StudentNotFoundMessage,
                    StatusCodes.Status404NotFound
                );
                return StatusCode(fail.StatusCode, fail);
            }

            ApiResponseDto<StudentResponseDto> response = ApiResponseDto<StudentResponseDto>.Success(
                Enumerable.Empty<StudentResponseDto>(),
                Constants.StudentRetrivedMessage,
                StatusCodes.Status200OK
            );

            return StatusCode(response.StatusCode, response);
        }
    }
}