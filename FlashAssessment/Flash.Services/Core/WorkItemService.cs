
using Flash.DomainModels;
using Flash.Services.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flash.Services.Core
{
    public class WorkItemService : IWorkItemService
    {
        public async Task<WorkItem> AddWorkItemAsync(WorkItem workItem)
        {
            throw new System.NotImplementedException();
        }

        public async Task<WorkItem> GetWorkItemAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItemsAsync(PaginationFilter pagination)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItemsByStatusAsync(int statusId, PaginationFilter pagination)
        {
            throw new System.NotImplementedException();
        }

        public async Task<WorkItem> UpdateWorkItemAsync(WorkItem workItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
