using Application.Agents.Queries;
using Application.Common.Models;
using Application.Programs.Commands;
using Application.Programs.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ProgramsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ProgramDto>>> Get(string state)
        {
            QueryStateModel queryState = new QueryStateModel();
            if (!string.IsNullOrEmpty(state))
            {
                queryState = JsonConvert.DeserializeObject<QueryStateModel>(state);
            }

            PaginatedList<ProgramDto> results = await Mediator.Send(new GetProgramsListQuery(queryState));
            return results;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramViewModel>> Get(int id)
        {
            var vm = await Mediator.Send(new GetProgramQuery(id));
            return vm;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProgramCommand command)
        {
            int result = await Mediator.Send(command);
            return result > 0 ? Accepted() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProgramCommand command)
        {
            if (id != command.Program.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return Accepted();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProgramCommand { Id = id });

            return Accepted();
        }
    }
}
