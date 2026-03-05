using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<BookDtoGet> Create(BookDtoCreate bookDtoCreate)
        {
            var book = bookDtoCreate.From_BookDto_To_Book();
            var addedBook = await _context.Books.AddAsync(book);
            int addedCount = await _context.SaveChangesAsync();
            if (addedCount == 1)
            {
                return addedBook.Entity.From_Book_To_BookDtoGet();
            }
            return null;
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDtoGet> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookDtoGet>> Get()
        {
            var books = await _context.Books.ToListAsync();
            if (books.IsNullOrEmpty())
            {
                return null;
            }
            return books.Select(book => book.From_Book_To_BookDtoGet());
        }

        public Task<BookDtoGet> Update(int Id, BookDtoUpdate data)
        {
            throw new NotImplementedException();
        }
    }
}