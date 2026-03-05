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
            var response = await _apiService.Get();
            return response.Status == true ? Ok(response) : BadRequest(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _apiService.Get(id);
            return response.Status == true ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDtoCreate bookDtoCreate)
        {
            var response = await _apiService.Create(bookDtoCreate);
            return response.Status == true ? Ok(response) : BadRequest(response);
        }
    }
}