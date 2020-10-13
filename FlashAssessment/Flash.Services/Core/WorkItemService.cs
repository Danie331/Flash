
using Flash.DAL.Contract;
using Flash.DomainModels;
using Flash.Services.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Flash.Services.Core
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IUserWorkItemDatastore _store;
        public WorkItemService(IUserWorkItemDatastore store)
        {
            _store = store;
        }

        public Task<WorkItem> AddWorkItemAsync(WorkItem workItem)
        {
            return _store.AddAsync(workItem);
        }

        public Task<WorkItem> GetWorkItemAsync(int id)
        {
            return _store.GetAsync(id);
        }

        public Task<IEnumerable<WorkItem>> GetWorkItemsAsync(PaginationFilter pagination)
        {
            return _store.GetAllAsync(pagination);
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItemsByStatusAsync(int statusId, PaginationFilter pagination)
        {
            var workItems = await _store.GetAllAsync(pagination);
            return workItems.Where(w => w.Status.Id == statusId); // If using repository pattern, this could be delegated to the database.
        }

        public async Task<WorkItem> UpdateWorkItemAsync(int id, WorkItem workItem)
        {
            if (id != workItem.Id)
            {
                throw new InvalidOperationException($"{nameof(UpdateWorkItemAsync)}");
            }

            return await _store.UpdateAsync(workItem);
        }
    }
}
