using Domain.Entities;
using Application.Common.Interfaces.Repository;
using Infrastructure.Persistence;
using Application.Common.Interfaces;

namespace Infrastructure.Repository
{
    public class SchoolRequestRepository : BaseRepository<SchoolRequest, int>, ISchoolRequestRepository
    {
        public SchoolRequestRepository(ApplicationDbContext dbContext,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
            : base(dbContext, currentUserService, domainEventService)
        {
        }

        //Write your own logic and business down here
    }
}
