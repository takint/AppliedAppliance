using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Schools.Queries.GetSchools;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Schools.Commands
{
    public class UpdateSchoolCommand : IRequest
    {
        public SchoolDto SchoolData { get; set; }
    }

    public class UpdateSchoolCommandHandler : BaseCommandHandler, IRequestHandler<UpdateSchoolCommand>
    {
        public UpdateSchoolCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<Unit> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Schools.FindAsync(request.SchoolData.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Schools), request.SchoolData.Id);
            }

            entity = _mapper.Map<School>(request.SchoolData);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
