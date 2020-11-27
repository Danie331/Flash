
using AutoMapper;
using Flash.DAL.Contract;
using Flash.DomainModels;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data = Flash.DAL.Datacontext.Models;

namespace Flash.DAL.Core
{
    public class UserDatastore : IUserDatastore
    {
        private readonly IMapper _mapper;
        private readonly ICacheConverter _cache;
        private readonly IDistributedCache _distributedCache;

        public UserDatastore(IMapper mapper,
                             ICacheConverter cache,
                             IDistributedCache distributedCache)
        {
            _mapper = mapper;
            _cache = cache;
            _distributedCache = distributedCache;
        }

        public async Task AddAsync(User user)
        {
            try
            {
                var userDao = _mapper.Map<Data.User>(user);
                var cacheable = _mapper.Map<byte[]>(userDao);
                var key = _cache.GetKeyValue(userDao);
                await _distributedCache.SetAsync(key, cacheable);
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return null;
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
                return null;
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }

        public async Task UpdateAsync(User user)
        {
            try
            {
                return;
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }
    }
}
