using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students.Queries
{
    public class GetStudentQuery : IRequest<StudentViewModel>
    {
        public int StudentId { get; set; }

        public GetStudentQuery() { }

        public GetStudentQuery(int id)
        {
            StudentId = id;
        }
    }

    public class GetStudentQueryHandler : BaseQueryHandler, IRequestHandler<GetStudentQuery, StudentViewModel>
    {
        public GetStudentQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<StudentViewModel> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            return new StudentViewModel
            {
                Student = await _context.Students
                    .Where(s => s.Id == request.StudentId)
                    .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                    .OrderBy(s => s.FirstName)
                    .SingleOrDefaultAsync(cancellationToken)
            };
        }
    }
}
