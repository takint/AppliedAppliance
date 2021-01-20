using System.Collections.Generic;

namespace Application.Programs.Queries
{
    public class ProgramViewModel
    {
        public IList<ProgramDto> List { get; set; }
        public int Total { get; set; }
    }
}
