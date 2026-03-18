using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using student_management_api.DTOs.User;
using student_management_api.Repository.IService;
using student_management_api.Repository.Service;

namespace student_management_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IApiService<UserDtoGet, UserDtoCreate, UserDtoUpdate> _userService;

        public UserController(IApiService<UserDtoGet, UserDtoCreate, UserDtoUpdate> userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDtoCreate userDtoCreate)
        {
            var response = await _userService.Create(userDtoCreate);
            return response.Status == true ? Ok(response) : BadRequest(response);
        }
    }
}