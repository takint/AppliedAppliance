namespace Domain.Entities
{
    public class Document : BaseEntity<int>
    {
        public string Type { get; set; } //TODO - Check with IVAN should be removed as the type and name is the same thing 
        public string Name { get; set; }
        public string Group { get; set; }
    }
}
 