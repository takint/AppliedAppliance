namespace Domain.Entities
{
    public class Document : BaseEntity<int>
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
    }
}
