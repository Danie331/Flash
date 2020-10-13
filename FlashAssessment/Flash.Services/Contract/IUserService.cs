
using Flash.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flash.Services.Contract
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync(PaginationFilter pagination);
        Task<User> GetUserAsync(int id);
        Task<User> UpdateUserAsync(User user);
        Task<User> AddUserAsync(User user);
    }
}
