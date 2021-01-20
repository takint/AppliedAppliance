namespace Domain.Entities
{
    public class SchoolDocument : BaseEntity<int>
    {
        public int SchoolId { get; set; }
        public int DocumentId { get; set; }
        public string Type { get; set; }
        public bool IsRequired { get; set; }
        public string Description { get; set; }
        public string PreTemplate { get; set; }

        //Linked Objects
        public School School { get; set; }
        public Document Document { get; set; }
    }
}
