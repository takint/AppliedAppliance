using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        protected readonly UserManager<ApplicationUser> StudyPorterUserManager;

        public ApiControllerBase()
        {
        }

        public ApiControllerBase(IDistributedCache distributedCache)
        {
            StudyPorterCache = distributedCache;
        }

        public ApiControllerBase(UserManager<ApplicationUser> userManager)
        {
            StudyPorterUserManager = userManager;
        }
    }
}
