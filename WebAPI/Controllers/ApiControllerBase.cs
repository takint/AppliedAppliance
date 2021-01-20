using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

        protected readonly IDistributedCache StudyPorterCache;

        public ApiControllerBase()
        { }

        public ApiControllerBase(IDistributedCache distributedCache)
        {
            StudyPorterCache = distributedCache;
        }
    }
}
