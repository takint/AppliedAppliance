using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SchoolRepository : BaseRepository<School, int>, ISchoolRepository
    {
        public SchoolRepository(ApplicationDbContext dbContext,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService) 
            : base(dbContext, currentUserService, domainEventService)
        {
        }

        // Write your own logic and business down here
    }
}
