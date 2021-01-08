using Application.Common.Interfaces;
using AutoMapper;

namespace Application.Common.Commands
{
    public abstract class BaseQueryHandler
    {
        protected readonly IApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public BaseQueryHandler(IApplicationDbContext context)
            : this(context, null)
        { }

        public BaseQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}