using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public class DocumentRepository : BaseRepository<Document, int>, IDocumentRepository
    {
        public DocumentRepository(ApplicationDbContext dbContext,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
            : base(dbContext, currentUserService, domainEventService)
        {
        }

        // Write your own logic and business down here

    }
}
