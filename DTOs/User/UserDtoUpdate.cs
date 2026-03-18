using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using student_management_api.Models;

namespace student_management_api.DTOs.User

{
    public class UserDtoUpdate
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; } = string.Empty;
    }
}