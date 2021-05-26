using Application.Common.Models;
using Application.Schools.Commands;
using Application.Schools.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class SchoolsController : ApiControllerBase
    {
        public SchoolsController(IDistributedCache distributedCache) : base(distributedCache)
        {
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<SchoolDto>>> Get(string state)
        {
            QueryStateModel queryState = new QueryStateModel();
            if (!string.IsNullOrEmpty(state))
            {
                queryState = JsonConvert.DeserializeObject<QueryStateModel>(state);
            }

            PaginatedList<SchoolDto> results = await Mediator.Send(
                new GetSchoolsListQuery(queryState));


            // Demo get list by using cache:
            //var encodedSchools = await AppliedApplianceCache.GetAsync("schoollist");
            //string serializedSchools;

            //if (encodedSchools != null)
            //{
            //    serializedSchools = Encoding.UTF8.GetString(encodedSchools);
            //    vm.Lists = JsonConvert.DeserializeObject<IList<SchoolDto>>(serializedSchools);
            //}
            // else
            //{
            //results = await Mediator.Send(new GetSchoolsWithPaginationQuery());

            //serializedSchools = JsonConvert.SerializeObject(results);
            //encodedSchools = Encoding.UTF8.GetBytes(serializedSchools);

            //var options = new DistributedCacheEntryOptions()
            //                .SetSlidingExpiration(TimeSpan.FromMinutes(5))
            //                .SetAbsoluteExpiration(DateTime.Now.AddHours(6));

            //await AppliedApplianceCache.SetAsync("schoollist", encodedSchools, options);
            // }

            return results;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolViewModel>> Get(int id)
        {
            var vm = await Mediator.Send(new GetSchoolQuery(id));
            return vm;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateSchoolCommand command)
        {
            int result = await Mediator.Send(command);
            return result > 0 ? Accepted() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateSchoolCommand command)
        {
            if (id != command.School.Id)
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
