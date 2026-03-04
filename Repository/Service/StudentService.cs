using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using student_management_api.DTOs.Student;
using student_management_api.Mappers;
using student_management_api.Models;
using student_management_api.Models.Data;
using student_management_api.Repository.IService;

namespace student_management_api.Repository.Service
{
    public class StudentService : IApiService<StudentDtoGet, StudentDtoCreate, StudentDtoUpdate>
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<StudentDtoCreate> Create(StudentDtoCreate data)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentDtoGet> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentDtoGet>> Get()
        {
            var students = await _context.Students.ToListAsync();
            if (students != null)
            {
                return students.Select(student => student.ToStudentDto());
            }

            return [];
        }

        public async Task<StudentDtoUpdate> Update(int Id, StudentDtoUpdate data)
        {
            throw new NotImplementedException();
        }
    }
}