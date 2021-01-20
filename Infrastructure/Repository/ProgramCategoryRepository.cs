using Domain.Entities;
using Infrastructure.Persistence;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;

namespace Infrastructure.Repository
{
    public class ProgramCategoryRepository : BaseRepository<ProgramCategory, int>, IProgramCategoryRepository
    {
        public ProgramCategoryRepository(ApplicationDbContext dbContext,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
            : base(dbContext, currentUserService, domainEventService)
        {

        }
    }
}
