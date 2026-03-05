using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using student_management_api.Models;

namespace student_management_api.Repository.IService
{
    public interface IApiService<TDtoGet, TDtoCreate, TDtoUpdate>
    {
        public Task<ApiResponse<TDtoGet>> Get(int Id);
        public Task<ApiResponse<IEnumerable<TDtoGet>>> Get();
        public Task<ApiResponse<TDtoGet>> Create(TDtoCreate data);
        public Task<ApiResponse<TDtoGet>> Update(int Id, TDtoUpdate data);
        public ApiResponse<TDtoGet> Delete(int Id);
    }
}