using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace student_management_api.Models
{
    public class Role : IdentityRole<int>
    {
        public override int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}