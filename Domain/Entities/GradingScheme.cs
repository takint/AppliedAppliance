namespace Domain.Entities
{
    public class GradingScheme : BaseEntity<int>
    {
        public string GradingSchemeName { get; set; }
        public string Description { get; set; }
        public int? MinScale { get; set; }
        public int? MaxScale { get; set; }
        public int? Step { get; set; }
        public int? Rank { get; set; }
        public int Type { get; set; }
        public string LetterGrade { get; set; }
        public int LevelId { get; set; }
        public string CountryCode { get; set; }
    }
}
