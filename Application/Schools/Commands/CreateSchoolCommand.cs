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
        private readonly ISchoolRepository _schoolRepository;

        public CreateSchoolCommandHandler(IApplicationDbContext context, IMapper mapper, ISchoolRepository repository)
            : base(context, mapper)
        {
            _schoolRepository = repository;
        }

        public async Task<int> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<School>(request.SchoolData);

            await _schoolRepository.CreateAsync(entity);

            return entity.Id;
        }
    }
}
