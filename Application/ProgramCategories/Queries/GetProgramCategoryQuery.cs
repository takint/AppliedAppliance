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
                Lists = await _context.ProgramCategories
                    .ProjectTo<ProgramCategoryDto>(_mapper.ConfigurationProvider)
                    .OrderBy(p => p.Name)
                    .ToListAsync(cancellationToken),
                Total = await _context.ProgramCategories.CountAsync(cancellationToken)
            };
        }
    }
}
