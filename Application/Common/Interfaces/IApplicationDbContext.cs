using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<School> Schools { get; set; }

        DbSet<SchoolRequest> SchoolRequests { get; set; }

        DbSet<Campus> Campuses { get; set; }

        DbSet<Student> Students { get; set; }

        DbSet<Agent> Agents { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
