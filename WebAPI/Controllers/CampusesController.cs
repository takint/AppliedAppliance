using Application.Campuses.Commands;
using Application.Campuses.Queries;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class CampusesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<CampusDto>>> Get(string state)
        {
            QueryStateModel queryState = new QueryStateModel();
            if (!string.IsNullOrEmpty(state))
            {
                queryState = JsonConvert.DeserializeObject<QueryStateModel>(state);
            }

            PaginatedList<CampusDto> results = await Mediator.Send(new GetCampusesListQuery(queryState));
            return results;
        }

        [HttpGet("{id}")]
        public async Task<CampusViewModel> Get(int id)
        {
            var vm = await Mediator.Send(new GetCampusQuery(id));
            return vm;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCampusCommand command)
        {
            int result = await Mediator.Send(command);
            return result > 0 ? Accepted() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCampusCommand command)
        {
            if (id != command.Campus.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCampusCommand { Id = id });
            return Accepted();
        }
    }
}
