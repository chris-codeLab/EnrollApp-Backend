using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Abstractions;

namespace Domain.Repositories
{
    public interface ISubjectRepository: IGenericRepository<Subject>
    {
        Task<IEnumerable<Subject>> GetAllBySubjectIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Subject> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Insert(Subject subject);

        void Remove(Subject subject);
    }
}
