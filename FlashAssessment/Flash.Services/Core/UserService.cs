
using Flash.DAL.Contract;
using Flash.DomainModels;
using Flash.Services.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flash.Services.Core
{
    public class UserService : IUserService
    {
        private readonly IUserDatastore _store;
        public UserService(IUserDatastore store)
        {
            _store = store;
        }

        public Task<User> AddUserAsync(User user)
        {
            return _store.AddAsync(user);
        }

        public Task<User> GetUserAsync(int id)
        {
            return _store.GetAsync(id);
        }

        public Task<IEnumerable<User>> GetUsersAsync(PaginationFilter pagination)
        {
            return _store.GetAsync(pagination);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
