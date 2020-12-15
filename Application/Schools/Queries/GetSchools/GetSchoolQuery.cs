using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Schools.Queries.GetSchools
{
    public class GetSchoolQuery : IRequest<SchoolViewModel>
    {
    }

    public class GetSchoolQueryHandler : IRequestHandler<GetSchoolQuery, SchoolViewModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSchoolQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SchoolViewModel> Handle(GetSchoolQuery request, CancellationToken cancellationToken)
        {
            return new SchoolViewModel
            {
                Lists = await _context.Schools
                    .ProjectTo<SchoolDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
