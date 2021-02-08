using Application.Common.Models;
using Application.Documents.Commands;
using Application.Documents.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class DocumentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<DocumentDto>>> Get(string state)
        {
            QueryStateModel queryState = new QueryStateModel();
            if (!string.IsNullOrEmpty(state))
            {
                queryState = JsonConvert.DeserializeObject<QueryStateModel>(state);
            }

            PaginatedList<DocumentDto> results = await Mediator.Send(new GetDocumentsListQuery(queryState));

            return results;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentViewModel>> Get(int id)
        {
            var vm = await Mediator.Send(new GetDocumentQuery(id));

            return vm;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateDocumentCommand command)
        {
            int result = await Mediator.Send(command);
            return result > 0 ? Accepted() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateDocumentCommand command)
        {
            if (id != command.Document.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteDocumentCommand { Id = id });

            return Accepted();
        }
    }
}
