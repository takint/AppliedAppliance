using Application.Common.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DropDownData
{
    public class GetProvincesDropDownQuery : IRequest<IList<ProvinceDropDown>>
    {
        public GetProvincesDropDownQuery() { }
    }

    public class GetProvincesDropDownQueryHandler : IRequestHandler<GetProvincesDropDownQuery, IList<ProvinceDropDown>>
    {
        public async Task<IList<ProvinceDropDown>> Handle(GetProvincesDropDownQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return ProvinceList.ProvincesData.Select(c => new ProvinceDropDown
                {
                    Value = c.Key,
                    Label = c.Value[1],
                    Description = c.Value[0]
                }).ToList();
            });
        }
    }

    public class ProvinceDropDown : DropDownModel<string>
    {
    }

    public static class ProvinceList
    {
        public static Dictionary<string, string[]> ProvincesData => new Dictionary<string, string[]>
        {
            { "AB", new string[] {"AB" , "Alberta"} },
            { "BC", new string[]  { "BC", "British Columbia" } },
            { "MB", new string[]  { "MB", "Manitoba" } },
            { "NB", new string[]  { "NB", "New Brunswick" } },
            { "NL", new string[]  { "NL", "Newfoundland and Labrador" } },
            { "NS", new string[]  { "NS", "Nova Scotia" } },
            { "NT", new string[]  { "NT", "Northwest Territories" } },
            { "NU", new string[]  { "NU", "Nunavut" } },
            { "ON", new string[]  { "ON", "Ontario" } },
            { "PE", new string[]  { "PE", "Prince Edward Island" } },
            { "QC", new string[]  { "QC", "Quebec" } },
            { "SK", new string[]  { "SK", "Saskatchewan" } },
            { "YT", new string[]  { "YT", "Yukon" } }
        };
    }
}
