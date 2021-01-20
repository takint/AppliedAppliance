namespace Domain.Entities
{
    public class School : BaseEntity<int>
    {
        public string SchoolName { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public decimal ApplicationFee { get; set; }
        public bool HasLeadIntegration { get; set; }
        public decimal IELTSlisten { get; set; }
        public decimal IELTSread { get; set; }
        public decimal IELTSwrite { get; set; }
        public decimal IELTSspeak { get; set; }
        public string PGWP { get; set; }
    }
}
