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
        public string message { get; set; } = "";
        public bool status { get; set; } = false;
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<ApiResponse<BookDtoGet>> Create(BookDtoCreate bookDtoCreate)
        {
            try
            {
                var TransformedBookDto = bookDtoCreate.From_BookDtoCreate_To_Book();
                var book = await _context.Books.AddAsync(TransformedBookDto);
                int addedCount = await _context.SaveChangesAsync();

                if (addedCount == 1)
                {
                    message = "Book created successfully";
                }
                else
                {
                    message = "Failed to create new book";
                }

                status = true;
                return new ApiResponse<BookDtoGet>(status, message, book.Entity.From_Book_To_BookDtoGet());
            }
            catch (Exception ex)
            {
                status = false;
                message = ex.Message.ToString();
                return new ApiResponse<BookDtoGet>(status, message, null);
            }
        }

        public ApiResponse<object> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<BookDtoGet>> Get(int Id)
        {
            try
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
                status = true;
                return new ApiResponse<BookDtoGet>(status, message, TransformedBook);
            }
            catch (Exception ex)
            {
                status = false;
                message = ex.Message.ToString();
                return new ApiResponse<BookDtoGet>(status, message, null);
            }
        }

        public async Task<ApiResponse<IEnumerable<BookDtoGet>>> Get()
        {
            try
            {
                var books = await _context.Books.ToListAsync();

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

        public async Task<ApiResponse<BookDtoGet>> Update(int Id, BookDtoUpdate bookDtoUpdate)
        {
            try
            {
                var TransformedBook = bookDtoUpdate.From_BookDtoUpdate_To_Book();
                var book = await _context.Books.AddAsync(TransformedBook);
                int addedCount = await _context.SaveChangesAsync();
                if (addedCount == 1)
                {
                    message = "Book updated successfully";
                }
                else
                {
                    message = "Failed to update book";
                }
                status = true;
                return new ApiResponse<BookDtoGet>(status, message, book.Entity.From_Book_To_BookDtoGet());
            }
            catch (Exception ex)
            {
                status = false;
                message = ex.Message.ToString();
                return new ApiResponse<BookDtoGet>(status, message, null);
            }
        }
    }
}