using Financial.Entries.Domain.Abstractions;
using Financial.Entries.Domain.Commands;
using Financial.Entries.Domain.Entities.Entries;
using Financial.Entries.Domain.Queries;
using Financial.Entries.Domain.Support.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Entries.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IEntrieRepository _entrieRepository;
        private readonly IEntrieQueries _entrieQueries;

        public EntriesController(IMediatorHandler mediatorHandler,
                                IEntrieRepository entrieRepository, 
                                IEntrieQueries entrieQueries)
        {
            _mediatorHandler = mediatorHandler;
            _entrieRepository = entrieRepository;
            _entrieQueries = entrieQueries;
        }


        [HttpPost("lancamento")]
        public async Task<IActionResult> CreateEntrie([FromBody] CreateEntrieRequest command)
        {
            var cancelSource = new CancellationTokenSource();
            var result = await _mediatorHandler.SendCommand(new CreateEntrieCommand(Guid.NewGuid(), command.EffectiveDate, command.Description, command.EntrieType, command.Value), cancelSource.Token);

            return Ok(result);
        }

        [HttpGet("lancamento/todos")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _entrieRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("lancamento/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            var result = await _entrieRepository.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("lancamento/consolidado")]
        public async Task<IActionResult> GetConsolidateAsync(DateTime InitialDate, DateTime FinalDate)
        {
            var result = await _entrieQueries.GetConsolidateAsync(InitialDate, FinalDate);
            return Ok(result);
        }
    }
}
