namespace Domain.Entities
{
    public class StandardGrade : BaseEntity<int>
    {
        public string Grade { get; set; }
        public int Rank { get; set; }
    }
}
