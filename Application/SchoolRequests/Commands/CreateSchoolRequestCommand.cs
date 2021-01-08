using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.SchoolRequests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchoolRequests.Commands
{
    public class CreateSchoolRequestCommand : IRequest<int>
    {
        public SchoolRequestDto SchoolRequestData { get; set; }
    }

    public class CreateSchoolRequestCommandHandler : BaseQueryHandler, IRequestHandler<CreateSchoolRequestCommand, int>
    {
        public CreateSchoolRequestCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<int> Handle(CreateSchoolRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SchoolRequest>(request.SchoolRequestData);

            _context.SchoolRequests.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
