namespace Financial.Entries.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
