using Application.Common.Interfaces;
using Application.Schools.Queries.GetSchools;
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

    public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateSchoolCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
