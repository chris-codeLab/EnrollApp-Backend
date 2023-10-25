using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Seed;
using Services.Abstractions;

namespace Persistence.Repositories
{
    internal sealed class SubjectRepository : GenericRepository<Subject>, ISubjectRepository, IGenericRepository<Subject>
    {
        private readonly EnrollAppContext _dbContext;

        public SubjectRepository(EnrollAppContext dbContext) : base(dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Subject>> GetAllBySubjectIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbContext.Subjects.Where(x => x.SubjectId == id).ToListAsync(cancellationToken);

        public async Task<Subject> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbContext.Subjects.FirstOrDefaultAsync(x => x.SubjectId == id, cancellationToken);

        public void Insert(Subject subject) => _dbContext.Subjects.Add(subject);

        public void Remove(Subject subject) => _dbContext.Subjects.Remove(subject);
    }
}
