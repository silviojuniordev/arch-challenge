using Financial.Entries.Data.Context;
using Financial.Entries.Domain.Abstractions;
using Financial.Entries.Domain.Entities.Entries;
using Microsoft.EntityFrameworkCore;

namespace Financial.Entries.Data.Repository
{
    public class EntrieRepository : IEntrieRepository
    {
        private readonly DefaultDbContext _context;

        public EntrieRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Entrie entrie)
        {
            _context.Entries.Add(entrie);
        }       

        public async Task<IEnumerable<Entrie>> GetAllAsync()
        {
            return await _context.Entries.AsNoTracking().ToListAsync();
        }

        public async Task<Entrie?> GetById(Guid? id)
        {
            return await _context.Entries.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
