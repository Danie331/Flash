
using Flash.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flash.Services.Contract
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync(PaginationFilter pagination);
        Task AddAsync(User user);
        Task<User> GetAsync(int id);
        Task UpdateAsync(User user);
    }
}
