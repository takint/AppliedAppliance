using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Schools.Queries
{
    public class GetSchoolQuery : IRequest<SchoolViewModel>
    {
        public int SchoolId { get; set; }

        public GetSchoolQuery() { }

        public GetSchoolQuery(int id)
        {
            SchoolId = id;
        }
    }

    public class GetSchoolQueryHandler : BaseQueryHandler, IRequestHandler<GetSchoolQuery, SchoolViewModel>
    {
        public GetSchoolQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<SchoolViewModel> Handle(GetSchoolQuery request, CancellationToken cancellationToken)
        {
            return new SchoolViewModel
            {
                School = await _context.Schools
                .Where(s => s.Id == request.SchoolId)
                .ProjectTo<SchoolDto>(_mapper.ConfigurationProvider)
                .OrderBy(s => s.SchoolName)
                .SingleOrDefaultAsync(cancellationToken)
            };
        }
    }
}
