namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        ISubjectRepository SubjectRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
