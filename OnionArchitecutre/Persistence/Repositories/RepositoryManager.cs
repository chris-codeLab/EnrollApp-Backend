using System;
using Domain.Repositories;
using Persistence.Seed;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ISubjectRepository> _lazySubjectRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(EnrollAppContext dbContext)
        {
            _lazySubjectRepository = new Lazy<ISubjectRepository>(() => new SubjectRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public ISubjectRepository SubjectRepository => _lazySubjectRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
