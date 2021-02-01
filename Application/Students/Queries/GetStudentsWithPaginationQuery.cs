using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Common.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students.Queries
{
    public class GetStudentsListQuery : BaseListQuery<Student, int>, IRequest<PaginatedList<StudentDto>>
    {
        public override Dictionary<KeyValuePair<string, string>, Func<IQueryable<Student>, IOrderedQueryable<Student>>> OrderByMaps
        {
            get
            {
                return new Dictionary<KeyValuePair<string, string>, Func<IQueryable<Student>, IOrderedQueryable<Student>>>()
                {
                    { new KeyValuePair<string, string>("id", "asc"), x => x.OrderBy(t => t.Id) },
                    { new KeyValuePair<string, string>("id", "desc"), x => x.OrderByDescending(t => t.Id) },
                    { new KeyValuePair<string, string>("studentCode", "asc"), x => x.OrderBy(t => t.StudentCode) },
                    { new KeyValuePair<string, string>("studentCode", "desc"), x => x.OrderByDescending(t => t.StudentCode) },
                    { new KeyValuePair<string, string>("firstName", "asc"), x => x.OrderBy(t => t.FirstName) },
                    { new KeyValuePair<string, string>("firstName", "desc"), x => x.OrderByDescending(t => t.FirstName) },
                    { new KeyValuePair<string, string>("lastName", "asc"), x => x.OrderBy(t => t.LastName) },
                    { new KeyValuePair<string, string>("lastName", "desc"), x => x.OrderByDescending(t => t.LastName) },
                    { new KeyValuePair<string, string>("email", "asc"), x => x.OrderBy(t => t.Email) },
                    { new KeyValuePair<string, string>("email", "desc"), x => x.OrderByDescending(t => t.Email) },
                    { new KeyValuePair<string, string>("agent", "asc"), x => x.OrderBy(t => t.AgentId) },
                    { new KeyValuePair<string, string>("agent", "desc"), x => x.OrderByDescending(t => t.AgentId) }
                };
            }
        }

        public GetStudentsListQuery(QueryStateModel queryState) : base(queryState) { }
    }

    public class GetStudentsWithPaginationQueryHandler : BaseQueryHandler, IRequestHandler<GetStudentsListQuery, PaginatedList<StudentDto>>
    {
        public GetStudentsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<PaginatedList<StudentDto>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students
                .Where(request.BasedFilter)
                .Where(s => s.FirstName.Contains(request.SearchTerm))
                .OrderedBy(request.OrderByMap)
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
