using Application.DropDownData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class CommonController : ApiControllerBase
    {
        [HttpGet]
        [Route("CountryDropDown")]
        public async Task<IList<CountryDropDown>> GetCountryDropDown()
        {
            var vm = await Mediator.Send(new GetCountriesDropDownQuery());
            return vm;
        }
    }
}
