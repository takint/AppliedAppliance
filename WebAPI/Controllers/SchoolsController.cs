using Application.Schools.Commands;
using Application.Schools.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class SchoolsController : ApiControllerBase
    {
        public SchoolsController(IDistributedCache distributedCache) : base(distributedCache)
        {
        }

        [HttpGet]
        public async Task<ActionResult<SchoolViewModel>> Get()
        {

            // Demo get list by using cache:
            var encodedSchools = await StudyPorterCache.GetAsync("schoollist");
            string serializedSchools;

            SchoolViewModel vm = new SchoolViewModel();

            if (encodedSchools != null)
            {
                serializedSchools = Encoding.UTF8.GetString(encodedSchools);
                vm.Lists = JsonConvert.DeserializeObject<IList<SchoolDto>>(serializedSchools);
            }
            else
            {
                vm = await Mediator.Send(new GetSchoolQuery());

                serializedSchools = JsonConvert.SerializeObject(vm.Lists);
                encodedSchools = Encoding.UTF8.GetBytes(serializedSchools);

                var options = new DistributedCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                                .SetAbsoluteExpiration(DateTime.Now.AddHours(6));

                await StudyPorterCache.SetAsync("schoollist", encodedSchools, options);
            }

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

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCampusCommand { Id = id });

            return Accepted();
        }
    }
}
