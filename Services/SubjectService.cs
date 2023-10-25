using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Mapping;
using AutoMapper;
using Services.Abstractions;

namespace Services
{
    internal sealed class SubjectService : ISubjectServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public  IMapper mapping()
        {
            return MapperConfig.InitializeAutoMapper();
        }
        
        public SubjectService(IRepositoryManager repositoryManager, IMapper mapper)  
        {
         _repositoryManager = repositoryManager;
         _mapper = mapping();
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjects(CancellationToken cancellationToken = default)
        {
            var subject = await _repositoryManager.SubjectRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<SubjectDto>>(subject) ;
        }

        public async Task<IEnumerable<SubjectDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var subject = await _repositoryManager.SubjectRepository.GetByIdAsync(id, cancellationToken);

            if (subject is null)
            {
                throw new SubjectNotFound(id);
            }


            return _mapper.Map<IEnumerable<SubjectDto>>(subject);
        }

        public async Task<SubjectDto> CreateAsync(SubjectForCreationDto subjectForCreationDto, Guid id, CancellationToken cancellationToken = default)
        {
            var subject = _repositoryManager.SubjectRepository.GetByIdAsync(id, cancellationToken);

            if(subject is null)
            {
                throw new SubjectNotFound(id);
            }

            var newSubject = _mapper.Map<Subject>(subjectForCreationDto);

             _repositoryManager.SubjectRepository.Insert(newSubject);

             await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SubjectDto>(subject);
        }

        public async Task UpdateAsync(Guid id, SubjectForUpdateDto ownerForUpdateDto, CancellationToken cancellationToken = default)
        {
            var subject = await _repositoryManager.SubjectRepository.GetByIdAsync(id, cancellationToken);

            if (subject is null)
            {
                throw new SubjectNotFound(id);
            }

             _repositoryManager.SubjectRepository.UpdateAsync(subject);
            
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var subject = await _repositoryManager.SubjectRepository.GetByIdAsync(id, cancellationToken);

            if (subject is null)
            {
                throw new SubjectNotFound(id);
            }

            _repositoryManager.SubjectRepository.RemoveAsync(subject);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}