using System;

namespace Domain.Exceptions
{
    public sealed class SubjectNotFound : NotFoundException
    {
        public SubjectNotFound(Guid id)
            : base($"The account with the identifier {id} was not found.")    
        {
        }
    }
}
