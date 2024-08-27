using Financial.Entries.Domain.DTO;
using Financial.Entries.Domain.Entities.Entries;
using System.Data.Common;

namespace Financial.Entries.Domain.Abstractions
{
    public interface IEntrieRepository : IRepository<Entrie>
    {
        void Add(Entrie entrie);
        Task<IEnumerable<Entrie>> GetAllAsync();
        Task<Entrie?> GetById(Guid? id);
        DbConnection GetDbConnection();
        Task<IEnumerable<EntrieConsolidateDTO>> GetConsolidateAsync(DateTime InitialDate, DateTime FinalDate);
    }
}
