using Domain.Entities;
using Infrastructure.Persistence;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AgentRepository : BaseRepository<Agent, int>, IAgentRepository
    {
        public AgentRepository(ApplicationDbContext dbContext,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
            : base(dbContext, currentUserService, domainEventService)
        {

        }
    }
}
