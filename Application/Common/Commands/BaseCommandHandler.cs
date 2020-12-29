using Application.Common.Interfaces;
using AutoMapper;

namespace Application.Common.Commands
{
    public abstract class BaseCommandHandler
    {
        protected readonly IApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public BaseCommandHandler(IApplicationDbContext context)
            : this(context, null)
        { }

        public BaseCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}