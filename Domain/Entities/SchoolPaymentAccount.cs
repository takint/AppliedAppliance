namespace Domain.Entities
{
    public class SchoolPaymentAccount : BaseEntity<int>
    {
        public string Description { get; set; }
        public string Province { get; set; }
        public byte AccountType { get; set; }
        public string AccountId { get; set; }
        public string AccountClientId { get; set; }
        public string ApplicationServiceId { get; set; }
        public string TuitionServiceId { get; set; }
        public string AccountVendorCode { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
