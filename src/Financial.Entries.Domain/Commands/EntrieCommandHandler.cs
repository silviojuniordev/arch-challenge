using Financial.Entries.Domain.Abstractions;
using Financial.Entries.Domain.Entities.Entries;
using Financial.Entries.Domain.Events;
using Financial.Entries.Domain.Queues.Configuration;
using Financial.Entries.Domain.Queues.Models;
using Financial.Entries.Domain.Support.Messages;
using Financial.Entries.Domain.Support.Messages.Integration;
using Financial.Entries.Domain.Support.Queue;
using FluentValidation.Results;
using MediatR;

namespace Financial.Entries.Domain.Commands
{
    public class EntrieCommandHandler : CommandHandler,
        IRequestHandler<CreateEntrieCommand, ValidationResult>
    {
        private readonly IEntrieRepository _entrieRepository;
        private readonly IMessageSender _message;

        public EntrieCommandHandler(IEntrieRepository entrieRepository, IMessageSender message)
        {
            _entrieRepository = entrieRepository;
            _message = message;
        }

        public async Task<ValidationResult> Handle(CreateEntrieCommand message, CancellationToken cancellationToken)
        {
            try
            {
                if (!message.IsValid()) return message.ValidationResult!;

                var entrie = new Entrie(message.EffectiveDate, message.Description, message.EntrieType, message.Value);
                _entrieRepository.Add(entrie);

                var register = new CreateEntrie(entrie.Id, entrie.EffectiveDate, entrie.Description, entrie.EntrieType, entrie.Value);
                _message.SendMessage(register, "arch-challenge");

                return await SaveData(_entrieRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                throw;
            }
            
            
        }
    }
}
