using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Campus : BaseEntity<int>
    {
        public int SchoolId { get; set; }
        public int? BrandId { get; set; }
        public int? LeadCampusId { get; set; }
        public int? SubmissionCode { get; set; }
        public string CampusName { get; set; }
        public Address CampusAddress { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string Province { get; set; }
        //public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Ext { get; set; }
        public decimal ProcessingFee { get; set; }

        public School OwnerSchool { get; set; }
    }
}
