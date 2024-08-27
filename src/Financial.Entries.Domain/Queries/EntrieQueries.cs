using Financial.Entries.Domain.Abstractions;
using Financial.Entries.Domain.DTO;
using Financial.Entries.Domain.Enums;

namespace Financial.Entries.Domain.Queries
{
    public class EntrieQueries : IEntrieQueries
    {
        public readonly IEntrieRepository _entrieRepository;

        public EntrieQueries(IEntrieRepository entrieRepository)
        {
            _entrieRepository = entrieRepository;
        }

        public async Task<IEnumerable<EntrieConsolidateDTO>> GetConsolidateAsync(DateTime InitialDate, DateTime FinalDate)
        {
            return await _entrieRepository.GetConsolidateAsync(InitialDate, FinalDate);
        }
    }
}
