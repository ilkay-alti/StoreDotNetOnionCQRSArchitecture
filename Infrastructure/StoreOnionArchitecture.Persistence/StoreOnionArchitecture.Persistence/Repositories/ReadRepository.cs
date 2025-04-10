﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using StoreOnionArchitecture.Application.Interfaces.Repositories;
using StoreOnionArchitecture.Domain.Common;
using StoreOnionArchitecture.Persistence.Context;

namespace StoreOnionArchitecture.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class ,IEntityBase, new()
    {
        private readonly ApplicationDbContext _dbContext;

        public ReadRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Table => _dbContext.Set<T>();

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking(); //Verilen nesne üzerinde değişiklik yapılmayacaksa AsNoTracking() kullanılır.
            if(include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> GetAllAsyncByPaging(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();// Paging işlemi için Skip ve Take kullanılır.

            return await queryable.Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
         

            return await queryable.FirstOrDefaultAsync(predicate);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null)  Table.Where(predicate);
            return await Table.CountAsync();
        }

        public  IQueryable<T> Find(Expression<Func<T, bool>> predicate,bool enableTracking=false)
        {
           if(!enableTracking ) Table.AsNoTracking();
            return  Table.Where(predicate);
        }


    }
}
