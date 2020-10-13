
using Flash.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flash.DAL.Contract
{
    public interface IUserDatastore
    {
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetAsync();
        Task<User> UpdateAsync(User user);
        Task<User> AddAsync(User user);
    }
}
