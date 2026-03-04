using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_api.DTOs.Student
{
    public class StudentDtoCreate
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal PendingFees { get; set; }
    }
}