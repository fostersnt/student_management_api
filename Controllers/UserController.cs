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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _userService.Get();
            return response.Status == true ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _userService.Get(id);
            return response.Status == true ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDtoCreate userDtoCreate)
        {
            var response = await _userService.Create(userDtoCreate);
            return response.Status == true ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserDtoUpdate userDtoUpdate)
        {
            var response = await _userService.Update(id, userDtoUpdate);
            return response.Status == true ? Ok(response) : BadRequest(response);
        }
    }
}