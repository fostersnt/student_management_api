using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_management_api.DTOs.User;
using student_management_api.Mappers;
using student_management_api.Models;
using student_management_api.Models.Data;
using student_management_api.Repository.IService;

namespace student_management_api.Repository.Service
{
    public class UserService : IApiService<UserDtoGet, UserDtoCreate, UserDtoUpdate, UserPasswordChangeDto>
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

            var result = await _userManager.CreateAsync(user, userDtoCreate.Password);

            if (!result.Succeeded)
            {
                status = false;
                message = string.Join(", ", result.Errors.Select(e => e.Description));
                return new ApiResponse<UserDtoGet>(
                    status,
                    message,
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
            try
            {
                User? user = _context.Users.Find(Id);

                if (user != null)
                {
                    _context.Remove(user);
                    _context.SaveChanges();
                    status = true;
                    message = "User deleted successfully";
                }
                else
                {
                    status = false;
                    message = "User cannot be found";
                }
            }
            catch (Exception ex)
            {
                status = false;
                message = "Failed to delete user";
                _logger.LogInformation("USER DELETION ==> " + ex.Message);
            }

            return new ApiResponse<UserDtoGet>(status, message, null);
        }

        public async Task<ApiResponse<UserDtoGet>> Get(int Id)
        {
            UserDtoGet? FoundUser = null;

            try
            {
                var user = await _context.Users.FindAsync(Id);

                if (user != null)
                {
                    FoundUser = user.From_User_To_UserDtoGet();
                    status = true;
                    message = "User Found";
                }
                else
                {
                    status = false;
                    message = "User Not Found";
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("USER FETCH (SINGLE) => " + ex.Message);

                status = false;
                message = "An error occurred";
            }

            return new ApiResponse<UserDtoGet>(status, message, FoundUser);
        }

        public async Task<ApiResponse<IEnumerable<UserDtoGet>>> Get()
        {
            IEnumerable<UserDtoGet>? formattedUsers = null;

            try
            {
                var users = await _context.Users.ToListAsync();

                if (users != null && users.Count > 0)
                {
                    formattedUsers = users.Select(user => user.From_User_To_UserDtoGet());
                    status = true;
                    message = "Users found";
                }
                else
                {
                    message = "No User found";
                }
            }
            catch (Exception ex)
            {
                status = false;
                message = ex.Message;
            }

            return new ApiResponse<IEnumerable<UserDtoGet>>(status, message, formattedUsers);
        }

        public async Task<ApiResponse<UserDtoGet>> Update(int Id, UserDtoUpdate userDtoUpdate)
        {
            User? ExistingUser = null;

            try
            {
                ExistingUser = _context.Users.Find(Id);

                if (ExistingUser != null)
                {
                    ExistingUser.FirstName = userDtoUpdate.FirstName;
                    ExistingUser.LastName = userDtoUpdate.LastName;
                    ExistingUser.MiddleName = userDtoUpdate.MiddleName ?? ExistingUser.MiddleName;

                    var result = _context.SaveChanges();

                    status = true;
                    message = "User updated successfully";
                }
                else
                {
                    status = false;
                    message = "User cannot be found";
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("USER UPDATE => " + ex.Message);
                status = false;
                message = "Failed to update user record";
            }

            return new ApiResponse<UserDtoGet>(status, message, ExistingUser?.From_User_To_UserDtoGet());
        }

        [HttpPost("{id:int}")]
        public async Task<ApiResponse<UserDtoGet>> ChangePassword([FromRoute] int id, [FromBody] UserPasswordChangeDto userPasswordChangeDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());

                if (user == null)
                {
                    return new ApiResponse<UserDtoGet>(
                        false,
                        "User not found for password change",
                        null
                    );
                }

                var result = await _userManager.ChangePasswordAsync(
                    user,
                    userPasswordChangeDto.CurrentPassword,
                    userPasswordChangeDto.NewPassword
                );

                if (!result.Succeeded)
                {
                    return new ApiResponse<UserDtoGet>(
                        false,
                        string.Join(", ", result.Errors.Select(e => e.Description)),
                        null
                    );
                }

                return new ApiResponse<UserDtoGet>(
                    true,
                    "Password changed successfully",
                    user.From_User_To_UserDtoGet()
                );
            }
            catch (Exception ex)
            {
                _logger.LogError("USER PASSWORD CHANGE ==> " + ex.Message);

                return new ApiResponse<UserDtoGet>(
                    false,
                    "Unable to change password",
                    null
                );
            }
        }

    }
}