using Domain.Entities;
using Infrastructure.Persistence;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
namespace Infrastructure.Repository
{
    public class PandaDocTemplateRepository : BaseRepository<PandaDocTemplate, int>, IPandaDocTemplateRepository
    {
        public PandaDocTemplateRepository(ApplicationDbContext dbContext,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
            : base(dbContext, currentUserService, domainEventService)
        {

        }
    }
}
