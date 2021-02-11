using Application.Common.Models;
using Application.SchoolDocuments.Commands;
using Application.SchoolDocuments.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class SchoolDocumentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<SchoolDocumentDto>>> Get(string state)
        {
            QueryStateModel queryState = new QueryStateModel();
            if (!string.IsNullOrEmpty(state))
            {
                queryState = JsonConvert.DeserializeObject<QueryStateModel>(state);
            }

            PaginatedList<SchoolDocumentDto> results = await Mediator.Send(new GetSchoolDocumentsListQuery(queryState));

            return results;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDocumentViewModel>> Get(int id)
        {
            var vm = await Mediator.Send(new GetSchoolDocumentQuery(id));
            return vm;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateSchoolDocumentCommand command)
        {
            int result = await Mediator.Send(command);
            return result > 0 ? Accepted() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateSchoolDocumentCommand command)
        {
            if (id != command.SchoolDocument.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteSchoolDocumentCommand { Id = id });

            return Accepted();
        }

    }
}
