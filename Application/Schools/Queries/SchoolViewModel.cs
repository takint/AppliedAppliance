using System.Collections.Generic;

namespace Application.Schools.Queries
{
    public class SchoolViewModel
    {
        public IList<SchoolDto> Lists { get; set; }
        public int Total { get; set; }
    }
}
