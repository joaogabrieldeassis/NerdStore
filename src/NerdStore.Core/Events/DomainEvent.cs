using NerdStore.Core.Messages;

namespace NerdStore.Core.Events
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid agregateId)
        {
            AggreagateId = agregateId;
        }
    }
}
