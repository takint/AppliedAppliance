namespace Domain.Entities
{
    public class ProgramCategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
