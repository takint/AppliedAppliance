using Application.Common.Models;
using Application.ProgramCategories.Commands;
using Application.ProgramCategories.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ProgramCategoriesController : ApiControllerBase
    {
        // GET: api/<ProgramCategoriesController>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ProgramCategoryDto>>> Get(string state)
        {
            QueryStateModel queryState = new QueryStateModel();
            if (!string.IsNullOrEmpty(state))
            {
                queryState = JsonConvert.DeserializeObject<QueryStateModel>(state);
            }

            PaginatedList<ProgramCategoryDto> results = await Mediator.Send(new GetProgramCategoriesListQuery(queryState));

            return results;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramCategoryViewModel>> Get(int id)
        {
            var vm = await Mediator.Send(new GetProgramCategoryQuery(id));

            return vm;
        }

        // POST api/<ProgramCategoriesController>
        [HttpPost]
        public async Task<ActionResult> Create(CreateProgramCategoryCommand command)
        {
            int result = await Mediator.Send(command);
            return result > 0 ? Accepted() : BadRequest();
        }

        // PUT api/<ProgramCategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProgramCategoryCommand command)
        {
            if (id != command.ProgramCategory.Id)
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
