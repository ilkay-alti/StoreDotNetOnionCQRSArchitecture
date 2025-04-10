﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreOnionArchitecture.Application.Interfaces.Repositories;
using StoreOnionArchitecture.Application.Interfaces.UnitOfWorks;
using StoreOnionArchitecture.Persistence.Context;
using StoreOnionArchitecture.Persistence.Repositories;

namespace StoreOnionArchitecture.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {

            this.dbContext = dbContext;
        }


        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();

        public int Save()=> dbContext.SaveChanges();

        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()=> new ReadRepository<T>(dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
            }
}
