using Application.Programs.Commands;
using Application.Programs.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ProgramsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ProgramViewModel>> Get()
        {
            ProgramViewModel vm = await Mediator.Send(new GetProgramQuery());
            return vm;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProgramCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProgramCommand command)
        {
            if (id != command.ProgramData.Id)
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
