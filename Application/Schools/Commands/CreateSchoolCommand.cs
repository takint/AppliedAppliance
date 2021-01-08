using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Schools.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Schools.Commands
{

    public class CreateSchoolCommand : IRequest<int>
    {
        public SchoolDto SchoolData { get; set; }
    }

    public class CreateSchoolCommandHandler : BaseQueryHandler, IRequestHandler<CreateSchoolCommand, int>
    {
        public CreateSchoolCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<int> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<School>(request.SchoolData);

            _context.Schools.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
