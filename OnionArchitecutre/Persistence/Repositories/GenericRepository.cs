using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistence.Seed;

namespace Persistence.Repositories
{
     public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EnrollAppContext _dbContext;
        
        public GenericRepository(EnrollAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => _dbContext.SaveChangesAsync(cancellationToken);
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) => await _dbContext.Set<T>().ToListAsync(cancellationToken);
        public void CreateAsync(T entity) => _dbContext.Set<T>().AddAsync(entity) ;                  
        public void UpdateAsync(T entity) => _dbContext.Set<T>().Update(entity);
        public void RemoveAsync(T entity) =>_dbContext.Remove(entity);
        public bool Save() => _dbContext.SaveChanges() >= 0;          
    }
}
