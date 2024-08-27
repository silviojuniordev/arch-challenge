namespace Financial.Entries.Domain.DTO
{
    public class EntrieConsolidateDTO
    {
        public DateTime EffectiveDate { get; set; }
        public string? EntrieType { get; set; }
        public decimal Value { get; set; }
    }
}
