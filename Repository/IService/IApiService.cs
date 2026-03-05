using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_api.Repository.IService
{
    public interface IApiService<TDtoGet, TDtoCreate, TDtoUpdate>
    {
        public Task<TDtoGet> Get(int Id);
        public Task<IEnumerable<TDtoGet>> Get();
        public Task<TDtoGet> Create(TDtoCreate data);
        public Task<TDtoGet> Update(int Id, TDtoUpdate data);
        public bool Delete(int Id);
    }
}