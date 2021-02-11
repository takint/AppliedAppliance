using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PandaDocTemplates.Queries
{
    public class GetPandaDocTemplateQuery : IRequest<PandaDocTemplateViewModel>
    {
        public int PandaDocTemplateId { get; set; }
        public int SchoolId { get; set; }
        public GetPandaDocTemplateQuery() { }
        public GetPandaDocTemplateQuery(int id)
        {
            PandaDocTemplateId = id;
        }
    }

    public class GetPandaDocTemplateQueryHandler : BaseQueryHandler, IRequestHandler<GetPandaDocTemplateQuery, PandaDocTemplateViewModel>
    {
        public GetPandaDocTemplateQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<PandaDocTemplateViewModel> Handle(GetPandaDocTemplateQuery request, CancellationToken cancellationToken)
        {
            return new PandaDocTemplateViewModel
            {
                PandaDoc = await _context.PandaDocTemplates
                    .Where(s => s.Id == request.PandaDocTemplateId)
                    .ProjectTo<PandaDocTemplateDto>(_mapper.ConfigurationProvider)
                    .OrderBy(s => s.Type)
                    .SingleOrDefaultAsync(cancellationToken)
            };
        }
    }
}
