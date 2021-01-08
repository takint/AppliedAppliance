namespace Domain.Entities
{
    public class SchoolRequest : BaseEntity<int>
    {
        public string CountryID { get; set; }
        public string SchoolName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Approved { get; set; }
        public string ContactTitle { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceEmail { get; set; }
        public string Comments { get; set; }
    }
}
