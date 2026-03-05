using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using student_management_api.DTOs.Book;
using student_management_api.Models;

namespace student_management_api.Mappers
{
    public static class BookMapper
    {
        public static BookDtoGet From_Book_To_BookDtoGet(this Book book)
        {
            return new BookDtoGet
            {
                BookName = book.BookName,
                Author = book.Author,
                StudentId = book.StudentId
            };
        }
        public static Book From_BookDtoCreate_To_Book (this BookDtoCreate bookDtoCreate)
        {
            return new Book
            {
                BookName = bookDtoCreate.BookName,
                Author = bookDtoCreate.Author,
                StudentId = bookDtoCreate.StudentId
            };
        }

        public static Book From_BookDtoUpdate_To_Book(this BookDtoUpdate bookDtoUpdate)
        {
            
        }
    }
}