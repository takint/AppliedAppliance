using Application.Common.Mappings;
using Application.Common.Models;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class UsersController : ApiControllerBase
    {
        public UsersController(UserManager<ApplicationUser> userManager) : base(userManager)
        { }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ApplicationUser>>> Get(string state)
        {
            QueryStateModel queryState = new QueryStateModel();

            if (!string.IsNullOrEmpty(state))
            {
                queryState = JsonConvert.DeserializeObject<QueryStateModel>(state);
            }

            var results = await StudyPorterUserManager.Users
                .Where(u => u.Email.Contains(queryState.SearchTerm))
                .PaginatedListAsync(queryState.Page, queryState.PageSize);

            return results;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUser(string id)
        {
            var vm = await StudyPorterUserManager.Users
                .FirstOrDefaultAsync(u => u.Id == id);
            return vm;
        }
    }
}
