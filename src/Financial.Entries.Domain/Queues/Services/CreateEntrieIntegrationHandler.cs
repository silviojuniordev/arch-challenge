using Financial.Entries.Domain.Abstractions;
using Financial.Entries.Domain.Support.Messages.Integration;
using Financial.Entries.Domain.Support.Queue;
using FluentValidation.Results;
using Microsoft.Extensions.Hosting;

namespace Financial.Entries.Domain.Queues.Services
{
    public class CreateEntrieIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public CreateEntrieIntegrationHandler(
                            IMessageBus bus,
                            IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponse();
            return Task.CompletedTask;
        }

        private void SetResponse()
        {
            _bus.RespondAsync<EntrieRegisteredIntegrationEvent, ResponseMessage>(async request =>
                await RegistrarCliente(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        private void OnConnect(object s, EventArgs e)
        {
            SetResponse();
        }

        private async Task<ResponseMessage> RegistrarCliente(EntrieRegisteredIntegrationEvent message)
        {
            //var clienteCommand = new RegistrarClienteCommand(message.Id, message.Nome, message.Email, message.Cpf);
            //ValidationResult sucesso;

            //using (var scope = _serviceProvider.CreateScope())
            //{
            //    var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
            //    sucesso = await mediator.EnviarComando(clienteCommand);
            //}

            return new ResponseMessage(new ValidationResult());
        }
    }
}