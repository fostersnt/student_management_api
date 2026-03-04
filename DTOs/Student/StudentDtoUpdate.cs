using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_api.DTOs.Student
{
    public class StudentDtoUpdate
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "PendingFees is required")]
        [Range(1, 200, ErrorMessage = "Enter correct value")]
        public decimal PendingFees { get; set; }
    }
}