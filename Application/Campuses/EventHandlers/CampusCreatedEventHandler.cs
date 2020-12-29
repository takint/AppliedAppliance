using Application.Common.Models;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Campuses.EventHandlers
{
    public class CampusCreatedEventHandler : INotificationHandler<DomainEventNotification<CampusCreatedEvent>>
    {
        private readonly ILogger<CampusCreatedEventHandler> _logger;

        public CampusCreatedEventHandler(ILogger<CampusCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<CampusCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Studyporter Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
