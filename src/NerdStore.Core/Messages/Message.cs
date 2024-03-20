namespace NerdStore.Core.Messages
{
    public abstract class Message
    {
        public Message()
        {
            MessageType = GetType().Name;
        }
        public string MessageType { get; protected set; }
        public Guid AggreagateId { get; protected set; }
    }
}
