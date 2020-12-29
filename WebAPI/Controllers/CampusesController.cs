using Application.Campuses.Commands;
using Application.Campuses.Queries;
using Application.Common.Models;
using Application.Schools.Queries.GetSchools;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class CampusesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<CampusDto>>> GetCampusesWithPagination([FromQuery] GetCampusesWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCampusCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
