using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Schools.Queries.GetSchools;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Campuses.Commands
{
    public class UpdateCampusCommand : IRequest<int>
    {
        public int SchoolId { get; set; }
        public CampusDto CampusData { get; set; }
    }

    public class UpdateCampusCommandHandler : BaseCommandHandler, IRequestHandler<UpdateCampusCommand, int>
    {
        public UpdateCampusCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper) 
        { }

        public Task<int> Handle(UpdateCampusCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
