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

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateStudentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateStudentCommand command)
        {
            if (id != command.StudentData.Id)
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
