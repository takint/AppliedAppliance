using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchoolDocuments.Queries
{
    public class GetSchoolDocumentQuery : IRequest<SchoolDocumentViewModel>
    {
        public int SchoolDocumentId { get; set; }
        public int SchoolId { get; set; }
        public int DocumentId { get; set; }

        public GetSchoolDocumentQuery() { }
        public GetSchoolDocumentQuery(int id)
        {
            SchoolDocumentId = id;
        }
    }

    public class GetSchoolDocumentQueryHandler : BaseQueryHandler, IRequestHandler<GetSchoolDocumentQuery, SchoolDocumentViewModel>
    {
        public GetSchoolDocumentQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<SchoolDocumentViewModel> Handle(GetSchoolDocumentQuery request, CancellationToken cancellationToken)
        {
            return new SchoolDocumentViewModel
            {
                SchoolDocument = await _context.SchoolDocuments
                    .Where(s => s.Id == request.SchoolDocumentId)
                    .ProjectTo<SchoolDocumentDto>(_mapper.ConfigurationProvider)
                    .OrderBy(s => s.Type)
                    .SingleOrDefaultAsync(cancellationToken)
            };
        }
    }
}
