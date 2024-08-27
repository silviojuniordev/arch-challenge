using Financial.Entries.Domain.DTO;

namespace Financial.Entries.Domain.Queries
{
    public interface IEntrieQueries
    {
        Task<IEnumerable<EntrieConsolidateDTO>> GetConsolidateAsync(DateTime InitialDate, DateTime FinalDate);
    }
}
