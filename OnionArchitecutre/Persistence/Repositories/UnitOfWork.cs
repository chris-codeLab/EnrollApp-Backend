using System.Threading;
using System.Threading.Tasks;
using Domain.Repositories;
using Persistence.Seed;

namespace Persistence.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly EnrollAppContext _dbContext;

        public UnitOfWork(EnrollAppContext dbContext) => _dbContext = dbContext;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            _dbContext.SaveChangesAsync(cancellationToken);
    }
}