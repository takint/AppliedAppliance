using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IStudentRepository : IRepository<Student, int>
    {
    }
}
