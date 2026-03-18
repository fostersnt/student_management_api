using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using student_management_api.DTOs.User;
using student_management_api.Models;

namespace student_management_api.Mappers
{
    public static class UserMapper
    {
        public static User From_UserDtoCreate_To_User(this UserDtoCreate userDtoCreate)
        {
            return new User
            {
                Email = userDtoCreate.Email,
                Password = userDtoCreate.Password,
            };
        }

        public static UserDtoGet From_User_To_UserDtoGet(this User user)
        {
            return new UserDtoGet
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
            };
        }

        public static User From_UserDtoUpdate_To_User(this UserDtoUpdate userDtoUpdate)
        {
            return new User
            {
                Email = userDtoUpdate.Email,
                Password = userDtoUpdate.Password
            };
        }
    }
}