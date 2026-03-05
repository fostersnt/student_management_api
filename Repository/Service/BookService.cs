using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using student_management_api.DTOs.Book;
using student_management_api.Mappers;
using student_management_api.Models;
using student_management_api.Models.Data;
using student_management_api.Repository.IService;

namespace student_management_api.Repository.Service
{
    public class BookService : IApiService<BookDtoGet, BookDtoCreate, BookDtoUpdate>
    {
        public string message { get; set; }
        public bool status { get; set; }
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Task<ApiResponse<BookDtoGet>> Create(BookDtoCreate data)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<object> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<BookDtoGet>> Get(int Id)
        {
            var book = await _context.Books.FindAsync(Id);
            var TransformedBook = book.From_Book_To_BookDtoGet();

            if (book == null)
            {
                message = "Not found";
            }
            else
            {
                message = "Book found";
            }
            return new ApiResponse<BookDtoGet>(true, message, TransformedBook);
        }

        public async Task<ApiResponse<IEnumerable<BookDtoGet>>> Get()
        {
            try
            {
                var books = await _context.Books.ToListAsync();
                var dtc = new List<int>{2, 4, 6};

                int a = dtc[10];

                var TransformedBooks = books?.Select(book => book.From_Book_To_BookDtoGet());

                if (books.IsNullOrEmpty())
                {
                    message = "No books found";
                }
                else
                {
                    message = "Books available";
                }

                status = true;

                return new ApiResponse<IEnumerable<BookDtoGet>>(true, message, TransformedBooks);
            }
            catch (Exception ex)
            {
                status = false;
                message = ex.Message.ToString();
                return new ApiResponse<IEnumerable<BookDtoGet>>(status, message, null);
            }
        }

        public Task<ApiResponse<BookDtoGet>> Update(int Id, BookDtoUpdate data)
        {
            throw new NotImplementedException();
        }
    }
}