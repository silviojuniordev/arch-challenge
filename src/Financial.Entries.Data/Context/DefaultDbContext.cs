using Financial.Entries.Domain.Abstractions;
using Financial.Entries.Domain.Entities;
using Financial.Entries.Domain.Entities.Entries;
using Financial.Entries.Domain.Support.Mediator;
using Financial.Entries.Domain.Support.Messages;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Financial.Entries.Data.Context
{
    public class DefaultDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;
        
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, IMediatorHandler mediatorHandler) 
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Entrie> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DefaultDbContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            if (sucesso) await _mediatorHandler.PublishEvent(this);

            return sucesso;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishEvent<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.CleanEvent());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
