using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public class CampusProgramRepository : BaseRepository<CampusProgram, int>, ICampusProgramRepository
    {
        public CampusProgramRepository(ApplicationDbContext dbContext,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
            : base(dbContext, currentUserService, domainEventService)
        {
        }

        // Write your own logic and business down here
    }
}
