using Application.Schools.Commands;
using Application.Schools.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class SchoolsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<SchoolViewModel>> Get()
        {
            SchoolViewModel vm = await Mediator.Send(new GetSchoolQuery());
            return vm;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSchoolCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateSchoolCommand command)
        {
            if (id != command.SchoolData.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCampusCommand { Id = id });

            return NoContent();
        }
    }
}
