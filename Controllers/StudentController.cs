
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using student_management_api.DTOs.Student;
using student_management_api.Mappers;
using student_management_api.Models;
using student_management_api.Models.Data;

namespace student_management_api.Migrations.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _context.Students.ToList().Select(s => s.ToStudentDto());
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var student = _context.Students.Find(id)?.ToStudentDto();
            if (student == null)
            {
                return NotFound("Student not found");
            }
            else
            {
                return Ok(student);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentRequest studentDto)
        {
            var studentData  = studentDto.ToStudentFromCreateDto();
            _context.Students.Add(studentData);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = studentData.Id}, studentData.ToStudentDto());
            // return Ok("New student created successfully");
        }
    }
}