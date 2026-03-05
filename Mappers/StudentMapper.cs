
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using student_management_api.DTOs.Student;
using student_management_api.Models;

namespace student_management_api.Mappers
{
    public static class StudentMapper
    {
        public static StudentDtoGet ToStudentDto(this Student studentModel)
        {
            return new StudentDtoGet
            {
                Id = studentModel.Id,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                PendingFees = studentModel.PendingFees,
                CreatedAt = studentModel.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")
            };
        }

        public static Student ToStudentFromCreateDto(this StudentDtoCreate studentDto)
        {
            return new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                PendingFees = studentDto.PendingFees
            };
        }

        public static Student ToStudentFromUpdateDto(this StudentDtoUpdate studentDto)
        {
            return new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                PendingFees = studentDto.PendingFees
            };
        }
    }
}