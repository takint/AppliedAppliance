using Application.Students.Queries;
using Application.Students.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class StudentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<StudentViewModel>> Get()
        {
            StudentViewModel vm = await Mediator.Send(new GetStudentQuery());
            return vm;
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
