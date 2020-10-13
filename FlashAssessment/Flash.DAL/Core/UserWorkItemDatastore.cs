

using AutoMapper;
using Flash.DAL.Contract;
using Flash.DAL.Datacontext;
using Flash.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data = Flash.DAL.Datacontext.Models;

namespace Flash.DAL.Core
{
    public class UserWorkItemDatastore : IUserWorkItemDatastore
    {
        private readonly IMapper _mapper;
        private readonly WorkItemTrackerContext _context;
        public UserWorkItemDatastore(WorkItemTrackerContext context,
                                     IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkItem> AddAsync(WorkItem workItem)
        {
            try
            {
                var dto = _mapper.Map<Data.WorkItem>(workItem);

                _context.Entry(dto).State = EntityState.Added;

                await _context.SaveChangesAsync();

                return await GetAsync(workItem.Id);
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }

        public async Task<WorkItem> GetAsync(int id)
        {
            try
            {
                var record = await _context.WorkItem.Include(x => x.Status)
                                                    .Include(x => x.User)
                                                    .AsNoTracking().FirstAsync(x => x.Id == id);

                return _mapper.Map<WorkItem>(record);
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }

        public async Task<IEnumerable<WorkItem>> GetAsync()
        {
            try
            {
                var records = await _context.WorkItem.Include(x => x.Status)
                                                     .Include(x => x.User)
                                                     .AsNoTracking().ToListAsync();

                return _mapper.Map<IEnumerable<WorkItem>>(records);
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }

        public async Task<WorkItem> UpdateAsync(WorkItem workItem)
        {
            try
            {
                var record = await _context.WorkItem.Include(x => x.Status).Include(x => x.User).FirstAsync(x => x.Id == workItem.Id);

                var entity = _mapper.Map(workItem, record, typeof(WorkItem), typeof(Data.WorkItem));

                _context.Entry(entity).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return await GetAsync(workItem.Id);
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }
    }
}
