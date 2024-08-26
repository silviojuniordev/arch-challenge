using Financial.Entries.Domain.Enums;
using Financial.Entries.Domain.Queues.Configuration;

namespace Financial.Entries.Domain.Queues.Models
{
    public class CreateEntrie : BaseMessage
    {
        public CreateEntrie(Guid id, DateTime effectiveDate, string? description, EntriesEnum entrieType, decimal value)
        {
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
    }
}
