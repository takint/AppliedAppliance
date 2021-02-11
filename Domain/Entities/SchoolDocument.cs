namespace Domain.Entities
{
    public class SchoolDocument : BaseEntity<int>
    {
        public int SchoolId { get; set; }
        public int DocumentId { get; set; }
        public string Type { get; set; } //TODO - may not be needed as this is document Id which will give the list of documents
        public bool IsRequired { get; set; }
        public string Description { get; set; }
        public string PreTemplate { get; set; } //TODO - not needned as its not used in the old project

        //Linked Objects
        public School School { get; set; }
        public Document Document { get; set; }
    }
}
