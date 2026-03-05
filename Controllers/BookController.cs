using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace student_management_api.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}