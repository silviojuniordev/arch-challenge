using Dapper;
using Financial.Entries.Data.Context;
using Financial.Entries.Domain.Abstractions;
using Financial.Entries.Domain.DTO;
using Financial.Entries.Domain.Entities.Entries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace Financial.Entries.Data.Repository
{
    public class EntrieRepository : IEntrieRepository
    {
        private readonly DefaultDbContext _context;
        private readonly ILogger<EntrieRepository> _logger;

        public EntrieRepository(DefaultDbContext context, ILogger<EntrieRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IUnitOfWork UnitOfWork => _context;

        public DbConnection GetDbConnection() => _context.Database.GetDbConnection();

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

        public async Task<IEnumerable<EntrieConsolidateDTO>> GetConsolidateAsync(DateTime initialDate, DateTime finalDate)
        {
            try
            {
                _logger.LogInformation("Obtendo Informações Consolidadas");

                string sql = @"SELECT FORMAT(EffectiveDate, 'yyyy-MM-dd') AS EffectiveDate,
                                   IIF(EntrieType = 1, 'Crédito', 'Débito') AS EntrieType,
                                   SUM(Value) AS Value
                            FROM [ArchChallenge].[dbo].[Entries] 
                            WHERE EffectiveDate >= @InitialDate AND EffectiveDate < @FinalDate
                            GROUP BY FORMAT(EffectiveDate, 'yyyy-MM-dd'), EntrieType
                            ORDER BY FORMAT(EffectiveDate, 'yyyy-MM-dd')";

                using (var connection = GetDbConnection())
                {
                    var result = await connection.QueryAsync<EntrieConsolidateDTO>(sql, new { InitialDate = initialDate, FinalDate = finalDate.AddDays(1) });
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter o Consolidado - {ex.Message}");
                throw;
            }
        }
    }
}
