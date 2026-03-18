using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using student_management_api.DTOs.User;
using student_management_api.Mappers;
using student_management_api.Models;
using student_management_api.Models.Data;
using student_management_api.Repository.IService;

namespace student_management_api.Repository.Service
{
    public class UserService : IApiService<UserDtoGet, UserDtoCreate, UserDtoUpdate>
    {
        public string message { get; set; } = "";
        public bool status { get; set; } = false;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StudentService> _logger;
        private readonly UserManager<User> _userManager;

        public UserService(ApplicationDbContext applicationDbContext, ILogger<StudentService> logger, UserManager<User> userManager)
        {
            _context = applicationDbContext;
            _logger = logger;
            _userManager = userManager;
        }
        public async Task<ApiResponse<UserDtoGet>> Create(UserDtoCreate userDtoCreate)
        {
            var user = userDtoCreate.From_UserDtoCreate_To_User();
            user.UserName = user.Email;

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                return new ApiResponse<UserDtoGet>(
                    status,
                    string.Join(", ", result.Errors.Select(e => e.Description)),
                    null
                );
            }

            // user now contains the created user, including Id
            var userDto = user.From_User_To_UserDtoGet();
            status = true;

            return new ApiResponse<UserDtoGet>(
                status,
                "User created successfully",
                userDto
            );
        }

        public ApiResponse<UserDtoGet> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<UserDtoGet>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<UserDtoGet>>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<UserDtoGet>> Update(int Id, UserDtoUpdate data)
        {
            throw new NotImplementedException();
        }
    }
}