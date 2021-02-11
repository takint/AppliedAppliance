using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchoolDocuments.Queries
{
    public class GetDocumentListQuery : IRequest<IList<DropDownModel>>
    {
        public GetDocumentListQuery() { }
    }

    public class GetDocumentListQueryHandler : BaseQueryHandler, IRequestHandler<GetDocumentListQuery, IList<DropDownModel>>
    {
        public GetDocumentListQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<IList<DropDownModel>> Handle(GetDocumentListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Documents
                .Select(c => new DropDownModel
                {
                    Value = c.Id,
                    Label = c.Name,
                    Description = c.Type
                }).ToListAsync();
        }
    }
}


