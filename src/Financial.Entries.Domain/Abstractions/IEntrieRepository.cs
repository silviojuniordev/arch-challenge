using Financial.Entries.Domain.Entities.Entries;

namespace Financial.Entries.Domain.Abstractions
{
    public interface IEntrieRepository : IRepository<Entrie>
    {
        void Add(Entrie entrie);
        Task<IEnumerable<Entrie>> GetAllAsync();
        Task<Entrie?> GetById(Guid? id);
    }
}
