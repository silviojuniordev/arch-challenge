using Financial.Entries.Domain.Abstractions;
using Financial.Entries.Domain.Commands;
using Financial.Entries.Domain.Entities.Entries;
using Financial.Entries.Domain.Support.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Entries.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IEntrieRepository _entrieRepository;

        public EntriesController(IMediatorHandler mediatorHandler, IEntrieRepository entrieRepository)
        {
            _mediatorHandler = mediatorHandler;
            _entrieRepository = entrieRepository;
        }


        [HttpPost("lancamento")]
        public async Task<IActionResult> CreateEntrie([FromBody] CreateEntrieRequest command)
        {
            var cancelSource = new CancellationTokenSource();
            var result = await _mediatorHandler.SendCommand(new CreateEntrieCommand(Guid.NewGuid(), command.EffectiveDate, command.Description, command.EntrieType, command.Value), cancelSource.Token);

            return Ok(result);
        }

        [HttpGet("lancamento/todos")]
        public async Task<IEnumerable<Entrie>> GetAllAsync()
        {
            return await _entrieRepository.GetAllAsync();
        }

        [HttpGet("lancamento/{id}")]
        public async Task<Entrie> ProdutoDetalhe(Guid id)
        {
            return await _entrieRepository.GetById(id);
        }
    }
}
