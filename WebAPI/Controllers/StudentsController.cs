using Application.Students.Queries;
using Application.Students.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Common.Models;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class StudentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<StudentDto>>> Get(string state)
        {
            QueryStateModel queryState = new QueryStateModel();
            if (!string.IsNullOrEmpty(state))
            {
                queryState = JsonConvert.DeserializeObject<QueryStateModel>(state);
            }

            PaginatedList<StudentDto> results = await Mediator.Send(
                new GetStudentsListQuery(queryState));

            return results;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentViewModel>> Get(int id)
        {
            var vm = await Mediator.Send(new GetStudentQuery(id));
            return vm;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateStudentCommand command)
        {
            int result = await Mediator.Send(command);
            return result > 0 ? Accepted() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateStudentCommand command)
        {
            if (id != command.Student.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteStudentCommand { Id = id });

            return Accepted();
        }
    }
}
