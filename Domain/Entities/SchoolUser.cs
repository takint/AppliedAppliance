namespace Domain.Entities
{
    public class SchoolUser : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public string Phone{ get; set; }
        public string Ext { get; set; }
        public bool Notify { get; set; }
        public bool Approved { get; set; }
        public string UserNoticeMessage { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
