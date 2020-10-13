
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
    public class UserDatastore : IUserDatastore
    {
        private readonly IMapper _mapper;
        private readonly WorkItemTrackerContext _context;
        public UserDatastore(WorkItemTrackerContext context,
                             IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> AddAsync(User user)
        {
            try
            {
                var dto = _mapper.Map<Data.User>(user);

                _context.Entry(dto).State = EntityState.Added;

                await _context.SaveChangesAsync();

                return await GetAsync(user.Id);
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAsync(PaginationFilter pagination)
        {
            try
            {
                var records = await _context.User.Include(x => x.Team).AsNoTracking().ToListAsync();

                return _mapper.Map<IEnumerable<User>>(records);
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }

        public async Task<User> GetAsync(int id)
        {
            try
            {
                var record = await _context.User.Include(x => x.Team).AsNoTracking().FirstAsync(x => x.Id == id);

                return _mapper.Map<User>(record);
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }

        public async Task<User> UpdateAsync(User user)
        {
            try
            {
                var userRecord = await _context.User.Include(x => x.Team).FirstAsync(x => x.Id == user.Id);

                var entity = _mapper.Map(user, userRecord, typeof(User), typeof(Data.User));

                _context.Entry(entity).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return await GetAsync(user.Id);
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }
    }
}
