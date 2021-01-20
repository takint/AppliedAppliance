using System;

namespace Domain.Entities
{
    public class Program : BaseEntity<int>
    {
        public int SchoolId { get; set; }
        public School School { get; set; }
        public int ProgramCategoryId { get; set; }
        public ProgramCategory ProgramCategory { get; set; }
        public int? BrandId { get; set; }
        public int? LeadProgramId { get; set; }
        public int? EATemplateId { get; set; }
        public PandaDocTemplate EATemplate { get; set; }
        public int? AdditionalDocumentId { get; set; }
        public PandaDocTemplate AdditionalDocument { get; set; }
        public string ProgramName { get; set; }
        public int ProgramLevel { get; set; }
        public DateTime? StartDate { get; set; }
        public int? ProgramLength { get; set; }
    }
}
