using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public class SchoolDocumentRepository : BaseRepository<SchoolDocument, int>, ISchoolDocumentRepository
    {
        public SchoolDocumentRepository(ApplicationDbContext dbContext,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
            : base(dbContext, currentUserService, domainEventService)
        {

        }
    }
}
