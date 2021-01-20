namespace Domain.Entities
{
    public class CampusProgram : BaseEntity<int>
    {
        public decimal DomTuition { get; set; }
        public decimal IntlTuition { get; set; }
        public string StartDates { get; set; }
        public int CampusId { get; set; }
        public  Campus Campus { get; set; }
        public int ProgramId { get; set; }
        public Program Program { get; set; }
    }
}
