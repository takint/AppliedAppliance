using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<SchoolUser> SchoolUsers { get; set; }
        DbSet<School> Schools { get; set; }
        DbSet<SchoolRequest> SchoolRequests { get; set; }
        DbSet<SchoolPaymentAccount> SchoolPaymentAccounts { get; set; }
        DbSet<Campus> Campuses { get; set; }
        DbSet<ProgramCategory> ProgramCategories { get; set; }
        DbSet<Program> Programs { get; set; }
        DbSet<CampusProgram> CampusPrograms { get; set; }
        DbSet<PandaDocTemplate> PandaDocTemplates { get; set; }
        DbSet<AssignedProgramPandaDocTemplate> AssignedProgramPandaDocTemplates { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Agent> Agents { get; set; }
        DbSet<StudentApplication> StudentApplications { get; set; }
        DbSet<ApplicationPayment> Payments { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<SchoolDocument> SchoolDocuments { get; set; }
        DbSet<ApplicationDocument> ApplicationDocuments { get; set; }
        DbSet<ApplicationDocumentFile> ApplicationDocumentFiles { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<PandaDocDocument> PandaDocDocuments { get; set; }
        DbSet<StandardGrade> StandardGrades { get; set; }
        DbSet<GradingScheme> GradingSchemes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
