using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchoolRequests.Queries
{
    public class GetSchoolRequestQuery : IRequest<SchoolRequestViewModel>
    {
    }

    public class GetSchoolRequestQueryHandler : BaseQueryHandler, IRequestHandler<GetSchoolRequestQuery, SchoolRequestViewModel>
    {
        public GetSchoolRequestQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<SchoolRequestViewModel> Handle(GetSchoolRequestQuery request, CancellationToken cancellationToken)
        {
            return new SchoolRequestViewModel
            {
                Lists = await _context.SchoolRequests
                    .ProjectTo<SchoolRequestDto>(_mapper.ConfigurationProvider)
                    .OrderBy(s => s.SchoolName)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
