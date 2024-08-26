namespace Financial.Entries.Domain.Queues.Configuration
{
    public class BaseMessage
    {
        public long Id { get; set; }
        public DateTime MessageCreated { get; set; }
    }
}
