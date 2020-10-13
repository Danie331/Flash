
using Flash.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flash.DAL.Contract
{
    public interface IUserWorkItemDatastore
    {
        Task<WorkItem> GetAsync(int id);
        Task<IEnumerable<WorkItem>> GetAsync();
        Task<WorkItem> UpdateAsync(WorkItem workItem);
        Task<WorkItem> AddAsync(WorkItem workItem);
    }
}
