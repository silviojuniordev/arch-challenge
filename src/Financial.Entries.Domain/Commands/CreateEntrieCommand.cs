using Financial.Entries.Domain.Enums;
using Financial.Entries.Domain.Support.Messages;
using FluentValidation;

namespace Financial.Entries.Domain.Commands
{
    public class CreateEntrieCommand : Command
    {
        public CreateEntrieCommand(Guid id, DateTime effectiveDate, string? description, EntriesEnum entrieType, decimal value)
        {
            AggregateId = id;
            Id = id;
            EffectiveDate = effectiveDate;
            Description = description;
            EntrieType = entrieType;
            Value = value;
        }

        public Guid Id { get; private set; }
        public DateTime EffectiveDate { get; private set; }
        public string? Description { get; private set; }
        public EntriesEnum EntrieType { get; private set; }
        public decimal Value { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateEntrieValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class CreateEntrieValidation : AbstractValidator<CreateEntrieCommand>
        {
            public CreateEntrieValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do cliente inválido");

                RuleFor(c => c.EffectiveDate)
                    .NotEmpty()
                    .WithMessage("A Data do lançamento não foi informada");

                RuleFor(c => c.Description)
                    .NotEmpty()
                    .WithMessage("A Descrição do lançamento não foi informada");

                RuleFor(c => c.Value)
                    .NotEmpty()
                    .WithMessage("O Valor do lançamento não foi informada");
            }
        }
    }
}
