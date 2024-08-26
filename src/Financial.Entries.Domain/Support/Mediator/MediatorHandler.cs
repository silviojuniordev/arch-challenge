using Financial.Entries.Domain.Support.Messages;
using FluentValidation.Results;
using MediatR;

namespace Financial.Entries.Domain.Support.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task<ValidationResult> SendCommand<T>(T command, CancellationToken cancellationToken) where T : Command
        {
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
