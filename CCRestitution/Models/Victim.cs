namespace CCRestitution.Models
{
    public class Victim : BaseEntity
    {
        public int VictimId { get; set; }
        public int CaseNumber { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Type { get; set; }
        public decimal? AmountDue { get; set; }
        public decimal? AmountPaid { get; set; }
        public string? Notes { get; set; }

    }
}
