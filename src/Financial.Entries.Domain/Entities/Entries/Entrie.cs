using Financial.Entries.Domain.Abstractions;
using Financial.Entries.Domain.Enums;

namespace Financial.Entries.Domain.Entities.Entries
{
    public class Entrie : Entity, IAggregateRoot
    {
        public Entrie(DateTime effectiveDate, string? description, EntriesEnum entrieType, decimal value)
        {
            EffectiveDate = effectiveDate;
            Description = description;
            EntrieType = entrieType;
            Value = value;
            Active = true;
        }

        public DateTime EffectiveDate { get; private set; }
        public string? Description { get; private set; }
        public EntriesEnum EntrieType { get; private set; }
        public decimal Value { get; private set; }
        public bool Active { get; private set; }
    }
}
