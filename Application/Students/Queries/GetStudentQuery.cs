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
                Lists = await _context.Students
                    .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                    .OrderBy(s => s.FirstName)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
