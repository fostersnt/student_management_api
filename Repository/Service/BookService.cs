using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using student_management_api.DTOs.Book;
using student_management_api.Models;
using student_management_api.Repository.IService;

namespace student_management_api.Repository.Service
{
    public class BookService : IApiService<BookDtoGet, BookDtoCreate, BookDtoUpdate>
    {
        public Task<BookDtoGet> Create(BookDtoCreate data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDtoGet> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDtoGet>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<BookDtoGet> Update(int Id, BookDtoUpdate data)
        {
            throw new NotImplementedException();
        }
    }
}