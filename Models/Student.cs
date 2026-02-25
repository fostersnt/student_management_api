using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_api.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? FastName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PendingFees { get; set; }

        public List<Book>? Books { get; set; }
    }
}