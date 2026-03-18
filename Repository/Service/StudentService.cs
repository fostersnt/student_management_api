using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using student_management_api.DTOs.Student;
using student_management_api.DTOs.User;
using student_management_api.Mappers;
using student_management_api.Models;
using student_management_api.Models.Data;
using student_management_api.Repository.IService;

namespace student_management_api.Repository.Service
{
    public class StudentService : IApiService<StudentDtoGet, StudentDtoCreate, StudentDtoUpdate, UserPasswordChangeDto>
    {
        public string message { get; set; } = "";
        public bool status { get; set; } = false;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StudentService> _logger;

        public StudentService(ApplicationDbContext applicationDbContext, ILogger<StudentService> logger)
        {
            _context = applicationDbContext;
            _logger = logger;
        }

        public async Task<ApiResponse<StudentDtoGet>> Create(StudentDtoCreate studentDtoCreate)
        {
            try
            {
                _logger.LogInformation("STUDENT_CREATION === Incoming Data {@student}", studentDtoCreate);
                var TransformedStudentDto = studentDtoCreate.ToStudentFromCreateDto();
                await _context.Students.AddAsync(TransformedStudentDto);
                int addedCount = await _context.SaveChangesAsync();

                if (addedCount == 1)
                {
                    message = "Student created successfully";
                }
                else
                {
                    message = "Failed to create new student";
                }

                status = true;
                return new ApiResponse<StudentDtoGet>(status, message, TransformedStudentDto.ToStudentDto());
            }
            catch (Exception ex)
            {
                string logMessage = ex.InnerException?.Message ?? ex.Message;
                _logger.LogInformation("STUDENT_CREATION_TRY_CATCH === Message [" + logMessage + "]");
                status = false;
                message = "Sorry, failed to create new student";
                _logger.LogInformation("");
                return new ApiResponse<StudentDtoGet>(status, message, null);
            }
        }

        public ApiResponse<StudentDtoGet> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<StudentDtoGet>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<StudentDtoGet>>> Get()
        {
            var students = await _context.Students.ToListAsync();
            IEnumerable<StudentDtoGet> formattedStudents = null;
            if (students != null)
            {
                formattedStudents = students.Select(student => student.ToStudentDto());
                message = "Students found";
                status = true;
            }
            else
            {
                message = "No Student Found";
            }

            return new ApiResponse<IEnumerable<StudentDtoGet>>(status, message, formattedStudents);
        }

        public Task<ApiResponse<StudentDtoGet>> Update(int Id, StudentDtoUpdate data)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<StudentDtoGet>> ChangePassword(int Id, UserPasswordChangeDto extraClass)
        {
            throw new NotImplementedException();
        }

    }
}