namespace Domain.Entities
{
    public class ApplicationDocumentFile : BaseEntity<int>
    {
        public int ApplicationDocumentId { get; set; }
        public long FileId { get; set; }

        //Linked Objects
        public ApplicationDocument ApplicationDocument { get; set; }
        public File File { get; set; }
    }
}
