
using Flash.DAL.Contract;
using Flash.DomainModels;
using Flash.Services.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Flash.Services.Exceptions;

namespace Flash.Services.Core
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IUserWorkItemDatastore _store;
        private const int _itemStatusInProgress = 2;
        public WorkItemService(IUserWorkItemDatastore store)
        {
            _store = store;
        }

        public async Task<WorkItem> AddWorkItemAsync(WorkItem workItem)
        {
            if (workItem.User != null)
            {
                if (await CanAssignItemAsync(workItem.UserId.Value, workItem.Status.Id))
                {
                    return await _store.AddAsync(workItem);
                }
                else
                    throw new UserAssignmentException("Unable to assign to user - resource not created");
            }

            return await _store.AddAsync(workItem);
        }

        public Task<WorkItem> GetWorkItemAsync(int id)
        {
            return _store.GetAsync(id);
        }

        public Task<IEnumerable<WorkItem>> GetWorkItemsAsync(PaginationFilter pagination = null)
        {
            return _store.GetAllAsync(pagination);
        }

        public Task<IEnumerable<WorkItem>> GetWorkItemsByStatusAsync(int statusId, PaginationFilter pagination = null)
        {
            return _store.GetByStatusAsync(statusId, pagination);
        }

        public async Task<WorkItem> UpdateWorkItemAsync(int id, WorkItem workItem)
        {
            if (id != workItem.Id)
            {
                throw new InvalidOperationException($"Mismatching resource IDs in {nameof(UpdateWorkItemAsync)}");
            }

            if (workItem.User != null)
            {
                if (await CanAssignItemAsync(workItem.UserId.Value, workItem.Status.Id))
                {
                    return await _store.UpdateAsync(workItem);
                }
                else
                    throw new UserAssignmentException("Unable to assign user to item - resource not modified");
            }

            return await _store.UpdateAsync(workItem);
        }

        private async Task<bool> CanAssignItemAsync(int userId, int statusId)
        {
            if (statusId != _itemStatusInProgress)
            {
                return true;
            }

            var inProgressItems = await GetWorkItemsByStatusAsync(_itemStatusInProgress);
            var userItemsInProgress = inProgressItems.Where(x => x.UserId == userId);

            return userItemsInProgress.Count() < 2;
        }
    }
}
