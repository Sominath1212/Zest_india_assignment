using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zest.Application.DTOs;
using Zest.Application.DTOs.Student;
using Zest.Application.Interfaces;

namespace Zest.UI.Controllers;

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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentRequestDto dto)
    {
        var result = await _studentService.CreateAsync(dto);

        var response = ApiResponseDto<StudentResponseDto>.Success(
            new List<StudentResponseDto> { result },
            "Student created successfully",
            StatusCodes.Status201Created
        );

        return StatusCode(response.StatusCode, response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _studentService.GetByIdAsync(id);

        if (result is null)
        {
            var fail = ApiResponseDto<StudentResponseDto>.Failure(
                "Student not found",
                StatusCodes.Status404NotFound
            );
            return StatusCode(fail.StatusCode, fail);
        }

        var response = ApiResponseDto<StudentResponseDto>.Success(
            new List<StudentResponseDto> { result },
            "Student fetched successfully"
        );

        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _studentService.GetAllAsync();

        var response = ApiResponseDto<StudentResponseDto>.Success(
            result,
            "Students fetched successfully"
        );

        return StatusCode(response.StatusCode, response);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentRequestDto dto)
    {
        var result = await _studentService.PatchAsync(id, dto);

        if (result is null)
        {
            var fail = ApiResponseDto<StudentResponseDto>.Failure(
                "Student not found",
                StatusCodes.Status404NotFound
            );
            return StatusCode(fail.StatusCode, fail);
        }

        var response = ApiResponseDto<StudentResponseDto>.Success(
            new List<StudentResponseDto> { result },
            "Student updated successfully"
        );

        return StatusCode(response.StatusCode, response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _studentService.DeleteAsync(id);

        if (!success)
        {
            var fail = ApiResponseDto<StudentResponseDto>.Failure(
                "Student not found",
                StatusCodes.Status404NotFound
            );
            return StatusCode(fail.StatusCode, fail);
        }

        var response = ApiResponseDto<StudentResponseDto>.Success(
            Enumerable.Empty<StudentResponseDto>(),
            "Student deleted successfully",
            StatusCodes.Status200OK
        );

        return StatusCode(response.StatusCode, response);
    }
}