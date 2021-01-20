using Application.Agents.Commands;
using Application.Agents.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    public class AgentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<AgentViewModel>> Get()
        {
            AgentViewModel vm = await Mediator.Send(new GetAgentQuery());
            return vm;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateAgentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateAgentCommand command)
        {
            if (id != command.AgentData.Id)
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
