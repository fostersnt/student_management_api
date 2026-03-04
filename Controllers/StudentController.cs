
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAll()
        {
            var data = await _apiService.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = await _apiService.Get(id);
            if (student != null)
            {
                return Ok(student);
            }

            return NotFound("Student not found");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentDtoCreate studentDto)
        {
            // var studentData = studentDto.ToStudentFromCreateDto();
           var result = await _apiService.Create(studentDto);
            // return CreatedAtAction(nameof(GetById), new { id = studentData.Id }, studentData.ToStudentDto());
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StudentDtoUpdate updateStudentRequestDto)
        {
            var student = await _apiService.Update(id, updateStudentRequestDto);

            if (student != null)
            {
                return Ok(student);
            }

            return NotFound();
        }

    }
}