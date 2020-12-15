using Domain.Common;
using Domain.Entities;

namespace Domain.Events
{
    public class CampusCreatedEvent : DomainEvent
    {
        public CampusCreatedEvent(Campus campus)
        {
            Campus = campus;
        }

        public Campus Campus { get; }
    }
}
