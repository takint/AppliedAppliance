using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProgramCategories.Queries
{
    public class GetProgramCategoryQuery : IRequest<ProgramCategoryViewModel>
    {

        public int ProgramCategoryId { get; set; }

        public GetProgramCategoryQuery() { }

        public GetProgramCategoryQuery(int id)
        {
            ProgramCategoryId = id;
        }
    }

    public class GetProgramCategoryQueryHandler : BaseQueryHandler, IRequestHandler<GetProgramCategoryQuery, ProgramCategoryViewModel>
    {
        public GetProgramCategoryQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<ProgramCategoryViewModel> Handle(GetProgramCategoryQuery request, CancellationToken cancellationToken)
        {
            return new ProgramCategoryViewModel
            {
                ProgramCategory = await _context.ProgramCategories
                    .Where(p => p.Id == request.ProgramCategoryId)
                    .ProjectTo<ProgramCategoryDto>(_mapper.ConfigurationProvider)
                    .OrderBy(p => p.Name)
                    .SingleOrDefaultAsync(cancellationToken)
            };
        }
    }
}
