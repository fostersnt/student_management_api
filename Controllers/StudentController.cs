
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
        private readonly IApiService<StudentDtoGet, StudentDtoCreate, StudentDtoUpdate> _context;
        public StudentController(IApiService<StudentDtoGet, StudentDtoCreate, StudentDtoUpdate> context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // var students = _context.Students.ToList().Select(s => s.ToStudentDto());
            // return Ok(students);
            var data = await _context.Get();
            return Ok(data);
        }

        // [HttpGet("{id}")]
        // public IActionResult GetById([FromRoute] int id)
        // {
        //     var student = _context.Students.Find(id)?.ToStudentDto();
        //     if (student == null)
        //     {
        //         return NotFound("Student not found");
        //     }
        //     else
        //     {
        //         return Ok(student);
        //     }
        // }

        // [HttpPost]
        // public IActionResult Create([FromBody] StudentDtoCreate studentDto)
        // {
        //     var studentData = studentDto.ToStudentFromCreateDto();
        //     _context.Students.Add(studentData);
        //     _context.SaveChanges();
        //     return CreatedAtAction(nameof(GetById), new { id = studentData.Id }, studentData.ToStudentDto());
        //     // return Ok("New student created successfully");
        // }

        // [HttpPut("{id}")]
        // public IActionResult Update([FromRoute] int id, [FromBody] StudentDtoUpdate updateStudentRequestDto)
        // {
        //     var student = _context.Students.FirstOrDefault(s => s.Id == id);
        //     if (student == null)
        //     {
        //         return NotFound();
        //     }

        //     student.FirstName = updateStudentRequestDto.FirstName;
        //     student.LastName = updateStudentRequestDto.LastName;
        //     student.PendingFees = updateStudentRequestDto.PendingFees;

        //     _context.SaveChanges();

        //     return Ok(student.ToStudentDto());
        // }

    }
}