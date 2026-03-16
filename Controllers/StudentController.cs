
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_management_api.DTOs.Student;
using student_management_api.Mappers;
using student_management_api.Models;
using student_management_api.Models.Data;
using student_management_api.Repository.IService;

namespace student_management_api.Migrations.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IApiService<StudentDtoGet, StudentDtoCreate, StudentDtoUpdate> _apiService;
        public StudentController(IApiService<StudentDtoGet, StudentDtoCreate, StudentDtoUpdate> context)
        {
            _apiService = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var response = await _apiService.Get();
            return response.Status == true ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = await _apiService.Get(id);
            if (student != null)
            {
                return Ok(new ApiResponse<StudentDtoGet>(true, "Student found", null));
            }

            return NotFound(new ApiResponse<StudentDtoGet>(false, "Student not found", null));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentDtoCreate studentDto)
        {
            var response = await _apiService.Create(studentDto);
            return response.Status == true ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StudentDtoUpdate updateStudentRequestDto)
        {
            var student = await _apiService.Update(id, updateStudentRequestDto);

            if (student != null)
            {
                return Ok(new ApiResponse<StudentDtoGet>(true, "Student updated successfully", null));
            }

            return NotFound(new ApiResponse<StudentDtoGet>(true, "Student not found", null));
        }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete([FromRoute] int id)
        // {
        //     bool deleteResult = _apiService.Delete(id);
        //     if (deleteResult)
        //     {
        //         return Ok(new ApiResponse<StudentDtoGet>(true, "Student deleted successfully", null));
        //     }
        //         return BadRequest(new ApiResponse<StudentDtoGet>(false, "Unable to delete student", null));
        // }

    }
}