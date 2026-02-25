using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? BookName { get; set; }
        public string? Author { get; set; }
        public int? StudentId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Student? Student { get; set; } //! This is called Navigation property
    }
}