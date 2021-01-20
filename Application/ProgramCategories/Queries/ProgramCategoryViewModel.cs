using System.Collections.Generic;

namespace Application.ProgramCategories.Queries
{
    public class ProgramCategoryViewModel
    {
        public IList<ProgramCategoryDto> Lists { get; set; }
        public int Total { get; set; }
    }
}
