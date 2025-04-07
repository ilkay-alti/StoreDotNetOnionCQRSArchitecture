using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreOnionArchitecture.Application.Interfaces.Repositories;
using StoreOnionArchitecture.Domain.Common;
using StoreOnionArchitecture.Persistence.Context;

namespace StoreOnionArchitecture.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()

    {

        private readonly ApplicationDbContext _dbContext;

        public WriteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Table => _dbContext.Set<T>();



        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
        await Table.AddRangeAsync(entities);
        }
        public async Task<T> UpdateAsync(T entity)
        {
           await Task.Run(() => Table.Update(entity));
            return entity;
        }
        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

      

  
    }
}
