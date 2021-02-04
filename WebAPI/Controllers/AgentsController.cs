using Application.Agents.Commands;
using Application.Agents.Queries;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    public class AgentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<AgentDto>>> Get(string state)
        {
            QueryStateModel queryState = new QueryStateModel();
            if (!string.IsNullOrEmpty(state))
            {
                queryState = JsonConvert.DeserializeObject<QueryStateModel>(state);
            }

            PaginatedList<AgentDto> results = await Mediator.Send(new GetAgentsListQuery(queryState));

            //AgentViewModel vm = await Mediator.Send(new GetAgentQuery());
            return results;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgentViewModel>> Get(int id)
        {
            var vm = await Mediator.Send(new GetAgentQuery(id));
            return vm;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateAgentCommand command)
        {
            int result = await Mediator.Send(command);
            return result > 0 ? Accepted() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateAgentCommand command)
        {
            if (id != command.Agent.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAgentCommand { Id = id });

            return Accepted();
        }
    }
}
