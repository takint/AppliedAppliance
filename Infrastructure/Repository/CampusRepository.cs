using Domain.Entities;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Infrastructure.Persistence;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CampusRepository : BaseRepository<Campus, int>, ICampusRepository
    {
        public CampusRepository(ApplicationDbContext dbContext,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
            : base(dbContext, currentUserService, domainEventService)
        {         
        }

        // Write your own logic and business down here

    }
}
