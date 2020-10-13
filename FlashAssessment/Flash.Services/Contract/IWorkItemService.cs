
using Flash.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flash.Services.Contract
{
    public interface IWorkItemService
    {
        Task<IEnumerable<WorkItem>> GetWorkItemsAsync(PaginationFilter pagination);
        Task<IEnumerable<WorkItem>> GetWorkItemsByStatusAsync(int statusId, PaginationFilter pagination);
        Task<WorkItem> GetWorkItemAsync(int id);
        Task<WorkItem> UpdateWorkItemAsync(int id, WorkItem workItem);
        Task<WorkItem> AddWorkItemAsync(WorkItem workItem);
    }
}
