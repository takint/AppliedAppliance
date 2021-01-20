using Application.ProgramCategories.Commands;
using Application.ProgramCategories.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ProgramCategoriesController : ApiControllerBase
    {
        // GET: api/<ProgramCategoriesController>
        [HttpGet]
        public async Task<ActionResult<ProgramCategoryViewModel>> Get()
        {
            ProgramCategoryViewModel vm = await Mediator.Send(new GetProgramCategoryQuery());
            return vm;
        }

        // POST api/<ProgramCategoriesController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProgramCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<ProgramCategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProgramCategoryCommand command)
        {
            if (id != command.ProgramCategoryData.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return Accepted();
        }

        // DELETE api/<ProgramCategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProgramCategoryCommand { Id = id });

            return Accepted();
        }
    }
}
