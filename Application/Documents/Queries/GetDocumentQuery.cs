using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Documents.Queries
{
    public class GetDocumentQuery : IRequest<DocumentViewModel>
    {

        public int DocumentId { get; set; }

        public GetDocumentQuery() { }

        public GetDocumentQuery(int id)
        {
            DocumentId = id;
        }
    }

    public class GetDocumentQueryHandler : BaseQueryHandler, IRequestHandler<GetDocumentQuery, DocumentViewModel>
    {
        public GetDocumentQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<DocumentViewModel> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            return new DocumentViewModel
            {
                Document = await _context.Documents
                    .Where(p => p.Id == request.DocumentId)
                    .ProjectTo<DocumentDto>(_mapper.ConfigurationProvider)
                    .OrderBy(p => p.Name)
                    .SingleOrDefaultAsync(cancellationToken)
            };
        }
    }
}
