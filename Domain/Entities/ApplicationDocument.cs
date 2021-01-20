using Domain.Enums;

namespace Domain.Entities
{
    public class ApplicationDocument : BaseEntity<int>
    {
        public int StudentApplicationId { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }
        public ApplicationDocumentStatus Status { get; protected set; }
        public bool RequirePandaDoc { get; set; }
        public string PandaDocId { get; set; }
        public string DocumentKey { get; set; }

        //Linked Object
        public StudentApplication StudentApplication { get; set; }
    }
}
