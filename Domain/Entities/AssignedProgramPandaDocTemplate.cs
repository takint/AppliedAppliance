namespace Domain.Entities
{
    public class AssignedProgramPandaDocTemplate : BaseEntity<int>
    {
        public int PandaDocTemplateId { get; set; }
        public int ProgramId { get; set; }
        public int SchoolId { get; set; }
        public string Province { get; set; }

        public PandaDocTemplate PandaDocTemplate { get; set; }
        public Program Program { get; set; }
        public School School { get; set; }
    }
}
