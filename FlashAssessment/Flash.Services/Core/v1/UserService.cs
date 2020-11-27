
using Flash.DAL.Contract;
using Flash.DomainModels;
using Flash.Services.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flash.Services.Core.v1
{
    // rabbit + redis + azure
    class UserService : IUserService
    {
        private readonly IUserDatastore _dal;
        public UserService(IUserDatastore dal)
        {
            _dal = dal;
        }

        public Task AddAsync(User user)
        {
            return _dal.AddAsync(user);
        }

        public Task<IEnumerable<User>> GetAllAsync(PaginationFilter pagination)
        {
            return _dal.GetAllAsync();
        }

        public Task<User> GetAsync(int id)
        {
            return _dal.GetAsync(id);
        }

        public Task UpdateAsync(User user)
        {
            return _dal.UpdateAsync(user);
        }
    }
}
