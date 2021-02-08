using Application.CampusesPrograms.Commands;
using Application.CampusesPrograms.Queries;
using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class CampusProgramsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<CampusProgramDto>>> Get(string state)
        {
            QueryStateModel queryState = new QueryStateModel();
            if (!string.IsNullOrEmpty(state))
            {
                queryState = JsonConvert.DeserializeObject<QueryStateModel>(state);
            }

            PaginatedList<CampusProgramDto> results = await Mediator.Send(new GetCampusProgramsListQuery(queryState));
            return results;
        }

        [HttpGet("{id}")]
        public async Task<CampusProgramViewModel> Get(int id)
        {
            var vm = await Mediator.Send(new GetCampusProgramQuery(id));
            return vm;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCampusProgramCommand command)
        {
            int result = await Mediator.Send(command);
            return result > 0 ? Accepted() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCampusProgramCommand command)
        {
            if (id != command.CampusProgram.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCampusProgramCommand { Id = id });
            return Accepted();
        }

    }
}
