using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts;

namespace Services.Abstractions
{
   

    public interface ISubjectServices
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjects(CancellationToken cancellationToken = default);

        Task<IEnumerable<SubjectDto>> GetByIdAsync(Guid id , CancellationToken cancellationToken = default);

        Task<SubjectDto> CreateAsync(SubjectForCreationDto subjectCreateDto, Guid id, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid id, SubjectForUpdateDto subjectUpdateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
    }
