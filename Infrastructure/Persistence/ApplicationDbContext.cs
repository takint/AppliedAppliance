using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using IdentityServer4.EntityFramework.Options;
using Infrastructure.Identity;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService) : base(options, operationalStoreOptions)
        {
            _domainEventService = domainEventService;
            _currentUserService = currentUserService;
        }

        public DbSet<SchoolUser> SchoolUsers { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolRequest> SchoolRequests { get; set; }
        public DbSet<SchoolPaymentAccount> SchoolPaymentAccounts { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<ProgramCategory> ProgramCategories { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<CampusProgram> CampusPrograms { get; set; }
        public DbSet<PandaDocTemplate> PandaDocTemplates { get; set; }
        public DbSet<AssignedProgramPandaDocTemplate> AssignedProgramPandaDocTemplates { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<StudentApplication> StudentApplications { get; set; }
        public DbSet<ApplicationPayment> Payments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<SchoolDocument> SchoolDocuments { get; set; }
        public DbSet<ApplicationDocument> ApplicationDocuments { get; set; }
        public DbSet<ApplicationDocumentFile> ApplicationDocumentFiles { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<PandaDocDocument> PandaDocDocuments { get; set; }
        public DbSet<StandardGrade> StandardGrades { get; set; }
        public DbSet<GradingScheme> GradingSchemes { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents();

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());      
            modelBuilder.Ignore<AssignedProgramPandaDocTemplate>();

            base.OnModelCreating(modelBuilder);
        }

        private async Task DispatchEvents()
        {
            var domainEventEntities = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .Where(domainEvent => !domainEvent.IsPublished);

            foreach (var domainEvent in domainEventEntities)
            {
                domainEvent.IsPublished = true;
                await _domainEventService.Publish(domainEvent);
            }
        }
    }
}
