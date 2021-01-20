using Application.SchoolRequests.Commands;
using Application.SchoolRequests.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class SchoolRequestsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<SchoolRequestViewModel>> Get()
        {
            SchoolRequestViewModel vm = await Mediator.Send(new GetSchoolRequestQuery());
            return vm;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSchoolRequestCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update (int id, UpdateSchoolRequestCommand command)
        {
            if (id != command.SchoolRequestData.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteSchoolRequestCommand { Id = id });

            return Accepted();
        }
    }
}
