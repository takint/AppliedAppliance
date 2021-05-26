using Application.Common.Models;
using Application.DropDownData;
using Application.SchoolDocuments.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class CommonController : ApiControllerBase
    {
        private readonly RoleManager<IdentityRole> AppliedApplianceRoleManager;

        public CommonController(RoleManager<IdentityRole> roleManager)
        {
            AppliedApplianceRoleManager = roleManager;
        }

        [HttpGet]
        [Route("CountryDropDown")]
        public async Task<IList<CountryDropDown>> GetCountryDropDown()
        {
            var vm = await Mediator.Send(new GetCountriesDropDownQuery());
            return vm;
        }

        [HttpGet]
        [Route("ProvinceDropDown")]
        public async Task<IList<ProvinceDropDown>> GetProvinceDropDown()
        {
            var vm = await Mediator.Send(new GetProvincesDropDownQuery());
            return vm;
        }

        [HttpGet]
        [Route("DocumentGroupListDropDown")]
        public async Task<IList<DropDownModel>> GetDocumentGroupListDropDown()
        {
            var vm = await Mediator.Send(new GetDocumentGroupListDropDownQuery());
            return vm;
        }

        [HttpGet]
        [Route("DocumentTypeListDropDown")]
        public async Task<IList<DropDownModel>> GetDocumentTypeListDropDown()
        {
            var vm = await Mediator.Send(new GetDocumentListQuery());
            return vm;
        }

        [HttpGet]
        [Route("RoleDropDown")]
        public async Task<IList<DropDownModel<string>>> GetRoleDropDown()
        {
            var vm = await AppliedApplianceRoleManager.Roles
                .Select(r => new DropDownModel<string>
                {
                    Label = r.Name,
                    Value = r.Id,
                    Description = r.ConcurrencyStamp
                }).ToListAsync();

            return vm;
        }
    }

}
