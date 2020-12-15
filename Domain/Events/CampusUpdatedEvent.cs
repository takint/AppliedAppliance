using Domain.Common;
using Domain.Entities;

namespace Domain.Events
{
    public class CampusUpdatedEvent : DomainEvent
    {
        public CampusUpdatedEvent(Campus campus)
        {
            Campus = campus;
        }

        public Campus Campus { get; }
    }
}
