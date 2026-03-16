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
        public string message { get; set; } = "";
        public bool status { get; set; } = false;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BookService> _logger;

        public StudentService(ApplicationDbContext applicationDbContext, ILogger<BookService> logger)
        {
            _context = applicationDbContext;
            _logger = logger;
        }

        public async Task<ApiResponse<StudentDtoGet>> Create(StudentDtoCreate studentDtoCreate)
        {
            try
            {
                _logger.LogInformation("BOOK_CREATION === Incoming Data {@book}", studentDtoCreate);
                var TransformedBookDto = studentDtoCreate.ToStudentFromCreateDto();
                await _context.Students.AddAsync(TransformedBookDto);
                int addedCount = await _context.SaveChangesAsync();

                if (addedCount == 1)
                {
                    message = "Book created successfully";
                }
                else
                {
                    message = "Failed to create new book";
                }

                status = true;
                return new ApiResponse<StudentDtoGet>(status, message, TransformedBookDto.ToStudentDto());
            }
            catch (Exception ex)
            {
                string logMessage = ex.InnerException?.Message ?? ex.Message;
                _logger.LogInformation("BOOK_CREATION_TRY_CATCH === Message [" + logMessage + "]");
                status = false;
                message = "Sorry, failed to create new book";
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

        // public async Task<StudentDtoGet> Create(StudentDtoCreate studentDtoCreate)
        // {
        //     var studentEntity = studentDtoCreate.ToStudentFromCreateDto();
        //     var entityEntry = await _context.Students.AddAsync(studentEntity);

        //     await _context.SaveChangesAsync();

        //     return entityEntry.Entity.ToStudentDto();
        // }

        // public bool Delete(int Id)
        // {
        //     var student = _context.Students.Find(Id);
        //     if (student != null)
        //     {
        //         _context.Students.Remove(student);
        //         return true;
        //     }

        //     return false;
        // }

        // public async Task<StudentDtoGet> Get(int Id)
        // {
        //     var student = await _context.Students.FindAsync(Id);
        //     if (student != null)
        //     {
        //         return student.ToStudentDto();
        //     }

        //     return null;
        // }

        // public async Task<IEnumerable<StudentDtoGet>> Get()
        // {
        //     var students = await _context.Students.ToListAsync();
        //     if (students != null)
        //     {
        //         return students.Select(student => student.ToStudentDto());
        //     }

        //     return null;
        // }

        // public async Task<StudentDtoGet> Update(int Id, StudentDtoUpdate studentDtoUpdate)
        // {
        //     var student = await _context.Students.FindAsync(Id);

        //     if (student != null)
        //     {
        //         student.FirstName = studentDtoUpdate.FirstName;
        //         student.LastName = studentDtoUpdate.LastName;
        //         student.PendingFees = studentDtoUpdate.PendingFees;

        //         await _context.SaveChangesAsync();

        //         return student.ToStudentDto();
        //     }

        //     return null;
        // }
    }
}