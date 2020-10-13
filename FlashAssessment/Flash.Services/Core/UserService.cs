
using Flash.DAL.Contract;
using Flash.DomainModels;
using Flash.Services.Contract;
using System;
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

        public Task<IEnumerable<User>> GetUsersAsync(PaginationFilter pagination = null)
        {
            return _store.GetAllAsync(pagination);
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            if (id != user.Id)
            {
                throw new InvalidOperationException($"{nameof(UpdateUserAsync)}");
            }

            return await _store.UpdateAsync(user);
        }
    }
}
