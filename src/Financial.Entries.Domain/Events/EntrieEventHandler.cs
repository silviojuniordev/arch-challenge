using EasyNetQ;
using Financial.Entries.Domain.Abstractions;
using Financial.Entries.Domain.Support.Messages.Integration;
using Financial.Entries.Domain.Support.Queue;
using MediatR;

namespace Financial.Entries.Domain.Events
{
    public class EntrieEventHandler : INotificationHandler<EntrieRegisteredEvent>
    {
        private readonly IMessageBus _bus;

        public EntrieEventHandler(IMessageBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(EntrieRegisteredEvent notification, CancellationToken cancellationToken)
        {

            var message = new EntrieRegisteredIntegrationEvent(notification.Id, notification.EffectiveDate, notification.Description, notification.EntrieType, notification.Value);
            await _bus.RequestAsync<EntrieRegisteredIntegrationEvent, ResponseMessage>(message);
        }
    }
}