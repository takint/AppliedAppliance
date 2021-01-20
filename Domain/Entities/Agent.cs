using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Agent : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string BusinessLicense { get; set; }
        public string Website { get; set; }
        public string MainSourceStudent { get; set; }
        public Address Address { get; set; }
        //public string StreetName { get; set; }
        //public string StreetNumber { get; set; }
        //public string City { get; set; }
        //public string Province { get; set; }
        //public string CountryCode { get; set; }
        //public string PostalCode { get; set; }
        public bool Notify { get; set; }
        public bool Approved { get; set; }
        public string Comments { get; set; }
        public string UserNoticeMessage { get; set; }

        public int? ManagerId { get; set; }
        public Agent AgentManager { get; set; }
    }
}
