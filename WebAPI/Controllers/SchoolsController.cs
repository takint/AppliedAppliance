using Application.Schools.Commands;
using Application.Schools.Queries.GetSchools;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class SchoolsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<SchoolViewModel>> Get()
        {
            return await Mediator.Send(new GetSchoolQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSchoolCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
