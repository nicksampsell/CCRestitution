namespace CCRestitution.Models
{
    public class Judge : BaseEntity
    {
        public int JudgeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? CourtId { get; set; }
        public Court? Court { get; set; }
    }
}
