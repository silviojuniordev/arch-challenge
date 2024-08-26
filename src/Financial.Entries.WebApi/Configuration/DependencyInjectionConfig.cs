using Financial.Entries.Data.Context;
using Financial.Entries.Data.Repository;
using Financial.Entries.Domain.Abstractions;
using Financial.Entries.Domain.Commands;
using Financial.Entries.Domain.Events;
using Financial.Entries.Domain.Queues.Configuration;
using Financial.Entries.Domain.Support.Mediator;
using FluentValidation.Results;
using MediatR;

namespace Financial.Entries.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<CreateEntrieCommand, ValidationResult>, EntrieCommandHandler>();

            services.AddScoped<INotificationHandler<EntrieRegisteredEvent>, EntrieEventHandler>();
            
            services.AddScoped<DefaultDbContext>();
            services.AddSingleton<IMessageSender, MessageSender>();
            services.AddSingleton<IMessageBus>(new MessageBus(configuration.GetSection("MessageQueueConnection:MessageBus").Value.ToString()));
            services.AddScoped<IEntrieRepository, EntrieRepository>();
        }
    }
}
