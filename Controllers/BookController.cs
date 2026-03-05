using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using student_management_api.DTOs.Book;
using student_management_api.Models;
using student_management_api.Repository.IService;

namespace student_management_api.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IApiService<BookDtoGet, BookDtoCreate, BookDtoUpdate> _apiService;

        public BookController(IApiService<BookDtoGet, BookDtoCreate, BookDtoUpdate> apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _apiService.Get();
            if (books.IsNullOrEmpty())
            {
                return Ok(new ApiResponse<BookDtoGet>(true, "No book found", null));
            }
        }
    }
}