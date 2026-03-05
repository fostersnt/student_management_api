
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_api.DTOs.Student
{
    public class StudentDtoGet
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal PendingFees { get; set; }
        public string CreatedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
    }
}