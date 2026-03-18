using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_api.DTOs.User
{
    public class UserPasswordChangeDto
    {
        [Required]
        public string? OldPassword { get; set; }
        [Required]
        public string? NewPassword { get; set; }
    }
}