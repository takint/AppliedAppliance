using Domain.Entities;
using Infrastructure.Persistence;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProgramRepository : BaseRepository<Program, int>, IProgramRepository
    {
        public ProgramRepository(ApplicationDbContext dbContext,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
            : base (dbContext, currentUserService, domainEventService)
        {

        }
    }
}
