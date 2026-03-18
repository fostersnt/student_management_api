using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using student_management_api.DTOs.Book;
using student_management_api.DTOs.Student;
using student_management_api.DTOs.User;
using student_management_api.Repository.IService;

namespace student_management_api.Repository.Service
{
    public static class ServiceRegistration
    {
        public static IServiceCollection MyPersonalApplicationServices(
        this IServiceCollection services)
        {
            services.AddScoped<IApiService<StudentDtoGet, StudentDtoCreate, StudentDtoUpdate>, StudentService>();
            services.AddScoped<IApiService<BookDtoGet, BookDtoCreate, BookDtoUpdate>, BookService>();
            services.AddScoped<IApiService<UserDtoGet, UserDtoCreate, UserDtoUpdate>, UserService>();

            return services;
        }
    }
}