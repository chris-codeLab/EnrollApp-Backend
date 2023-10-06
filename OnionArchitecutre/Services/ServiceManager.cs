using System;
using AutoMapper;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ISubjectServices> _lazySubjectService;



        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazySubjectService = new Lazy<ISubjectServices>(() => new SubjectService(repositoryManager, mapper));
        }

        public ISubjectServices SubjectService => _lazySubjectService.Value;

    }
}
