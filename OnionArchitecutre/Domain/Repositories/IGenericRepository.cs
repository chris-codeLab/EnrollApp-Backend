using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void CreateAsync(T entity);
        void UpdateAsync(T entity);
        void RemoveAsync(T entity);
        bool Save();

    }

}
