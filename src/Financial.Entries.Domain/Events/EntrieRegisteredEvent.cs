using Financial.Entries.Domain.Enums;
using Financial.Entries.Domain.Support.Messages;

namespace Financial.Entries.Domain.Events
{
    public class EntrieRegisteredEvent : Event
    {
        public EntrieRegisteredEvent(Guid id, DateTime effectiveDate, string? description, EntriesEnum entrieType, decimal value)
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
