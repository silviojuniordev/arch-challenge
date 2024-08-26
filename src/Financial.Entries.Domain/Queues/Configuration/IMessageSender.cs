namespace Financial.Entries.Domain.Queues.Configuration
{
    public interface IMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
