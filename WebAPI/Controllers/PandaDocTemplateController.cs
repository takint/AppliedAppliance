using Application.PandaDocTemplates.Commands;
using Application.PandaDocTemplates.Queries;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class PandaDocTemplateController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<PandaDocTemplateDto>>> Get(string state)
        {
            QueryStateModel queryState = new QueryStateModel();
            if (!string.IsNullOrEmpty(state))
            {
                queryState = JsonConvert.DeserializeObject<QueryStateModel>(state);
            }

            PaginatedList<PandaDocTemplateDto> results = await Mediator.Send(new GetPandaDocTemplatesListQuery(queryState));

            return results;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PandaDocTemplateViewModel>> Get(int id)
        {
            var vm = await Mediator.Send(new GetPandaDocTemplateQuery(id));
            return vm;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePandaDocTemplateCommand command)
        {
            int result = await Mediator.Send(command);
            return result > 0 ? Accepted() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdatePandaDocTemplateCommand command)
        {
            if (id != command.PandaDocTemplate.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePandaDocTemplateCommand { Id = id });

            return Accepted();
        }
    }
}
