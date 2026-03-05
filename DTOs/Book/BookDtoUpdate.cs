using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_api.DTOs.Book
{
    public class BookDtoUpdate
    {
        public string? BookName { get; set; }
        public string? Author { get; set; }
        public int? StudentId { get; set; }
    }
}