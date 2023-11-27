namespace CCRestitution.Models
{
    public class Court : BaseEntity
    {
        public int CourtId { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public List<Judge>? Judges { get; set; }
    }
}
